using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Tvm.Service;

namespace Vtm.Service.ConsoleHost
{
    public  class Program 
    {

        public  static void Main(string[] args)
        {
            Logger.MessageThrow += OnLoggerMessage;
            ServiceBase.Run(new TvmService());
        }

        private static void OnLoggerMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
