using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Pizza : Refeicao
    {
        public const String INSERT = "INSERT INTO TB_REFEICAO ([descricao],[valor]) VALUES('{0}', {1})";
        public const String SELECT = "SELECT id, descricao, valor FROM TB_REFEICAO";
    }
}
