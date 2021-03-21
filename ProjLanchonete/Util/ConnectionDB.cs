using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class ConnectionDB : IDisposable //é o responsável pela abertura da conexão com o Banco de Dados
    {
        private SqlConnection _conn;
        //private static ConnectionDB _instance;

        public ConnectionDB()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString);
            _conn.Open();
        }

        public bool ExecQuery(string query)
        {
            var cmd = new SqlCommand
            {
                CommandText = query,
                CommandType = CommandType.Text,
                Connection = _conn
            };
            return (cmd.ExecuteNonQuery() == 1) ? true : false;

        }

       /* public static ConnectionDB GetConnection()
        {
            if (_instance == null)
                _instance = new ConnectionDB();
            return _instance;
        }*/

        /*public void ExecQuery(string query)
        {
            var cmd = new SqlCommand
            {
                CommandText = query,
                CommandType = CommandType.Text,
                Connection = conn
            };
            cmd.ExecuteNonQuery();
        }*/

        public SqlDataReader ExecQueryReturn(string query)
        {
            var cmd = new SqlCommand(query, _conn);
            return cmd.ExecuteReader();
        }

        public void Dispose()
        {
            if (_conn.State == ConnectionState.Open)
            {
                _conn.Close();
                //_instance = null;
                _conn.Dispose();
            }
        }
    }
}
