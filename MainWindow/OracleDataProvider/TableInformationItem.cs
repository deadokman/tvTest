using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataProvider;

namespace DataProvider
{
    public class TableInformationItem
    {
        ///<summary> Справочник по столбцам, со списком значений по номерам строк </summary>
        private Dictionary<string, TabRowsItem> _dict;  
        ///<summary> Справочник по столбцам, со списком значений по номерам строк </summary>
        public int RowCount { get; private set; }


        ///<summary> Название таблицы по которой содержится информация в данном объекте </summary>
        public string TableName { get; private set; }
        ///<summary> Лист доступных столбцов </summary>
        public List<string> TabCols;

        private void AddNewColAndVal(string colName, string colVal, int rowIdx)
        {
            if (RowCount + 1 == rowIdx)
                RowCount++;
            TabCols.Add(colName);
            _dict.Add(colName, new TabRowsItem(RowCount, colVal));
        }

        ///<summary> Конструктор для создания объекта вне запроса данных </summary>
        public TableInformationItem(string tableName)
        {
            //Создать структуры данных
            TabCols = new List<string>();
            _dict = new Dictionary<string, TabRowsItem>();
            RowCount = 0;
            if (tableName != null)
                TableName = tableName;
            else
                TableName = "NoTab";
        }

       ///<summary> Конструктор для создания объекта при запросе данных </summary>
        public TableInformationItem(SelectQuery query)
        {

            //Создать структуры данных
            TabCols = new List<string>();
            _dict = new Dictionary<string, TabRowsItem>();
            RowCount = 0;
            if (query != null)
            {
                TableName = query.TabName;
               /* if (query.Cols.Count() > 0)
                    query.Cols.ForEach(col => 
                    {
                        if (!_dict.ContainsKey(col))
                        {
                            _dict.Add(col, new TabRowsItem(0, "NULL"));
                            TabCols.Add(col);
                        }
                    });*/
            }
            else
                TableName = "NoTab";

        }

        public void SetVal(string colName, string colVal, int rowIdx)
        {
            //Если пытаемся установить значение в строку которая больше количества имеющихся строк больше чем на 1
            //то вызываем эксепшн
            //иначе или добавляем значение или создаем новую строку.
            string value;
            if (colVal == "")
                value = null;
            else
                value = colVal;


            if (rowIdx > RowCount + 1)
                throw new IndexOutOfRangeException();
            if ((!TabCols.Any(col => col == colName) && (rowIdx <= RowCount + 1)))
                AddNewColAndVal(colName, value, rowIdx);
            else
                if (_dict[colName] != null)
                {
                    if (rowIdx == RowCount + 1)
                        RowCount++;
                    _dict[colName].SetVal(rowIdx, value);
                }
             
        }

        public TabRowsItem GetColData(string colName)
        {
            if (colName == null)
                return null;
            if (!TabCols.Any(col => col == colName))
                throw new IndexOutOfRangeException();
            if (_dict.ContainsKey(colName))
                return _dict[colName];
            else
                return null;
        }

        public string GetColDataByIdx(string colName, int colIdx)
        {
            if (colName == null)
                return null;
            if (!TabCols.Any(col => col == colName))
                throw new IndexOutOfRangeException();
            if (_dict.ContainsKey(colName))
                return _dict[colName].GetVal(colIdx);
            else
                throw new IndexOutOfRangeException();
        }

        public TabRowsItem this[string ColName]    // Индексирование
        {
            get { return GetColData(ColName); }
        }
    }
}
