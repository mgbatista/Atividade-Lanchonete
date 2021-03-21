using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using Model;
using System.Data.SqlClient;

namespace Data
{
    public class PizzaDB // tem a função de fazer comunicação direta com classe connection db pra fazer as inclusões etc.. no banco de dados
    {
        private ConnectionDB conn;

        public void Insert(Pizza pizza)
        {
            string sqlfinal = string.Format("INSERT INTO [dbo].[TB_REFEICAO] ([descricao],[valor]) VALUES('{0}', {1})", pizza.Descricao, pizza.Valor);

            using (conn = ConnectionDB.GetConnection())
            {
                conn.ExecQuery(sqlfinal);
            }
        }

        public void Delete(Pizza pizza)
        {
            string sqlfinal = string.Format("DELETE FROM [bdlanchonetesystem].[dbo].[TB_REFEICAO] WHERE [descricao] = '{0}' ", pizza.Descricao);

            using (conn = ConnectionDB.GetConnection())
            {
                conn.ExecQuery(sqlfinal);
            }
        }

        public List<Pizza> Select()
        {
            using (conn = ConnectionDB.GetConnection())
            {
                string sql = "SELECT id, descricao, valor FROM TB_REFEICAO";
                var returnData = conn.ExecQueryReturn(sql);
                return TransformSQLReaderToList(returnData);
            }
        }

        private List<Pizza> TransformSQLReaderToList (SqlDataReader returnData)
        {
            var list = new List<Pizza>();

            while (returnData.Read())
            {
                var item = new Pizza()
                {
                    Id = int.Parse(returnData["id"].ToString()),
                    Descricao = returnData["descricao"].ToString(),
                    Valor = returnData["valor"].ToString(),
                };

                list.Add(item);
            }
            return list;
        }
    }
}
