using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbInfo;
using DbInfo.Objects;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace DataProvider
{
    public class DbProvider : IDbProvider
    {
        OracleDataReader reader;
        OracleConnection _connection;
        private string _login;
        private string _pass;
        private string _connectionString;



        public DbProvider(string passw, string user_id, string connectionString)
        {
            _connection = new OracleConnection();
            if (passw != null)
                _pass = "PASSWORD=" + passw;
            if (user_id != null)
                _login = "USER ID=" + user_id;
            _connectionString = connectionString;

        }

        public OracleConnection GetDbconnection()
        {
            return _connection;
        }

        public List<Table> ExtractdatabaseInfo(List<string> tablesNamesList)
        {
           var DbInfoExtractor = new InfoExtractor(_connection);
           var data = DbInfoExtractor.Extract(tablesNamesList);
            return data;
        }

          

        public TableInformationItem GetTableData(SelectQuery query)
        {
            if (_connectionString == null)
                throw new Exception("Строка подключения не инициализирована");
                _connection.ConnectionString = _connectionString + ";" + _login + ";" + _pass;
            try
            {
                _connection.Open();
            }
            catch(Exception ex)
            {
                throw new Exception("Ошибка открытия соединения "+ ex.Data);
            }
            var cmd = _connection.CreateCommand();
            var tableInfo = new TableInformationItem(query);
            //TODO: Реализовать выборку по конкретным столбцам
            cmd.CommandText = "select ";
            query.Cols.ForEach(column =>{
                                            cmd.CommandText = cmd.CommandText + column;
                                            if (column != query.Cols.Last() ) 
                                                cmd.CommandText = cmd.CommandText + ", "; 
                                        });
            cmd.CommandText = cmd.CommandText + " from " + query.TabName;
            
            try
            {
                reader = cmd.ExecuteReader();  
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Data + " " + ex.InnerException + " "+ex.Message);
            }
            var rowcntr = 0;
            while (reader.Read())
            {

                query.Cols.ForEach(col =>
                {
                    tableInfo.SetVal(col, Convert.ToString(reader[col]), rowcntr);
                });
                rowcntr++;
            }

            cmd.Dispose();
            reader.Close();
            _connection.Close();
            return tableInfo;
        }
    }
}
