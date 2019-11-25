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
    public partial class Company_Master : System.Web.UI.Page
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

                Fetch_Company_Master();
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_Company_Name.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Company Name !!')", true);
            }
            else
            {
                try
                {

                    bool status = bal.Save_Company_Master(txt_Company_Code.Text, txt_Company_Name.Text, txt_Address_Line1.Text, txt_Address_Line2.Text, txt_City_Town.Text, txt_District.Text, txt_State.Text, txt_Pincode.Text, txt_Phone.Text,txt_Com_Gst_No.Text);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Saved Successfully !!')", true);
                }
                catch (Exception ex)
                {
                    lbl_Status.Text = ex.Message;
                }
            }
        }

        void Fetch_Company_Master()
        {
            bel.Branch_Code = txt_Company_Code.Text;
            bel.Branch_Code = bal.Fetch_Company_Master(bel).ToString();

            txt_Company_Name.Text = bel.Company_Name.ToString();
            txt_Address_Line1.Text = bel.Address_Line_1.ToString();
            txt_Address_Line2.Text = bel.Address_Line_2.ToString();
            txt_City_Town.Text = bel.Town_City.ToString();
            txt_District.Text = bel.District.ToString();
            txt_State.Text = bel.State.ToString();
            txt_Pincode.Text = bel.Pincode.ToString();
            txt_Phone.Text = bel.Contact_No_1.ToString();
            txt_Com_Gst_No.Text = bel.Gst_No.ToString();
        }

       

    }
}