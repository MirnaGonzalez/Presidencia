using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presidencia
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string strUserAgent = Request.UserAgent.ToString().ToLower();

            if (strUserAgent != null)
            {
                if (Request.Browser.IsMobileDevice == true && strUserAgent.Contains("windows"))
                {
                    imgBannerSup.ImageUrl = "~/images/CINTILLO-SUPERIOR.png";
                    imgBannerInf.ImageUrl = "~/images/CINTILLO-INFERIOR.png";
                }
                if (Request.Browser.IsMobileDevice == true && strUserAgent.Contains("iphone"))
                {
                    imgBannerSup.ImageUrl = "~/images/CINTILLO-SUPERIORIphone.png";
                    imgBannerInf.ImageUrl = "~/images/CINTILLO-INFERIORIphone.png";
                }
                if (Request.Browser.IsMobileDevice == true && strUserAgent.Contains("ipad"))
                {
                    imgBannerSup.ImageUrl = "~/images/CINTILLO-SUPERIORIpad.png";
                    imgBannerInf.ImageUrl = "~/images/CINTILLO-INFERIORIpad.png";
                }
                if (Request.Browser.IsMobileDevice == true && strUserAgent.Contains("android"))
                {
                    //   imgBannerSup.ImageUrl = "~/images/CINTILLO-SUPERIORAndroid.png";
                    //  imgBannerInf.ImageUrl = "~/images/CINTILLO-INFERIORAndroid.png";
                    imgBannerSup.ImageUrl = "~/images/CINTILLO-SUPERIORIphone.png";
                    imgBannerInf.ImageUrl = "~/images/CINTILLO-INFERIORIphone.png";
                }


            }
        }
    }
}