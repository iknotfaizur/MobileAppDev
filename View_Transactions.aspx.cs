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
    public partial class View_Transactions : System.Web.UI.Page
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

                txt_From_Date.Text = txt_To_Date.Text = Session["Current_Date"].ToString();
                View_Transactions_List();
            }
        }

        public void View_Transactions_List()
        {
            bel.From_Date = txt_From_Date.Text;
            bel.To_Date = txt_To_Date.Text;
            GridView1.DataSource = bal.View_Transactions(bel);
            GridView1.DataBind();
        }

        protected void btn_Go_Click(object sender, EventArgs e)
        {
            if (txt_From_Date.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter From Date!!')", true);
            }
            else if (txt_To_Date.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter To Date!!')", true);
            }
            else
            {
                bel.From_Date = txt_From_Date.Text;
                bel.To_Date = txt_To_Date.Text;
                GridView1.DataSource = bal.View_Transactions(bel);
                GridView1.DataBind();
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.View_Transactions_List();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            hd_Tran_Id.Value = bel.Transaction_Id = (row.FindControl("lbl_Tran_Id") as Label).Text;
            hd_Tran_Date.Value = bel.Transaction_Date = (row.FindControl("lbl_Tran_Date") as Label).Text;
            GridView2.DataSource = bal.Fetch_GL_Transactions(bel);
            GridView2.DataBind();

            GridView3.DataSource = bal.Fetch_AC_Transactions(bel);
            GridView3.DataBind();
            mp1.Show();
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                bel.Transaction_Id = hd_Tran_Id.Value;
                bel.Transaction_Date = hd_Tran_Date.Value;
                bal.Fetch_Account_No_Delete_Transaction(bel).ToString();
                hd_Account_No.Value = bel.Account_No.ToString();

                bal.Delete_Daily_Transaction(hd_Tran_Id.Value, hd_Tran_Date.Value);
                mp1.Hide();
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Transactions Deleted Successfully!!')", true);
                View_Transactions_List();

                bool status1 = bal.Update_Closing_Balance(hd_Account_No.Value);

                hd_Tran_Id.Value = "";
                hd_Tran_Date.Value = "";
                hd_Account_No.Value = "";

            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You Clicked No!!')", true);
            }
        }

       

    }
}