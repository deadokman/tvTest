using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProvider
{
    public interface IOracleDataProvider
    {
        ///<summary> Получить информацию по запросу из таблицы </summary>
        TableInformationItem GetTableData (SelectQuery query);
    }
}
