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
    public partial class General_Ledger : System.Web.UI.Page
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
            }
        }

        void Fetch_GL_Master()
        {
            GridViewRow row = GridView1.SelectedRow;
            bel.Search = txt_GL_Code.Text;
            GridView2.DataSource = bal.Fetch_GL_Master(bel);
            GridView2.DataBind();
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Fetch_GL_Master();
            mp1.Show();
        }

        protected void GridView2_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.Fetch_GL_Master();
        }

        protected void GridView2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            txt_GL_Code.Text = (row.FindControl("lbl_GL_Code") as Label).Text;
            txt_GL_Name.Text = (row.FindControl("lbl_GL_Name") as Label).Text;
        }

        public void View_GL_Master_Tran()
        {
            bel.Account_No = txt_GL_Code.Text;
            bel.From_Date = txt_From_Date.Text;
            bel.To_Date = txt_To_Date.Text;
            GridView1.DataSource = bal.Fetch_GL_Master_Tran(bel);
            GridView1.DataBind();
        }

        protected void btn_Go_Click(object sender, EventArgs e)
        {
            if (txt_GL_Code.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Choose GL Account!!')", true);
            }
            else if (txt_From_Date.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter From Date!!')", true);
            }
            else if (txt_To_Date.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter To Date!!')", true);
            }
            else
            {
                View_GL_Master_Tran();
            }
        }

        protected void GridView1_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.View_GL_Master_Tran();
        }

        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Vithal" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView1.GridLines = GridLines.Both;
            GridView1.HeaderStyle.Font.Bold = true;
            GridView1.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

        protected void btn_Excel_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }  

    }
}