using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMS
{
    public partial class Purchase_Sales_Menu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null)
            {
                Response.Redirect("Session_Expired.aspx");
            }

            lbl_Current_Date.Text = Session["Current_Date"].ToString();
        }

        protected void btn_Logout_Click(object sender, EventArgs e)
        {
            Session["userName"] = "";
            Session.Abandon();
            Response.Redirect("Login_New.aspx");
        }
    }
}