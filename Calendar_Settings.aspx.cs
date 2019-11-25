using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace SMS
{
    public partial class Calendar_Settings : System.Web.UI.Page
    {
        BEL bel = new BEL();
        BLL bal = new BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userName"] == null)
                {
                    Response.Redirect("Session_Expired.aspx");
                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_Software_Date.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Software Date !!')", true);
            }
            else
            {
                try
                {
                    bel.Calendar_Date = txt_Software_Date.Text;

                    bool status = bal.Save_Calendar_Settings(bel);

                    hd_Id.Value = txt_Software_Date.Text = "";

                    bal.Fetch_Calendar_Date(bel).ToString();

                    Session["Current_Date"] = bel.Calendar_Date.ToString();

                    Response.Redirect("Calendar_Settings.aspx");
                }
                catch (Exception ex)
                {
                    lbl_Status.Text = ex.Message;
                }
            }
        }


    }
}