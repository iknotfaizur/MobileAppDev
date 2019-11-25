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
    public partial class Purchase_Bal_Payment : System.Web.UI.Page
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
            Bind_Purchase_Balance();
            mp1.Show();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.Bind_Purchase_Balance();
            mp1.Show();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            txt_Account_No.Text = (row.FindControl("lbl_Invoice_No") as Label).Text;
            txt_Invoice_Date.Text = (row.FindControl("lbl_Invoice_Date") as Label).Text;
            txt_Receipt_No.Text = (row.FindControl("lbl_Receipt_No") as Label).Text;
            txt_Supplier_Id.Text = (row.FindControl("lbl_Supplier_Id") as Label).Text;
            txt_Supplier_Name.Text = (row.FindControl("lbl_Supplier_Name") as Label).Text;
            txt_Closing_Balance.Text = (row.FindControl("lbl_Closing_Balance") as Label).Text;
            mp1.Hide();
            SetFocus(txt_Transaction_Amount);
            Fill_Account_Transactions();
        }

        public void Bind_Purchase_Balance()
        {
            bel.Search = txt_Account_No.Text;
            GridView1.DataSource = bal.Bind_Purchase_Balance(bel);
            GridView1.DataBind();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_Transaction_Amount.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Transaction Amount!!')", true);
                SetFocus(txt_Transaction_Amount);
            }
            else if (txt_Supplier_Id.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Choose Account!!')", true);
                SetFocus(txt_Transaction_Amount);
            }
            else
            {
                try
                {
                    string Cr = "Credit";
                    string Dr = "Debit";
                    string Transaction_Particulars = "Purchase Balance Payment" + " - " + txt_Account_No.Text + " - " + txt_Supplier_Name.Text + " - Rs " + txt_Transaction_Amount.Text;
                   
                    // Purchase Head

                    bool status1 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, "29002", txt_Transaction_Amount.Text, Dr, "GL", Transaction_Particulars, txt_Narration.Text, "PB");

                    // Purchase Amount Payable

                    bool status2 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, "29000", txt_Transaction_Amount.Text, Cr, "GL", Transaction_Particulars, txt_Narration.Text, "PB");

                    // Individual Account

                    // Debit

                    bool status3 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, txt_Account_No.Text, txt_Transaction_Amount.Text, Dr, "AC", Transaction_Particulars, txt_Narration.Text, "PB");

                    // Supplier Account

                    // Credit

                    bool status4 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, txt_Supplier_Id.Text, txt_Transaction_Amount.Text, Cr, "IAC", Transaction_Particulars, txt_Narration.Text, "PB");

                    bool status5 = bal.Update_Closing_Balance(txt_Account_No.Text);

                    SetFocus(txt_Transaction_Amount);

                    txt_Transaction_Amount.Text = "";
                    txt_Narration.Text = "";

                    Fill_Account_Transactions();

                    txt_Transaction_Id.Text = bal.Get_Transaction_Id(txt_Transaction_Date.Text).Tables[0].Rows[0][0].ToString();

                    Fetch_Purchase_Closing_Balance();
                   
                }
                catch (Exception ex)
                {
                    lbl_Status.Text = ex.Message;
                }
            }
        }


        public void Fill_Account_Transactions()
        {
            bel.Account_No = txt_Account_No.Text;
            DataTable dt = bal.Fetch_Account_Transactions(bel);
            GridView2.DataSource = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];

                decimal credit = 0, debit = 0, previousBalance = 0;
                decimal.TryParse(row["Credit"].ToString(), out credit);
                decimal.TryParse(row["Debit"].ToString(), out debit);

                if (i > 0)
                    decimal.TryParse(dt.Rows[i - 1]["Balance"].ToString(), out previousBalance);

                row["Balance"] = i == 0 ? credit - debit : previousBalance - credit - debit;
            }
            GridView2.DataBind();
        }

        void Fetch_Purchase_Closing_Balance()
        {
            bel.Account_No = txt_Account_No.Text;
            bel.Account_No = bal.Fetch_Purchase_Closing_Balance(bel).ToString();
            txt_Closing_Balance.Text = bel.Closing_Balance.ToString();
        }

        protected void GridView2_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.Fill_Account_Transactions();
        }
    }
}