using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presidencia
{
    public partial class ReservaAuditorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string javaScript = "myFunction();";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);

            string strUserAgent = Request.UserAgent.ToString().ToLower();

            if (strUserAgent != null)
            {
                if (Request.Browser.IsMobileDevice == true || strUserAgent.Contains("iphone") ||
                strUserAgent.Contains("blackberry") || strUserAgent.Contains("mobile") ||
                strUserAgent.Contains("windows ce") || strUserAgent.Contains("opera mini") ||
                strUserAgent.Contains("palm"))
                {
                    //Response.Redirect("http://www.m.tuweb.com/");
    
                } 
            }
            }
    }
}