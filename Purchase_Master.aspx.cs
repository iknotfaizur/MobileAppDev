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
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;

namespace SMS
{
    public partial class Purchase_Master : System.Web.UI.Page
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

                if (Session["Account_No"] != null)
                {
                    txt_Invoice_No.Text = Session["Account_No"].ToString();
                    lbl_Current_Date.Text = Session["Current_Date"].ToString();
                    Fetch_Purchase_Details();
                }
                else
                {
                    DateTime dateTime = DateTime.UtcNow.Date;
                    txt_Invoice_No.Text = bal.Get_Purchase_Invoice_No(bel).Tables[0].Rows[0][0].ToString();
                    lbl_Current_Date.Text = txt_Transaction_Date.Text = txt_Invoice_Date.Text = Session["Current_Date"].ToString();
                    txt_Transaction_Id.Text = bal.Get_Transaction_Id(txt_Transaction_Date.Text).Tables[0].Rows[0][0].ToString();
                }

                    DataTable dt = new DataTable();
                    dt.Columns.AddRange(new DataColumn[12] { new DataColumn("Code"), new DataColumn("Product_Name"), new DataColumn("Unit_Name"), new DataColumn("Quantity"), new DataColumn("Rate"), new DataColumn("Amount"), new DataColumn("CGST_PER"), new DataColumn("CGST_AMT"), new DataColumn("SGST_PER"), new DataColumn("SGST_AMT"), new DataColumn("IGST_PER"), new DataColumn("IGST_AMT") });
                    Session["Product_Details"] = dt;
                    this.BindGrid();
            }
        }

        public void Bind_Supplier_List()
        {
            bel.Search = txt_Supplier_Name.Text;
            GridView1.DataSource = bal.Bind_Supplier_Master(bel);
            GridView1.DataBind();
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Bind_Supplier_List();
            mp1.Show();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.Bind_Supplier_List();
            mp1.Show();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            txt_Supplier_Id.Text = (row.FindControl("lbl_Supplier_Id") as Label).Text;
            txt_Supplier_Name.Text = (row.FindControl("lbl_Supplier_Name") as Label).Text;
            mp1.Hide();
            SetFocus(txt_Product_Code);
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_Supplier_Id.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Choose Supplier Name!!')", true);
                SetFocus(txt_Supplier_Id);
            }
            else if (txt_Supplier_Name.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Choose Supplier Name!!')", true);
                SetFocus(txt_Supplier_Name);
            }
            else if (Convert.ToDecimal(txt_Purchase_Value.Text) <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Purchase Product!!')", true);
                SetFocus(txt_Product_Code);
            }
            else if (txt_Addition.Text == "")
            {
                txt_Addition.Text = "0.00";
            }
            else if (txt_Deduction.Text == "")
            {
                txt_Deduction.Text = "0.00";
            }
            else
            {
                try
                {

                    bel.Invoice_No = txt_Invoice_No.Text;
                    bel.Invoice_Date = txt_Invoice_Date.Text;
                    bel.Supplier_Id = txt_Supplier_Id.Text;
                    bel.Supplier_Name = txt_Supplier_Name.Text;
                    bel.Scheme_Code = hd_Scheme_Code.Value;
                    bel.Purchase_Value = txt_Purchase_Value.Text;
                    bel.Addition = txt_Addition.Text;
                    bel.Deduction = txt_Deduction.Text;
                    bel.Grand_Total = txt_Grand_Total.Text;
                    bel.Closing_Balance = txt_Closing_Balance.Text;
                    bel.Transaction_Id = txt_Transaction_Id.Text;
                    bel.Transaction_Date = txt_Invoice_Date.Text;
                    bel.Receipt_No = txt_Receipt_No.Text;
                    
                    // Save Purchase Invoice

                    bool status1 = bal.Save_Purchase_Invoice(bel);

                    for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
                    {
                        string Code = GridView2.Rows[i].Cells[1].Text;
                        string Product_Name = GridView2.Rows[i].Cells[2].Text;
                        string Unit_Name = GridView2.Rows[i].Cells[3].Text;
                        string Quantity = GridView2.Rows[i].Cells[4].Text;
                        string Rate = GridView2.Rows[i].Cells[5].Text;
                        string Amount = GridView2.Rows[i].Cells[6].Text;
                        string CGST_PER = GridView2.Rows[i].Cells[7].Text;
                        string CGST_AMT = GridView2.Rows[i].Cells[8].Text;
                        string SGST_PER = GridView2.Rows[i].Cells[9].Text;
                        string SGST_AMT = GridView2.Rows[i].Cells[10].Text;
                        string IGST_PER = GridView2.Rows[i].Cells[11].Text;
                        string IGST_AMT = GridView2.Rows[i].Cells[12].Text;

                        // Save Purchase Details

                        bool status2 = bal.Save_Purchase_Details(txt_Invoice_No.Text, Code, Product_Name, Unit_Name, Quantity, Rate, Amount, CGST_PER, CGST_AMT, SGST_PER, SGST_AMT, IGST_PER, IGST_AMT);
                    }

                    string Cr = "Credit";
                    string Dr = "Debit";
                    string Transaction_Particulars = "Purchase Invoice" + " - " + txt_Invoice_No.Text + " - " + txt_Supplier_Name.Text + " - Rs " + txt_Grand_Total.Text;

                    if (ddl_Payment_Mode.Text == "Cash")
                    {

                        // Purchase Head

                        bool status3 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, "29001", txt_Purchase_Value.Text, Dr, "GL", Transaction_Particulars, txt_Narration.Text,"PM");

                        // Cash Head

                        bool status4 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, "29000", txt_Grand_Total.Text, Cr, "GL", Transaction_Particulars, txt_Narration.Text,"PM");

                    }
                    else
                    {
                        // Purchase Head

                        bool status5 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, "29001", txt_Purchase_Value.Text, Dr, "GL", Transaction_Particulars, txt_Narration.Text,"PM");

                        // Purchase Amount Payable

                        bool status6 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, "29002", txt_Grand_Total.Text, Cr, "GL", Transaction_Particulars, txt_Narration.Text, "PM");

                    }


                    // Purchase Addition

                    bool status10 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, "29003", txt_Addition.Text, Dr, "GL", Transaction_Particulars, txt_Narration.Text, "PM");

                    // Purchase Deduction

                    bool status11 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, "29004", txt_Deduction.Text, Cr, "GL", Transaction_Particulars, txt_Narration.Text, "PM");


                    DataTable dt2 = (DataTable)Session["Product_Details"];

                    decimal CGST_AMT2 = dt2.AsEnumerable().Sum(x => Convert.ToDecimal(x["CGST_AMT"]));
                    decimal SGST_AMT2 = dt2.AsEnumerable().Sum(x => Convert.ToDecimal(x["SGST_AMT"]));
                    decimal IGST_AMT2 = dt2.AsEnumerable().Sum(x => Convert.ToDecimal(x["IGST_AMT"]));

                    // CGST Taxable

                    bool status7 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, "40001", CGST_AMT2.ToString(), Dr, "GL", Transaction_Particulars, txt_Narration.Text, "PM");

                    // SGST Taxable

                    bool status8 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, "40002", SGST_AMT2.ToString(), Dr, "GL", Transaction_Particulars, txt_Narration.Text, "PM");

                    // IGST Taxable

                    bool status9 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, "40003", IGST_AMT2.ToString(), Dr, "GL", Transaction_Particulars, txt_Narration.Text, "PM");


                    // Individual Account

                    if (ddl_Payment_Mode.Text == "Cash")
                    {
                        // Credit

                        bool status12 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, txt_Invoice_No.Text, txt_Grand_Total.Text, Cr, "AC", Transaction_Particulars, txt_Narration.Text, "PM");

                        // Debit

                        bool status13 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, txt_Invoice_No.Text, txt_Grand_Total.Text, Dr, "AC", Transaction_Particulars, txt_Narration.Text, "PM");

                        // Supplier Account
                        
                        // Credit

                        bool status14 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, txt_Supplier_Id.Text, txt_Grand_Total.Text, Cr, "IAC", Transaction_Particulars, txt_Narration.Text, "PM");

                        // Debit

                        bool status15 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, txt_Supplier_Id.Text, txt_Grand_Total.Text, Dr, "IAC", Transaction_Particulars, txt_Narration.Text, "PM");
                    
                    }
                    else
                    {
                        // Credit

                        bool status16 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, txt_Invoice_No.Text, txt_Grand_Total.Text, Cr, "AC", Transaction_Particulars, txt_Narration.Text, "PM");

                        // Supplier Account

                        // Debit

                        bool status17 = bal.Save_Daily_Transaction(txt_Transaction_Id.Text, txt_Transaction_Date.Text, txt_Supplier_Id.Text, txt_Grand_Total.Text, Dr, "IAC", Transaction_Particulars, txt_Narration.Text, "PM");

                    }

                    // Save Cust Acc Link

                    bool status18 = bal.Save_Cust_Acc_Link(txt_Invoice_No.Text,txt_Supplier_Id.Text,txt_Supplier_Name.Text,"Purchase");

                    // Update Closing Balance

                    bool status19 = bal.Update_Closing_Balance(txt_Invoice_No.Text);

                    txt_Invoice_No.Text = bal.Get_Purchase_Invoice_No(bel).Tables[0].Rows[0][0].ToString();
                    bal.Get_Transaction_Id(txt_Transaction_Date.Text).Tables[0].Rows[0][0].ToString();
                    Response.Redirect("Purchase_Master.aspx");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Saved Successfully!!')", true);
                }
                catch (Exception ex)
                {
                    lbl_Status.Text = ex.Message;
                }
            }
        }

        protected void txt_Product_Code_Change(object sender, EventArgs e)
        {
            if (txt_Supplier_Id.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Choose Supplier!!')", true);
                SetFocus(txt_Supplier_Name);
                txt_Product_Code.Text = "";
            }
            else
            {
                Fetch_Product_Details();
            }
        }

        void Fetch_Product_Details()
        {
            bel.Product_Code = txt_Product_Code.Text;
            bel.Product_Code = bal.Fetch_Product_Details(bel).ToString();
            if (bel.Product_Name != "")
            {
                txt_Product_Name.Text = bel.Product_Name.ToString();
                txt_Unit_Name.Text = bel.Unit_Name.ToString();
                txt_CGST_PER.Text = bel.CGST_PER.ToString();
                txt_SGST_PER.Text = bel.SGST_PER.ToString();
                txt_IGST_PER.Text = bel.IGST_PER.ToString();
                SetFocus(txt_Quantity);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Product Not Available!!')", true);
                txt_Product_Code.Text = "";
                SetFocus(txt_Product_Code);
            }
        }

        protected void txt_Quantity_Change(object sender, EventArgs e)
        {
            if (txt_Product_Code.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Product!!')", true);
                txt_Quantity.Text = "";
                SetFocus(txt_Product_Code);
            }
            else if (txt_Product_Name.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Product!!')", true);
                txt_Quantity.Text = "";
                SetFocus(txt_Product_Code);
            }
            else if (txt_Quantity.Text == "" && txt_Quantity.Text == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Valid Quantity!!')", true);
                SetFocus(txt_Quantity);
            }
            else
            {
                SetFocus(txt_Rate);
            }
        }

        protected void txt_Rate_Change(object sender, EventArgs e)
        {
            if (txt_Product_Code.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Product!!')", true);
                txt_Rate.Text = "";
                SetFocus(txt_Product_Code);
            }
            else if (txt_Product_Name.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Product!!')", true);
                txt_Rate.Text = "";
                SetFocus(txt_Product_Code);
            }
            else if (txt_Rate.Text == "" && txt_Rate.Text == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Purchase Rate!!')", true);
                txt_Rate.Text = "";
                SetFocus(txt_Product_Code);
            }
            else
            {
                if (!string.IsNullOrEmpty(txt_Quantity.Text) && !string.IsNullOrEmpty(txt_Rate.Text))
                    txt_Amount.Text = (Convert.ToDecimal(txt_Quantity.Text) * Convert.ToDecimal(txt_Rate.Text)).ToString();

                if (chk_Tax.Checked)
                {
                    txt_CGST_AMT.Text = (Convert.ToDecimal(txt_CGST_PER.Text) * Convert.ToDecimal(txt_Amount.Text) / 100).ToString();
                    txt_SGST_AMT.Text = (Convert.ToDecimal(txt_SGST_PER.Text) * Convert.ToDecimal(txt_Amount.Text) / 100).ToString();
                    txt_IGST_AMT.Text = (Convert.ToDecimal(txt_IGST_PER.Text) * Convert.ToDecimal(txt_Amount.Text) / 100).ToString();
                }
                else
                {
                    txt_CGST_PER.Text = "0";
                    txt_SGST_PER.Text = "0";
                    txt_IGST_PER.Text = "0";

                    txt_CGST_AMT.Text = "0";
                    txt_SGST_AMT.Text = "0";
                    txt_IGST_AMT.Text = "0";
                }

                Insert();
                SetFocus(txt_Product_Code);
            }
        }

        protected void BindGrid()
        {
            GridView2.DataSource = (DataTable)Session["Product_Details"];
            GridView2.DataBind();
        }

        void Insert()
        {
            DataTable dt = (DataTable)Session["Product_Details"];
            dt.Rows.Add(txt_Product_Code.Text.Trim(), txt_Product_Name.Text.Trim(), txt_Unit_Name.Text.Trim(),txt_Quantity.Text.Trim(), txt_Rate.Text.Trim(),txt_Amount.Text.Trim(),txt_CGST_PER.Text.Trim(),txt_CGST_AMT.Text.Trim(),txt_SGST_PER.Text.Trim(),txt_SGST_AMT.Text.Trim(),txt_IGST_PER.Text.Trim(),txt_IGST_AMT.Text.Trim());
            Session["Product_Details"] = dt;
            this.BindGrid();

            txt_Product_Code.Text = string.Empty;
            txt_Product_Name.Text = string.Empty;
            txt_Unit_Name.Text = string.Empty;
            txt_Quantity.Text = string.Empty;
            txt_Rate.Text = string.Empty;
            txt_Amount.Text = string.Empty;
            txt_CGST_PER.Text = string.Empty;
            txt_CGST_AMT.Text = string.Empty;
            txt_SGST_PER.Text = string.Empty;
            txt_SGST_AMT.Text = string.Empty;
            txt_IGST_PER.Text = string.Empty;
            txt_IGST_AMT.Text = string.Empty;
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt1 = (DataTable)Session["Product_Details"];
            if (dt1.Rows.Count > 0)
            {
                dt1.Rows[e.RowIndex].Delete();
                GridView2.DataSource = dt1;
                GridView2.DataBind();
            }

            DataTable dt = (DataTable)Session["Product_Details"];

            txt_Purchase_Value.Text = dt.AsEnumerable().Sum(x => Convert.ToDecimal(x["Amount"])).ToString("N");

            decimal CGST_AMT = dt.AsEnumerable().Sum(x => Convert.ToDecimal(x["CGST_AMT"]));
            decimal SGST_AMT = dt.AsEnumerable().Sum(x => Convert.ToDecimal(x["SGST_AMT"]));
            decimal IGST_AMT = dt.AsEnumerable().Sum(x => Convert.ToDecimal(x["IGST_AMT"]));

            txt_Total_Tax.Text = (CGST_AMT + SGST_AMT + IGST_AMT).ToString("N");

            if (!string.IsNullOrEmpty(txt_Purchase_Value.Text) && !string.IsNullOrEmpty(txt_Total_Tax.Text) && !string.IsNullOrEmpty(txt_Addition.Text) && !string.IsNullOrEmpty(txt_Deduction.Text) && !string.IsNullOrEmpty(txt_Grand_Total.Text))

            lbl_Balance.Text = txt_Closing_Balance.Text = txt_Grand_Total.Text = (Convert.ToDecimal(txt_Purchase_Value.Text) + Convert.ToDecimal(txt_Total_Tax.Text) + Convert.ToDecimal(txt_Addition.Text) - Convert.ToDecimal(txt_Deduction.Text)).ToString("N");

            SetFocus(txt_Product_Code);
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = (DataTable)Session["Product_Details"];

            txt_Purchase_Value.Text = dt.AsEnumerable().Sum(x => Convert.ToDecimal(x["Amount"])).ToString("N");

            decimal CGST_AMT = dt.AsEnumerable().Sum(x => Convert.ToDecimal(x["CGST_AMT"]));
            decimal SGST_AMT = dt.AsEnumerable().Sum(x => Convert.ToDecimal(x["SGST_AMT"]));
            decimal IGST_AMT = dt.AsEnumerable().Sum(x => Convert.ToDecimal(x["IGST_AMT"]));

            txt_Total_Tax.Text = (CGST_AMT + SGST_AMT + IGST_AMT).ToString("N");

            if (!string.IsNullOrEmpty(txt_Purchase_Value.Text) && !string.IsNullOrEmpty(txt_Total_Tax.Text) && !string.IsNullOrEmpty(txt_Addition.Text) && !string.IsNullOrEmpty(txt_Deduction.Text) && !string.IsNullOrEmpty(txt_Grand_Total.Text))

                lbl_Balance.Text = txt_Closing_Balance.Text = txt_Grand_Total.Text = (Convert.ToDecimal(txt_Purchase_Value.Text) + Convert.ToDecimal(txt_Total_Tax.Text) + Convert.ToDecimal(txt_Addition.Text) - Convert.ToDecimal(txt_Deduction.Text)).ToString("N");
        }

        protected void txt_Grand_Total_Change(object sender, EventArgs e)
        {
           if (!string.IsNullOrEmpty(txt_Purchase_Value.Text) && !string.IsNullOrEmpty(txt_Total_Tax.Text) && !string.IsNullOrEmpty(txt_Addition.Text) && !string.IsNullOrEmpty(txt_Deduction.Text) && !string.IsNullOrEmpty(txt_Grand_Total.Text))

           txt_Grand_Total.Text = (Convert.ToDecimal(txt_Purchase_Value.Text) + Convert.ToDecimal(txt_Total_Tax.Text) + Convert.ToDecimal(txt_Addition.Text) - Convert.ToDecimal(txt_Deduction.Text)).ToString("N");

           lbl_Balance.Text = txt_Closing_Balance.Text = (Convert.ToDecimal(txt_Grand_Total.Text)).ToString("N");
        }

        protected void txt_Addition_Change(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Purchase_Value.Text) && !string.IsNullOrEmpty(txt_Total_Tax.Text) && !string.IsNullOrEmpty(txt_Addition.Text) && !string.IsNullOrEmpty(txt_Deduction.Text) && !string.IsNullOrEmpty(txt_Grand_Total.Text))

                txt_Grand_Total.Text = (Convert.ToDecimal(txt_Purchase_Value.Text) + Convert.ToDecimal(txt_Total_Tax.Text) + Convert.ToDecimal(txt_Addition.Text) - Convert.ToDecimal(txt_Deduction.Text)).ToString("N");

            lbl_Balance.Text = txt_Closing_Balance.Text = (Convert.ToDecimal(txt_Grand_Total.Text)).ToString("N");
        }

        protected void txt_Deduction_Change(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Purchase_Value.Text) && !string.IsNullOrEmpty(txt_Total_Tax.Text) && !string.IsNullOrEmpty(txt_Addition.Text) && !string.IsNullOrEmpty(txt_Deduction.Text) && !string.IsNullOrEmpty(txt_Grand_Total.Text))

                txt_Grand_Total.Text = (Convert.ToDecimal(txt_Purchase_Value.Text) + Convert.ToDecimal(txt_Total_Tax.Text) + Convert.ToDecimal(txt_Addition.Text) - Convert.ToDecimal(txt_Deduction.Text)).ToString("N");

            lbl_Balance.Text = txt_Closing_Balance.Text = (Convert.ToDecimal(txt_Grand_Total.Text)).ToString("N");
        }

        protected void btn_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Purchase_List.aspx");
        }

        void Fetch_Purchase_Details()
        {
            bel.Invoice_No = txt_Invoice_No.Text;
            bel.Invoice_No = bal.Fetch_Purchase_Master(bel).ToString();

            txt_Invoice_Date.Text = Convert.ToDateTime(bel.Invoice_Date).ToString("dd/MM/yyyy");
            txt_Supplier_Id.Text = bel.Supplier_Id;
            txt_Supplier_Name.Text = bel.Supplier_Name ;
            hd_Scheme_Code.Value = bel.Scheme_Code;
            txt_Purchase_Value.Text = bel.Purchase_Value;
            txt_Addition.Text = bel.Addition ;
            txt_Deduction.Text = bel.Deduction;
            txt_Grand_Total.Text = bel.Grand_Total;
            txt_Closing_Balance.Text = bel.Closing_Balance;
            txt_Transaction_Id.Text = bel.Transaction_Id;
            txt_Transaction_Date.Text = Convert.ToDateTime(bel.Transaction_Date).ToString("dd/MM/yyyy");
            txt_Receipt_No.Text = bel.Receipt_No;

            //bel.Invoice_No = bal.Fetch_Purchase_Details(bel).ToString();

            //bel.Invoice_No = txt_Invoice_No.Text;
            //GridView2.DataSource = bal.Fetch_Purchase_Details(bel);
            //GridView2.DataBind();
        }


    }
}