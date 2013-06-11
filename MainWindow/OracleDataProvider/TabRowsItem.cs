using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProvider
{
    public  class TabRowsItem
    {
        private Dictionary<int, string> _dict;  

        public TabRowsItem(int rowIdx, string val)
        {
            _dict = new Dictionary<int, string>();
            _dict.Add(rowIdx, val);
        }

        public void SetVal(int idx, string val)
        {
            if (_dict.Count() >= idx)
                _dict[idx] = val;
            else
                _dict.Add(idx, val);
        }

        public string GetVal(int idx)
        {
            if (_dict.ContainsKey(idx))
                return _dict[idx];
            else
                return null;
        }

        public string this[int index]    // Индексирвоание
        {
            get { return GetVal(index); }
            set { SetVal(index, value); }
        }

    }
}
