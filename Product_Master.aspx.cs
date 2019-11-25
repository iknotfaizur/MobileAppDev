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
    public partial class Product_Master : System.Web.UI.Page
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

                txt_Product_Code.Text = bal.Get_Product_Code(bel).Tables[0].Rows[0][0].ToString();
                Bind_Category();
                Bind_Unit_Name();
                Bind_Product_Master();

            }
        }

        public void Bind_Category()
        {
            DataTable dtState = bal.Bind_Category_Name();
            ddl_Category.DataSource = dtState;
            ddl_Category.DataTextField = "Category";
            ddl_Category.DataValueField = "Category";
            ddl_Category.DataBind();
        }

        public void Bind_Unit_Name()
        {
            DataTable dtState = bal.Bind_Unit_Name();
            ddl_Unit_Name.DataSource = dtState;
            ddl_Unit_Name.DataTextField = "Unit_Name";
            ddl_Unit_Name.DataValueField = "Unit_Name";
            ddl_Unit_Name.DataBind();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_Product_Name.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Product Name!!')", true);
            }
            else if (txt_Purchase_Price.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Purchase Price!!')", true);
            }
            else if (txt_Market_Price.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Market Price!!')", true);
            }
            else if (txt_Sales_Price.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Sales Price!!')", true);
            }
            else
            {
                try
                {
                    bel.Product_Code = txt_Product_Code.Text;
                    bel.Product_Category = ddl_Category.Text;
                    bel.Product_Name = txt_Product_Name.Text;
                    bel.Purchase_Price = txt_Purchase_Price.Text;
                    bel.Market_Price = txt_Market_Price.Text;
                    bel.Sales_Price = txt_Sales_Price.Text;
                    bel.Unit_Name = ddl_Unit_Name.Text;
                    bel.CGST_PER = txt_CGST_PER.Text;
                    bel.SGST_PER = txt_SGST_PER.Text;
                    bel.IGST_PER = txt_IGST_PER.Text;

                    bool status = bal.Save_Product_Master(bel);

                    txt_Product_Code.Text = bal.Get_Product_Code(bel).Tables[0].Rows[0][0].ToString();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Saved Successfully !!')", true);
                    Bind_Product_Master();
                    Clear();
                }
                catch (Exception ex)
                {
                    lbl_Status.Text = ex.Message;
                }
            }
        }

        void Clear()
        {
            txt_Product_Name.Text = "";
            txt_Purchase_Price.Text = "0.00";
            txt_Market_Price.Text = "0.00";
            txt_Sales_Price.Text = "0.00";
            txt_CGST_PER.Text = "0";
            txt_SGST_PER.Text = "0";
            txt_IGST_PER.Text = "0";
        }


        public void Bind_Product_Master()
        {
            bel.Search = txt_Search.Text;
            GridView1.DataSource = bal.Bind_Product_Master(bel);
            GridView1.DataBind();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            hd_Id.Value = (row.FindControl("lbl_Id") as Label).Text;
            txt_Product_Code.Text = (row.FindControl("lbl_Product_Code") as Label).Text;
            ddl_Category.Text = (row.FindControl("lbl_Category") as Label).Text;
            txt_Product_Name.Text = (row.FindControl("lbl_Product_Name") as Label).Text;
            ddl_Unit_Name.Text = (row.FindControl("lbl_Unit") as Label).Text;
            txt_Purchase_Price.Text = (row.FindControl("lbl_Purchase_Price") as Label).Text;
            txt_Market_Price.Text = (row.FindControl("lbl_Market_Price") as Label).Text;
            txt_Sales_Price.Text = (row.FindControl("lbl_Sales_Price") as Label).Text;
            txt_CGST_PER.Text = (row.FindControl("lbl_CGST_PER") as Label).Text;
            txt_SGST_PER.Text = (row.FindControl("lbl_SGST_PER") as Label).Text;
            txt_IGST_PER.Text = (row.FindControl("lbl_IGST_PER") as Label).Text;
            lbl_Status.Text = "";
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Product_Code = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Values["Product_Code"].ToString());
            bal.Delete_Product_Master(Product_Code);
            Bind_Product_Master();
            txt_Product_Code.Text = bal.Get_Product_Code(bel).Tables[0].Rows[0][0].ToString();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted Successfully !!')", true);
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.Bind_Product_Master();
            lbl_Status.Text = "";
        }

        protected void txt_Search_Change(object sender, EventArgs e)
        {
            bel.Search = txt_Search.Text;
            GridView1.DataSource = bal.Bind_Product_Master(bel);
            GridView1.DataBind();
        }

       

    }
}