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
    public partial class Voucher_Receipt : System.Web.UI.Page
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

                txt_Transaction_Date.Text = Session["Current_Date"].ToString();
                txt_Transaction_Id.Text = bal.Get_Transaction_Id(txt_Transaction_Date.Text).Tables[0].Rows[0][0].ToString();
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Bind_GL_Master();
            mp1.Show();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.Bind_GL_Master();
            mp1.Show();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            txt_Credit_Code.Text = (row.FindControl("lbl_GL_Code") as Label).Text;
            txt_Credit_Acc_Name.Text = (row.FindControl("lbl_GL_Name") as Label).Text;
            mp1.Hide();
            SetFocus(txt_Transaction_Amount);
        }

        public void Bind_GL_Master()
        {
            bel.Search = txt_Credit_Code.Text;
            GridView1.DataSource = bal.Bind_GL_Master(bel);
            GridView1.DataBind();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_Transaction_Amount.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Transaction Amount!!')", true);
                SetFocus(txt_Transaction_Amount);
            }
            else if (txt_Credit_Acc_Name.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Choose Credit Account!!')", true);
                SetFocus(txt_Transaction_Amount);
            }
            else
            {
                try
                {
                    string Cr = "Credit";
                    string Dr = "Debit";
                    string Transaction_Particulars = "Voucher Receipt" + " - " + " Rs " + txt_Transaction_Amount.Text + " " + txt_Narration.Text;

                    // Debit Account

                    bool status1 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, txt_Debit_Code.Text, txt_Transaction_Amount.Text, Dr, "GL", Transaction_Particulars, txt_Narration.Text, "VR");

                    // Credit Account

                    bool status2 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, txt_Credit_Code.Text, txt_Transaction_Amount.Text, Cr, "GL", Transaction_Particulars, txt_Narration.Text, "VR");


                    SetFocus(txt_Transaction_Amount);

                    txt_Transaction_Amount.Text = "";
                    txt_Narration.Text = "";

                    txt_Transaction_Id.Text = bal.Get_Transaction_Id(txt_Transaction_Date.Text).Tables[0].Rows[0][0].ToString();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Voucher Receipt Saved Successfully !!')", true);

                }
                catch (Exception ex)
                {
                    lbl_Status.Text = ex.Message;
                }
            }
        }

        
    }
}