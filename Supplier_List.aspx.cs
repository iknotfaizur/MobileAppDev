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
    public partial class Supplier_List : System.Web.UI.Page
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

                Bind_Supplier_List();
            }
        }

        public void Bind_Supplier_List()
        {
            bel.Search = txt_Search.Text;
            GridView1.DataSource = bal.Bind_Supplier_Master(bel);
            GridView1.DataBind();
        }

        protected void btn_Go_Click(object sender, EventArgs e)
        {
            bel.Search = txt_Search.Text;
            GridView1.DataSource = bal.Bind_Supplier_Master(bel);
            GridView1.DataBind();
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Session["Supplier_Id"] = "";
            Response.Redirect("Supplier_Master.aspx");
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.Bind_Supplier_List();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Session["Supplier_Id"] = (row.FindControl("lbl_Supplier_Id") as Label).Text;
            Response.Redirect("Supplier_Master.aspx");
        }

    }
}