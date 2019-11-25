using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMS
{
    public partial class Full_Width : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_Current_Date.Text = Session["Current_Date"].ToString();
        }

        protected void btn_Logout_Click(object sender, EventArgs e)
        {
            Session["userName"] = "";
            Session.Abandon();
            Response.Redirect("Login_Page.aspx");
        }
    }
}