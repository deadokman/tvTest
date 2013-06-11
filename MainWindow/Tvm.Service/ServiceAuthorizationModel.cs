using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;
using UserDataModel;

namespace Tvm.Service
{
    public class ServiceAuthorizationModel
    {
        private List<UserDataItem> _usersData;
        private List<RoleVariantModelData> _roles;
        private List<FunctionalModelData> _functionals; 

        public List<TableInformationItem> DataBaseTables { get; private set; }

        public ServiceAuthorizationModel(List<TableInformationItem> tablesData)
        {
              DataBaseTables = tablesData;
        }

        private void InitStates()
        {
            var tabPrc = DataBaseTables.FirstOrDefault(tbl => tbl.TableName == DataQuerys.UserFunctionalsTab);
            for (var i = 0; i < tabPrc.RowCount; i++)
            {
                foreach (var colData in tabPrc.TabCols)
                {
                    switch (colData)
                    {
                            
                    }
                    
                }
            }
        }


    }
}
