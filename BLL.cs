using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SMS
{
    public class BLL
    {
        DAL da = new DAL();

        // LOGIN 

        public int ballog(string userid, string pass)//checking the usename and password
        {
            try
            {
                int a = da.userlogin(userid, pass);
                string b = da.userlog(userid, pass);
                if (a == 1 && (b == "Level1" || b == "Level2" || b == "Level3"))
                {
                    return 1;
                }
                else if (a == 1 && b == "admin")
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ec)
            {
                ec.GetType();
            }
            return 0;
        }

        public string usertype(string user, string pass)//checking the userType
        {
            try
            {
                return da.userlog(user, pass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // SAVE COMPANY MASTER

        public bool Save_Company_Master(string Branch_Code, string Company_Name, string Address_Line_1, string Address_Line_2, string Com_City_Town, string Com_District, string Com_State, string Com_Pincode, string Com_Phone, string Com_Gst_No)
        {
            bool status = false;
            da.Save_Company_Master(Branch_Code, Company_Name, Address_Line_1, Address_Line_2, Com_City_Town, Com_District, Com_State, Com_Pincode, Com_Phone, Com_Gst_No);
            return status;
        }

        // FETCH COMPANY MASTER

        public DataSet Fetch_Company_Master(BEL be)
        {
            return da.Fetch_Company_Master(be);
        }

        // CATEGORY MASTER

        // GET CATEGORY MASTER

        public DataTable Get_Category_Master()
        {
            return da.Get_Category_Master();
        }

        // SAVE CATEGORY MASTER

        public bool Save_Category_Master(BEL be)
        {
            bool status = false;
            da.Save_Category_Master(be);
            return status;
        }

        // DELETE CATEGORY MASTER

        public void Delete_Category_Master(int id)
        {
            da.Delete_Category_Master(id);
        }

        // PRODUCT MASTER

        // GET PRODUCT CODE

        public DataSet Get_Product_Code(BEL be)
        {
            return da.Get_Product_Code(be);
        }

        // BIND CATEGORY

        public DataTable Bind_Category_Name()
        {
            return da.Bind_Category_Name();
        }

        // BIND UNIT NAME

        public DataTable Bind_Unit_Name()
        {
            return da.Bind_Unit_Name();
        }

        // SAVE PRODUCT MASTER

        public bool Save_Product_Master(BEL be)
        {
            bool status = false;
            da.Save_Product_Master(be);
            return status;
        }

        // BIND PRODUCT MASTER

        public DataTable Bind_Product_Master(BEL be)
        {
            return da.Bind_Product_Master(be);
        }

        // DELETE PRODUCT MASTER

        public void Delete_Product_Master(int Product_Code)
        {
            da.Delete_Product_Master(Product_Code);
        }

        // UNIT MASTER

        // BIND UNIT MASTER

        public DataTable Bind_Unit_Master()
        {
            return da.Bind_Unit_Master();
        }

        // DELETE UNIT MASTER

        public void Delete_Unit_Master(int id)
        {
            da.Delete_Unit_Master(id);
        }

        // SAVE UNIT MASTER

        public bool Save_Unit_Master(BEL be)
        {
            bool status = false;
            da.Save_Unit_Master(be);
            return status;
        }

        // SUPPLIER MASTER

        // GET SUPPLIER ID

        public DataSet Get_Supplier_Id(BEL be)
        {
            return da.Get_Supplier_Id(be);
        }

        // SAVE PRODUCT MASTER

        public bool Save_Supplier_Master(BEL be)
        {
            bool status = false;
            da.Save_Supplier_Master(be);
            return status;
        }

        // BIND SUPPLIER LIST

        public DataTable Bind_Supplier_Master(BEL be)
        {
            return da.Bind_Supplier_Master(be);
        }

        // FETCH SUPPLIER DETAILS

        public DataSet Fetch_Supplier_Details(BEL be)
        {
            return da.Fetch_Supplier_Details(be);
        }

        // DELETE SUPPLIER MASTER

        public void Delete_Supplier_Master(string Supplier_Id)
        {
            da.Delete_Supplier_Master(Supplier_Id);
        }

        // CUSTOMER MASTER

        // BIND CUSTOMER LIST

        public DataTable Bind_Customer_Master(BEL be)
        {
            return da.Bind_Customer_Master(be);
        }

        // GET CUSTOMER ID

        public DataSet Get_Customer_Id(BEL be)
        {
            return da.Get_Customer_Id(be);
        }

        // SAVE CUSTOMER MASTER

        public bool Save_Customer_Master(BEL be)
        {
            bool status = false;
            da.Save_Customer_Master(be);
            return status;
        }

        // FETCH SUPPLIER DETAILS

        public DataSet Fetch_Customer_Details(BEL be)
        {
            return da.Fetch_Customer_Details(be);
        }

        // DELETE CUSTOMER MASTER

        public void Delete_Customer_Master(string Customer_Id)
        {
            da.Delete_Customer_Master(Customer_Id);
        }

        // PURCHASE MASTER

        // GET PURCHASE INVOICE NO

        public DataSet Get_Purchase_Invoice_No(BEL be)
        {
            return da.Get_Purchase_Invoice_No(be);
        }


        // SAVE PURCHASE INVOICE

        public bool Save_Purchase_Invoice(BEL be)
        {
            bool status = false;
            da.Save_Purchase_Invoice(be);
            return status;
        }

        // FETCH PRODUCT DETAILS

        public DataSet Fetch_Product_Details(BEL be)
        {
            return da.Fetch_Product_Details(be);
        }

        // SAVE PURCHASE DETAILS

        public bool Save_Purchase_Details(string Invoice_No,string Code, string Product_Name,string Unit_Name, string Quantity, string Rate, string Amount, string CGST_PER, string CGST_AMT, string SGST_PER, string SGST_AMT, string IGST_PER, string IGST_AMT)
        {
            bool status = false;
            da.Save_Purchase_Details(Invoice_No, Code, Product_Name, Unit_Name, Quantity, Rate, Amount, CGST_PER, CGST_AMT, SGST_PER, SGST_AMT, IGST_PER, IGST_AMT);
            return status;
        }

        // SAVE DAILY TRANSACTION

        public bool Save_Daily_Transaction(string Transaction_Id, string Transaction_Date, string Account_No, string Transaction_Amount, string Transaction_Type, string Flag, string Transaction_Particulars, string Account_Desc, string Page_Source)
        {
            bool status = false;
            da.Save_Daily_Transaction(Transaction_Id, Transaction_Date, Account_No, Transaction_Amount, Transaction_Type, Flag, Transaction_Particulars, Account_Desc, Page_Source);
            return status;
        }

        // SAVE CUS ACC LINK

        public bool Save_Cust_Acc_Link(string Account_No, string Sup_Cus_Id, string Sup_Cus_Name, string Account_Type)
        {
            bool status = false;
            da.Save_Cust_Acc_Link(Account_No, Sup_Cus_Id, Sup_Cus_Name, Account_Type);
            return status;
        }


        // UPDATE CLOSING BALANCE

        public bool Update_Closing_Balance(string Account_No)
        {
            bool status = false;
            da.Update_Closing_Balance(Account_No);
            return status;
        }

        // GET TRANSACTION ID

        public DataSet Get_Transaction_Id(string Transaction_Date)
        {
            return da.Get_Transaction_Id(Transaction_Date);
        }

        // PURCHASE LIST

        // BIND PURCHASE LIST

        public DataTable Bind_Purchase_Master(BEL be)
        {
            return da.Bind_Purchase_Master(be);
        }

        // FETCH PURCHASE MASTER

        public DataSet Fetch_Purchase_Master(BEL be)
        {
            return da.Fetch_Purchase_Master(be);
        }

        // FETCH PURCHASE DETAILS

        public DataTable Fetch_Purchase_Details(BEL be)
        {
            return da.Fetch_Purchase_Details(be);
        }

        // FETCH CALENDAR DATE

        public DataSet Fetch_Calendar_Date(BEL be)
        {
            return da.Fetch_Calendar_Date(be);
        }

        // SAVE CALENDAR SETTINGS

        public bool Save_Calendar_Settings(BEL be)
        {
            bool status = false;
            da.Save_Calendar_Settings(be);
            return status;
        }

        // BIND PURCHASE BALANCE

        public DataTable Bind_Purchase_Balance(BEL be)
        {
            return da.Bind_Purchase_Balance(be);
        }

        // FETCH ACCOUNT TRANSACTIONS

        public DataTable Fetch_Account_Transactions(BEL be)
        {
            return da.Fetch_Account_Transactions(be);
        }

        // FETCH PURCHASE CLOSING BALANCE

        public DataSet Fetch_Purchase_Closing_Balance(BEL be)
        {
            return da.Fetch_Purchase_Closing_Balance(be);
        }


        // SALES MASTER

        // BIND CUSTOMER LIST

        public DataTable Bind_Sales_Master(BEL be)
        {
            return da.Bind_Sales_Master(be);
        }

        // GET SALES ACC NO

        public DataSet Get_Sales_Acc_No(BEL be)
        {
            return da.Get_Sales_Acc_No(be);
        }

        // GET SALES INVOICE NO

        public DataSet Get_Sales_Invoice_No(string Invoice_Date)
        {
            return da.Get_Sales_Invoice_No(Invoice_Date);
        }

        // SAVE SALES INVOICE

        public bool Save_Sales_Invoice(BEL be)
        {
            bool status = false;
            da.Save_Sales_Invoice(be);
            return status;
        }

        // SAVE SALES DETAILS

        public bool Save_Sales_Details(string Invoice_No,string Invoice_Date,string Account_No, string Code, string Product_Name, string Unit_Name, string Quantity, string Rate, string Amount, string CGST_PER, string CGST_AMT, string SGST_PER, string SGST_AMT, string IGST_PER, string IGST_AMT)
        {
            bool status = false;
            da.Save_Sales_Details(Invoice_No, Invoice_Date, Account_No, Code, Product_Name, Unit_Name, Quantity, Rate, Amount, CGST_PER, CGST_AMT, SGST_PER, SGST_AMT, IGST_PER, IGST_AMT);
            return status;
        }


        // BIND SALES BALANCE

        public DataTable Bind_Sales_Balance(BEL be)
        {
            return da.Bind_Sales_Balance(be);
        }

        // FETCH SALES CLOSING BALANCE

        public DataSet Fetch_Sales_Closing_Balance(BEL be)
        {
            return da.Fetch_Sales_Closing_Balance(be);
        }

        // VOUCHER RECEIPT

        public DataTable Bind_GL_Master(BEL be)
        {
            return da.Bind_GL_Master(be);
        }

        // VIEW TRANSACTIONS

        public DataTable View_Transactions(BEL be)
        {
            return da.View_Transactions(be);
        }

        // FETCH GL TRANSACTIONS

        public DataTable Fetch_GL_Transactions(BEL be)
        {
            return da.Fetch_GL_Transactions(be);
        }

        // FETCH AC TRANSACTIONS

        public DataTable Fetch_AC_Transactions(BEL be)
        {
            return da.Fetch_AC_Transactions(be);
        }

        // DELETE DAILY TRANSACTION

        public void Delete_Daily_Transaction(string Transaction_Id,string Transaction_Date)
        {
            da.Delete_Daily_Transaction(Transaction_Id, Transaction_Date);
        }

        // FETCH ACCOUNT NO FOR DELETE TRANSACTION

        public DataSet Fetch_Account_No_Delete_Transaction(BEL be)
        {
            return da.Fetch_Account_No_Delete_Transaction(be);
        }

        // FETCH GL MASTER

        public DataTable Fetch_GL_Master(BEL be)
        {
            return da.Fetch_GL_Master(be);
        }

        // FETCH GL MASTER TRAN

        public DataTable Fetch_GL_Master_Tran(BEL be)
        {
            return da.Fetch_GL_Master_Tran(be);
        }
    }
}
