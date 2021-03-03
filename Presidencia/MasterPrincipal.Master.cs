using Presidencia.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presidencia
{
    public partial class MasterPrincipal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuarios Usuario = Session["Usuario"] as Usuarios;
            if (Usuario != null)
            {
                if (!IsPostBack)
                {
                    Page.Session.Timeout = 180;
                }
            }
            else
            {

                Response.Redirect("AgendaLogin.aspx");
            }
        }

        protected void lbCerrarSesion_Click(object sender, EventArgs e)
        {
            Page.Session.Abandon();
            Response.Redirect("AgendaLogin.aspx");
        }
    }
}