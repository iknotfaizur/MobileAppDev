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
    public partial class Supplier_Master : System.Web.UI.Page
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

                if (Session["Supplier_Id"].ToString() != "")
                {
                    txt_Supplier_Id.Text = Session["Supplier_Id"].ToString();
                    Fetch_Supplier_Details();
                }
                else
                {
                    txt_Supplier_Id.Text = bal.Get_Supplier_Id(bel).Tables[0].Rows[0][0].ToString();
                }

                
            }
        }


        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_Supplier_Name.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Supplier Name!!')", true);
            }
            else if (txt_Contact_No1.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Contact No!!')", true);
            }
            else
            {
                try
                {
                    bel.Supplier_Id = txt_Supplier_Id.Text;
                    bel.Supplier_Name = txt_Supplier_Name.Text;
                    bel.Address_Line_1 = txt_Address_Line1.Text;
                    bel.Address_Line_2 = txt_Address_Line2.Text;
                    bel.Town_City = txt_City_Town.Text;
                    bel.District = txt_District.Text;
                    bel.State = txt_State.Text;
                    bel.Pincode = txt_Pincode.Text;
                    bel.Contact_Person = txt_Contact_Person.Text;
                    bel.Contact_No_1 = txt_Contact_No1.Text;
                    bel.Contact_No_2 = txt_Contact_No2.Text;
                    bel.Email = txt_Email.Text;
                    bel.Gst_No = txt_Gst_Tin_No.Text;
                    bel.Remarks =  txt_Remarks.Text;

                    bool status = bal.Save_Supplier_Master(bel);

                    txt_Supplier_Id.Text = bal.Get_Supplier_Id(bel).Tables[0].Rows[0][0].ToString();
                    Response.Redirect("Supplier_List.aspx");
                }
                catch (Exception ex)
                {
                    lbl_Status.Text = ex.Message;
                }
            }
        }


        void Fetch_Supplier_Details()
        {
            bel.Supplier_Id = txt_Supplier_Id.Text;
            bel.Supplier_Id = bal.Fetch_Supplier_Details(bel).ToString();

            txt_Supplier_Name.Text = bel.Supplier_Name.ToString();
            txt_Address_Line1.Text = bel.Address_Line_1.ToString();
            txt_Address_Line2.Text = bel.Address_Line_2.ToString();
            txt_City_Town.Text = bel.Town_City.ToString();
            txt_District.Text = bel.District.ToString();
            txt_State.Text = bel.State.ToString();
            txt_Pincode.Text = bel.Pincode.ToString();
            txt_Contact_Person.Text = bel.Contact_Person.ToString();
            txt_Contact_No1.Text = bel.Contact_No_1.ToString();
            txt_Contact_No2.Text = bel.Contact_No_2.ToString();
            txt_Email.Text = bel.Email.ToString();
            txt_Gst_Tin_No.Text = bel.Gst_No.ToString();
            txt_Remarks.Text = bel.Remarks.ToString();
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                bal.Delete_Supplier_Master(txt_Supplier_Id.Text);
                Response.Redirect("Supplier_List.aspx");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You Clicked No!!')", true);
            }
        }

    }
}