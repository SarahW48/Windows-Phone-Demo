using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectUI
{
    public partial class Thankyou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(Session["istrue"].ToString());
            //Response.Write(Session["counter"].ToString());
            Response.Write("<style>body{background-image:url('http://www.etc.cmu.edu/projects/up-plus/background/thank_you.jpg');background-repeat:no-repeat;}</style>");
            Response.Write("<font size=\"10\" color=\"Blue\"><center>");
            if (Session["istrue"].ToString()=="True")
            {
                Response.Write("we made the right guess!");
            }
            else if (Session["istrue"].ToString() == "False")
            {
                Response.Write("we made the wrong guess");
            }
            Response.Write("</font></center>");

        }
    }
}