using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Timers;
using DataProvider;
using System.ServiceModel;
using System.ServiceProcess;
using System.Configuration;

namespace Tvm.Service
{
    public class TvmService : ServiceBase, ITvmService 
    {
        private string _connectionString;
        private OracleDbProvider _provider;
        private ServiceAuthorizationModel _userAuthorizationModel;
        private Timer _loadtimer;
        private ProviderDataAdapter _dataAdapter;
        private List<TableInformationItem>  _dataTables;

        private bool _isBaseDataInit;


        #region Контракты операций
        
        public ServiceHost host;

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public bool AuthorizeUser(string userId, string userPwdHash)
        {
            if (!_isBaseDataInit) InitServiceData();

        }


        #endregion Контракты операций

        public TvmService()
        {
            var t = ConfigurationManager.GetSection("connectionStrings");
            _connectionString = ConfigurationManager.ConnectionStrings["OraConn"].ConnectionString;
            _provider = new OracleDbProvider("TEST", "TV_MANAGER", _connectionString);
            _loadtimer = new Timer(12000);
            _loadtimer.Start();
            _loadtimer.Elapsed += OnLoadTimerElapsed;
            ServiceName = "WCFWindowsServiceSample";
           _dataTables = new List<TableInformationItem>();
        }

        public void InitServiceData()
        {
            if (_isBaseDataInit) return;
            Logger.LogEvent("Сервис запущен, выгрузка справочников пользователей");
            _userAuthorizationModel = new ServiceAuthorizationModel(DataQuerys.UserDataQuerys().Select(dq => _provider.GetTableData(dq)).ToList());
            Logger.LogEvent("Загружено " + _userAuthorizationModel.DataBaseTables.Count);
            _isBaseDataInit = true;

        }



        public void OnLoadTimerElapsed(object sender, EventArgs e)
        {
            InitServiceData();

        }

        protected override void OnStart(string[] args)
        {
            if (host != null)
            {
                host.Close();
            }

            Type serviceType = typeof(TvmService);
            Uri serviceUri = new Uri("http://localhost:8080/");
            host = new ServiceHost(serviceType, serviceUri);

            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            host.Open();
        }

        protected override void OnStop()
        {
            if (host != null)
            {
                host.Close();
                host = null;
            }
        }

    }
}
