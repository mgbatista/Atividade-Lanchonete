using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjLanchonete
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GVPizza.DataSource = new PizzaDB().Select();
            GVPizza.DataBind();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            var pizza = new Pizza()
            {
                Descricao = txtDescricao.Text,
                Valor = txtvalor.Text
            };

            new PizzaDB().Insert(pizza);

            lblMSG.Text = "Pedido Enviado!";
            GVPizza.DataSource = new PizzaDB().Select();
            GVPizza.DataBind();

        }

        protected void btnexcluir_Click(object sender, EventArgs e)
        {
            var pizza = new Pizza()
            {
                Descricao = txtDescricao.Text,
            };

            new PizzaDB().Delete(pizza);

            lblMSG.Text = "Pedido Excluído!";
            GVPizza.DataSource = new PizzaDB().Select();
            GVPizza.DataBind();
        }
    }
}