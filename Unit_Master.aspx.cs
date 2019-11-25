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
    public partial class Unit_Master : System.Web.UI.Page
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

                Bind_Unit_Master();

            }
        }


        public void Bind_Unit_Master()
        {
            GridView1.DataSource = bal.Bind_Unit_Master();
            GridView1.DataBind();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            hd_Id.Value = (row.FindControl("lbl_Id") as Label).Text;
            txt_Unit_Name.Text = (row.FindControl("lbl_Unit_Name") as Label).Text;
            lbl_Status.Text = "";
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Values["Id"].ToString());
            bal.Delete_Unit_Master(id);
            Bind_Unit_Master();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted Successfully !!')", true);
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.Bind_Unit_Master();
            lbl_Status.Text = "";
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_Unit_Name.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Unit Name !!')", true);
            }
            else
            {
                try
                {
                    bel.Id = hd_Id.Value.ToString();
                    bel.Unit_Name = txt_Unit_Name.Text;

                    bool status = bal.Save_Unit_Master(bel);

                    hd_Id.Value = txt_Unit_Name.Text = "";

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Saved Successfully !!')", true);

                    Bind_Unit_Master();
                }
                catch (Exception ex)
                {
                    lbl_Status.Text = ex.Message;
                }
            }
        }

       

    }
}