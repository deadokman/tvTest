using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProvider
{
    public class SelectQuery
    {
        public string TabName { get; private set; }
        public List<string> Cols;
        public List<string> Conditions;
        public SelectQuery(string tableName, string[] cols, string[] condtions)
        {
            TabName = tableName;
            Cols = cols.ToList();
            if (condtions != null)
                Conditions = condtions.ToList();
            else
                Conditions = new List<string>();
        }

    }
}
