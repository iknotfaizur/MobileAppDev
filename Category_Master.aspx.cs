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
    public partial class Category_Master : System.Web.UI.Page
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

                Fill_Category_Details();

            }
        }


        public void Fill_Category_Details()
        {
            GridView1.DataSource = bal.Get_Category_Master();
            GridView1.DataBind();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            hd_Id.Value = (row.FindControl("lbl_Id") as Label).Text;
            txt_Category.Text = (row.FindControl("lbl_Category") as Label).Text;
            lbl_Status.Text = "";
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Values["Id"].ToString());
            bal.Delete_Category_Master(id);
            Fill_Category_Details();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted Successfully !!')", true);
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.Fill_Category_Details();
            lbl_Status.Text = "";
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_Category.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Category !!')", true);
            }
            else
            {
                try
                {
                    bel.Id = hd_Id.Value.ToString();
                    bel.Category = txt_Category.Text;

                    bool status = bal.Save_Category_Master(bel);

                    hd_Id.Value = txt_Category.Text = "";

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Saved Successfully !!')", true);

                    Fill_Category_Details();
                }
                catch (Exception ex)
                {
                    lbl_Status.Text = ex.Message;
                }
            }
        }

       

    }
}