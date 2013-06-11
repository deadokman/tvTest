using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tvm.Service
{
    public static class Logger
    {
        public delegate void LoggerMessageThrown(string msg);

        public static event LoggerMessageThrown MessageThrow;

        public static void LogEvent(string msg)
        {
            if (MessageThrow == null) return;
            MessageThrow(msg);
        }
    }
}
