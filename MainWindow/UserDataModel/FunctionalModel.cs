using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UserDataModel
{
    public class FunctionalModelData
    {
        public EFunctionalTag Tag { get; private set; }
        public string Roleid { get; set; }
        private bool _isActive;
    }
}
