using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMS
{
    public partial class Login_New : System.Web.UI.Page
    {
        BEL bel = new BEL();
        BLL bal = new BLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string userName = txt_Username.Text;
            string password = txt_Password.Text;
            int a = bal.ballog(userName, password);
            txt_Username.Text = "";
            txt_Password.Text = "";
            if (a == 1)
            {
                Session["userName"] = userName;
                string type = bal.usertype(userName, password);
                Session["usertype"] = type;
                Fetch_Current_Date();
                Response.Redirect("Company_Master.aspx");
            }
            else if (a == 2)
            {
                Session["userName"] = userName;
                Fetch_Current_Date();
                Response.Redirect("Company_Master.aspx");
            }
            else
            {
                //lbl_Status.Text = "Invalid Username or Password";
            }
        }


        void Fetch_Current_Date()
        {
            bal.Fetch_Calendar_Date(bel).ToString();
            Session["Current_Date"] = bel.Calendar_Date.ToString();
        }
    }
}