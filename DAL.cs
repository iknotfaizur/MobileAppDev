using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SMS
{
    public class DAL
    {
        //SQL Connection string

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        SqlCommand cmd;

        // LOGIN

        public int userlogin(string user, string passw)//checking the user name and password.If matched count 1 not 0.
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from Login_Details where Username='" + user + "'and Password='" + passw + "'", con);
                int a = Convert.ToInt32(cmd.ExecuteScalar());
                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public string userlog(string user, string passw)//getting the userType
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select User_Type from Login_Details where userName='" + user + "' and password='" + passw + "'", con);
                string a = cmd.ExecuteScalar().ToString();
                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }


        // SAVE COMPANY MASTER

        public bool Save_Company_Master(string Branch_Code, string Company_Name, string Address_Line_1, string Address_Line_2, string Com_City_Town, string Com_District, string Com_State, string Com_Pincode, string Com_Phone, string Com_Gst_No)
        {
            bool status = false;
            cmd = new SqlCommand("Save_Company_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Branch_Code", Branch_Code);
            cmd.Parameters.AddWithValue("@Company_Name", Company_Name);
            cmd.Parameters.AddWithValue("@Address_Line_1", Address_Line_1);
            cmd.Parameters.AddWithValue("@Address_Line_2", Address_Line_2);
            cmd.Parameters.AddWithValue("@Com_City_Town", Com_City_Town);
            cmd.Parameters.AddWithValue("@Com_District", Com_District);
            cmd.Parameters.AddWithValue("@Com_State", Com_State);
            cmd.Parameters.AddWithValue("@Com_Pincode", Com_Pincode);
            cmd.Parameters.AddWithValue("@Com_Phone", Com_Phone);
            cmd.Parameters.AddWithValue("@Com_Gst_No", Com_Gst_No);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }


        // FETCH COMPANY MASTER

        public DataSet Fetch_Company_Master(BEL be)
        {
            cmd = new SqlCommand("Fetch_Company_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Branch_Code", be.Branch_Code);
            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        be.Company_Name = (reader["Company_Name"].ToString());
                        be.Address_Line_1 = (reader["Address_Line_1"].ToString());
                        be.Address_Line_2 = (reader["Address_Line_2"].ToString());
                        be.Town_City = (reader["Com_City_Town"].ToString());
                        be.District = (reader["Com_District"].ToString());
                        be.State = (reader["Com_State"].ToString());
                        be.Pincode = (reader["Com_Pincode"].ToString());
                        be.Contact_No_1 = (reader["Com_Phone"].ToString());
                        be.Gst_No = (reader["Com_Gst_No"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        // CATEGORY MASTER

        // GET CATEGORY MASTER

        public DataTable Get_Category_Master()
        {
            cmd = new SqlCommand("Get_Category_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // SAVE CATEGORY MASTER

        public bool Save_Category_Master(BEL be)
        {
            bool status = false;
            cmd = new SqlCommand("Save_Category_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", be.Id);
            cmd.Parameters.AddWithValue("@Category", be.Category);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }

        // DELETE CATEGORY MASTER

        public void Delete_Category_Master(int id)
        {
            cmd = new SqlCommand("Delete_Category_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
        }

        // PRODUCT MASTER

        // GET PRODUCT CODE

        public DataSet Get_Product_Code(BEL be)
        {
            cmd = new SqlCommand("Get_Product_Code", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        be.Product_Code = (reader["Product_Code"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        // BIND CATEGORY NAME

        public DataTable Bind_Category_Name()
        {
            cmd = new SqlCommand("Select * from Category_Master", con);
            cmd.CommandType = CommandType.Text;
            DataTable dt = null;
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt = new DataTable("Category");
                    dt.Load(dr);
                    //status = true;  
                    return dt;
                }
            }
            finally
            {
                con.Close();
            }
            if (cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }
            return dt;
        }


        // BIND UNIT NAME

        public DataTable Bind_Unit_Name()
        {
            cmd = new SqlCommand("Select * from Unit_Master", con);
            cmd.CommandType = CommandType.Text;
            DataTable dt = null;
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt = new DataTable("Unit_Name");
                    dt.Load(dr);
                    //status = true;  
                    return dt;
                }
            }
            finally
            {
                con.Close();
            }
            if (cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }
            return dt;
        }

        // SAVE CATEGORY MASTER

        public bool Save_Product_Master(BEL be)
        {
            bool status = false;
            cmd = new SqlCommand("Save_Product_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Product_Code", be.Product_Code);
            cmd.Parameters.AddWithValue("@Product_Category", be.Product_Category);
            cmd.Parameters.AddWithValue("@Product_Name", be.Product_Name);
            cmd.Parameters.AddWithValue("@Purchase_Price", be.Purchase_Price);
            cmd.Parameters.AddWithValue("@Market_Price", be.Market_Price);
            cmd.Parameters.AddWithValue("@Sales_Price", be.Sales_Price);
            cmd.Parameters.AddWithValue("@Unit_Name", be.Unit_Name);
            cmd.Parameters.AddWithValue("@CGST_PER", be.CGST_PER);
            cmd.Parameters.AddWithValue("@SGST_PER", be.SGST_PER);
            cmd.Parameters.AddWithValue("@IGST_PER", be.IGST_PER);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }


        // BIND PRODUCT MASTER

        public DataTable Bind_Product_Master(BEL be)
        {
            cmd = new SqlCommand("Bind_Product_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", be.Search);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        // DELETE PRODUCT MASTER

        public void Delete_Product_Master(int Product_Code)
        {
            cmd = new SqlCommand("Delete_Product_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Product_Code", Product_Code);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
        }


        // GET UNIT MASTER

        public DataTable Bind_Unit_Master()
        {
            cmd = new SqlCommand("Bind_Unit_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        // DELETE UNIT MASTER

        public void Delete_Unit_Master(int id)
        {
            cmd = new SqlCommand("Delete_Unit_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
        }


        // SAVE UNIT MASTER

        public bool Save_Unit_Master(BEL be)
        {
            bool status = false;
            cmd = new SqlCommand("Save_Unit_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", be.Id);
            cmd.Parameters.AddWithValue("@Unit_Name", be.Unit_Name);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }


        // SUPPLIER MASTER

        // GET SUPPLIER ID

        public DataSet Get_Supplier_Id(BEL be)
        {
            cmd = new SqlCommand("Get_Supplier_Id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        be.Product_Code = (reader["Supplier_Id"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        // SAVE SUPPLIER MASTER

        public bool Save_Supplier_Master(BEL be)
        {
            bool status = false;
            cmd = new SqlCommand("Save_Supplier_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Supplier_Id", be.Supplier_Id);
            cmd.Parameters.AddWithValue("@Supplier_Name", be.Supplier_Name);
            cmd.Parameters.AddWithValue("@Address_Line_1", be.Address_Line_1);
            cmd.Parameters.AddWithValue("@Address_Line_2", be.Address_Line_2);
            cmd.Parameters.AddWithValue("@Town_City", be.Town_City);
            cmd.Parameters.AddWithValue("@District", be.District);
            cmd.Parameters.AddWithValue("@State", be.State);
            cmd.Parameters.AddWithValue("@Pincode", be.Pincode);
            cmd.Parameters.AddWithValue("@Contact_Person", be.Contact_Person);
            cmd.Parameters.AddWithValue("@Contact_No_1", be.Contact_No_1);
            cmd.Parameters.AddWithValue("@Contact_No_2", be.Contact_No_2);
            cmd.Parameters.AddWithValue("@Email", be.Email);
            cmd.Parameters.AddWithValue("@Gst_No", be.Gst_No);
            cmd.Parameters.AddWithValue("@Remarks", be.Remarks);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }


        // BIND SUPPLIER MASTER

        public DataTable Bind_Supplier_Master(BEL be)
        {
            cmd = new SqlCommand("Bind_Supplier_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", be.Search);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        // FETCH SUPPLIER DETAILS

        public DataSet Fetch_Supplier_Details(BEL be)
        {
            cmd = new SqlCommand("Fetch_Supplier_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Supplier_Id", be.Supplier_Id);
            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        be.Supplier_Id = (reader["Supplier_Id"].ToString());
                        be.Supplier_Name = (reader["Supplier_Name"].ToString());
                        be.Address_Line_1 = (reader["Address_Line_1"].ToString());
                        be.Address_Line_2 = (reader["Address_Line_2"].ToString());
                        be.Town_City = (reader["Town_City"].ToString());
                        be.District = (reader["District"].ToString());
                        be.State = (reader["State"].ToString());
                        be.Pincode = (reader["Pincode"].ToString());
                        be.Contact_Person = (reader["Contact_Person"].ToString());
                        be.Contact_No_1 = (reader["Contact_No_1"].ToString());
                        be.Contact_No_2 = (reader["Contact_No_2"].ToString());
                        be.Email = (reader["Email"].ToString());
                        be.Gst_No = (reader["Gst_No"].ToString());
                        be.Remarks = (reader["Remarks"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        // DELETE SUPPLIER MASTER

        public void Delete_Supplier_Master(string Supplier_Id)
        {
            cmd = new SqlCommand("Delete_Supplier_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
        }

        // CUSTOMER MASTER

        // BIND CUSTOMER MASTER

        public DataTable Bind_Customer_Master(BEL be)
        {
            cmd = new SqlCommand("Bind_Customer_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", be.Search);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        // GET CUSTOMER ID

        public DataSet Get_Customer_Id(BEL be)
        {
            cmd = new SqlCommand("Get_Customer_Id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        be.Product_Code = (reader["Customer_Id"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        // SAVE CUSTOMER MASTER

        public bool Save_Customer_Master(BEL be)
        {
            bool status = false;
            cmd = new SqlCommand("Save_Customer_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Customer_Id", be.Customer_Id);
            cmd.Parameters.AddWithValue("@Customer_Name", be.Customer_Name);
            cmd.Parameters.AddWithValue("@Address_Line_1", be.Address_Line_1);
            cmd.Parameters.AddWithValue("@Address_Line_2", be.Address_Line_2);
            cmd.Parameters.AddWithValue("@Town_City", be.Town_City);
            cmd.Parameters.AddWithValue("@District", be.District);
            cmd.Parameters.AddWithValue("@State", be.State);
            cmd.Parameters.AddWithValue("@Pincode", be.Pincode);
            cmd.Parameters.AddWithValue("@Contact_Person", be.Contact_Person);
            cmd.Parameters.AddWithValue("@Contact_No_1", be.Contact_No_1);
            cmd.Parameters.AddWithValue("@Contact_No_2", be.Contact_No_2);
            cmd.Parameters.AddWithValue("@Email", be.Email);
            cmd.Parameters.AddWithValue("@Gst_No", be.Gst_No);
            cmd.Parameters.AddWithValue("@Remarks", be.Remarks);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }


        // FETCH CUSTOMER DETAILS

        public DataSet Fetch_Customer_Details(BEL be)
        {
            cmd = new SqlCommand("Fetch_Customer_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Customer_Id", be.Customer_Id);
            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        be.Customer_Id = (reader["Customer_Id"].ToString());
                        be.Customer_Name = (reader["Customer_Name"].ToString());
                        be.Address_Line_1 = (reader["Address_Line_1"].ToString());
                        be.Address_Line_2 = (reader["Address_Line_2"].ToString());
                        be.Town_City = (reader["Town_City"].ToString());
                        be.District = (reader["District"].ToString());
                        be.State = (reader["State"].ToString());
                        be.Pincode = (reader["Pincode"].ToString());
                        be.Contact_Person = (reader["Contact_Person"].ToString());
                        be.Contact_No_1 = (reader["Contact_No_1"].ToString());
                        be.Contact_No_2 = (reader["Contact_No_2"].ToString());
                        be.Email = (reader["Email"].ToString());
                        be.Gst_No = (reader["Gst_No"].ToString());
                        be.Remarks = (reader["Remarks"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        // DELETE CUSTOMER MASTER

        public void Delete_Customer_Master(string Customer_Id)
        {
            cmd = new SqlCommand("Delete_Customer_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Customer_Id", Customer_Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
        }


        // PURCHASE MASTER

        // GET PURCHASE INVOICE NO

        public DataSet Get_Purchase_Invoice_No(BEL be)
        {
            cmd = new SqlCommand("Get_Purchase_Invoice_No", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        be.Invoice_No = (reader["Invoice_No"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        // SAVE PURCHASE INVOICE

        public bool Save_Purchase_Invoice(BEL be)
        {
            bool status = false;
            cmd = new SqlCommand("Save_Purchase_Invoice", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Invoice_No", be.Invoice_No);
            cmd.Parameters.AddWithValue("@Invoice_Date", DateTime.ParseExact(be.Invoice_Date, "dd/MM/yyyy", null));
            cmd.Parameters.AddWithValue("@Supplier_Id", be.Supplier_Id);
            cmd.Parameters.AddWithValue("@Supplier_Name", be.Supplier_Name);
            cmd.Parameters.AddWithValue("@Scheme_Code", be.Scheme_Code);
            cmd.Parameters.AddWithValue("@Purchase_Value", be.Purchase_Value);
            cmd.Parameters.AddWithValue("@Addition", be.Addition);
            cmd.Parameters.AddWithValue("@Deduction", be.Deduction);
            cmd.Parameters.AddWithValue("@Grand_Total", be.Grand_Total);
            cmd.Parameters.AddWithValue("@Closing_Balance", be.Closing_Balance);
            cmd.Parameters.AddWithValue("@Transaction_Id", be.Transaction_Id);
            cmd.Parameters.AddWithValue("@Transaction_Date", DateTime.ParseExact(be.Transaction_Date, "dd/MM/yyyy", null));
            cmd.Parameters.AddWithValue("@Receipt_No", be.Receipt_No);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }


        // BIND PRODUCT DETAILS

        public DataSet Fetch_Product_Details(BEL be)
        {
            cmd = new SqlCommand("Fetch_Product_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", be.Product_Code);
            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            be.Product_Code = (reader["Product_Code"].ToString());
                            be.Product_Name = (reader["Product_Name"].ToString());
                            be.Unit_Name = (reader["Unit_Name"].ToString());
                            be.Sales_Price = (reader["Sales_Price"].ToString());
                            be.CGST_PER = (reader["CGST_PER"].ToString());
                            be.SGST_PER = (reader["SGST_PER"].ToString());
                            be.IGST_PER = (reader["IGST_PER"].ToString());
                        }
                    }
                    else
                    {
                        be.Product_Code = "";
                        be.Product_Name = "";
                        be.Unit_Name = "";
                        be.CGST_PER = "";
                        be.SGST_PER = "";
                        be.IGST_PER = "";
                    }
                }
            }
            finally
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        // SAVE PURCHASE DETAILS

        public bool Save_Purchase_Details(string Invoice_No,string Code, string Product_Name,string Unit_Name, string Quantity, string Rate, string Amount, string CGST_PER, string CGST_AMT, string SGST_PER, string SGST_AMT, string IGST_PER, string IGST_AMT)
        {
            bool status = false;
            cmd = new SqlCommand("Save_Purchase_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Invoice_No", Invoice_No);
            cmd.Parameters.AddWithValue("@Product_Code", Code);
            cmd.Parameters.AddWithValue("@Product_Name", Product_Name);
            cmd.Parameters.AddWithValue("@Unit_Name", Unit_Name);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Rate", Rate);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@CGST_PER", CGST_PER);
            cmd.Parameters.AddWithValue("@CGST_AMT", CGST_AMT);
            cmd.Parameters.AddWithValue("@SGST_PER", SGST_PER);
            cmd.Parameters.AddWithValue("@SGST_AMT", SGST_AMT);
            cmd.Parameters.AddWithValue("@IGST_PER", IGST_PER);
            cmd.Parameters.AddWithValue("@IGST_AMT", IGST_AMT);


            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }


        // SAVE DAILY TRANSACTION

        public bool Save_Daily_Transaction(string Transaction_Id, string Transaction_Date, string Account_No, string Transaction_Amount, string Transaction_Type, string Flag, string Transaction_Particulars, string Account_Desc, string Page_Source)
        {
            bool status = false;
            cmd = new SqlCommand("Save_Daily_Transaction", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Transaction_Id", Transaction_Id);
            cmd.Parameters.AddWithValue("@Transaction_Date", DateTime.ParseExact(Transaction_Date, "dd/MM/yyyy", null));
            cmd.Parameters.AddWithValue("@Account_No", Account_No);
            cmd.Parameters.AddWithValue("@Transaction_Amount", Transaction_Amount);
            cmd.Parameters.AddWithValue("@Transaction_Type", Transaction_Type);
            cmd.Parameters.AddWithValue("@Flag", Flag);
            cmd.Parameters.AddWithValue("@Transaction_Particulars", Transaction_Particulars);
            cmd.Parameters.AddWithValue("@Account_Desc", Account_Desc);
            cmd.Parameters.AddWithValue("@Page_Source", Page_Source);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }


        // SAVE CUS ACC LINK

        public bool Save_Cust_Acc_Link(string Account_No, string Sup_Cus_Id, string Sup_Cus_Name, string Account_Type)
        {
            bool status = false;
            cmd = new SqlCommand("Save_Cust_Acc_Link", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Account_No", Account_No);
            cmd.Parameters.AddWithValue("@Sup_Cus_Id", Sup_Cus_Id);
            cmd.Parameters.AddWithValue("@Sup_Cus_Name", Sup_Cus_Name);
            cmd.Parameters.AddWithValue("@Account_Type", Account_Type);
            
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }

        // UPDATE CLOSING BALANCE

        public bool Update_Closing_Balance(string Account_No)
        {
            bool status = false;
            cmd = new SqlCommand("Update_Closing_Balance", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Account_No", Account_No);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }


        // GET TRANSACTION ID

        public DataSet Get_Transaction_Id(string Transaction_Date)
        {
            cmd = new SqlCommand("Get_Transaction_Id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Transaction_Date", Transaction_Date);
            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Transaction_Id = (reader["Transaction_Id"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        // PURCHASE LIST

        // BIND PURCHASE LIST

        public DataTable Bind_Purchase_Master(BEL be)
        {
            cmd = new SqlCommand("Bind_Purchase_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", be.Search);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // FETCH PURCHASE MASTER

        public DataSet Fetch_Purchase_Master(BEL be)
        {
            cmd = new SqlCommand("Fetch_Purchase_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Invoice_No", be.Invoice_No);
            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        be.Invoice_No = (reader["Invoice_No"].ToString());
                        be.Invoice_Date = (reader["Invoice_Date"].ToString());
                        be.Supplier_Id = (reader["Supplier_Id"].ToString());
                        be.Supplier_Name = (reader["Supplier_Name"].ToString());
                        be.Scheme_Code = (reader["Scheme_Code"].ToString());
                        be.Purchase_Value = (reader["Purchase_Value"].ToString());
                        be.Addition = (reader["Addition"].ToString());
                        be.Deduction = (reader["Deduction"].ToString());
                        be.Grand_Total = (reader["Grand_Total"].ToString());
                        be.Closing_Balance = (reader["Closing_Balance"].ToString());
                        be.Transaction_Id = (reader["Transaction_Id"].ToString());
                        be.Transaction_Date = (reader["Transaction_Date"].ToString());
                        be.Receipt_No = (reader["Receipt_No"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        // FETCH PURCHASE DETAILS

        public DataTable Fetch_Purchase_Details(BEL be)
        {
            cmd = new SqlCommand("Fetch_Purchase_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Invoice_No", be.Invoice_No);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        // FETCH CALENDAR DATE

        public DataSet Fetch_Calendar_Date(BEL be)
        {
            cmd = new SqlCommand("Fetch_Calendar_Settings", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        be.Calendar_Date = (reader["Calendar_Dates"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        // SAVE CALENDAR SETTINGS

        public bool Save_Calendar_Settings(BEL be)
        {
            bool status = false;
            cmd = new SqlCommand("Save_Calendar_Settings", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Calendar_Date", DateTime.ParseExact(be.Calendar_Date, "dd/MM/yyyy", null));
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }


        // BIND PURCHASE BALANCE

        public DataTable Bind_Purchase_Balance(BEL be)
        {
            cmd = new SqlCommand("Bind_Purchase_Balance", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Account_No", be.Search);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // FETCH ACCOUNT TRANSACTIONS

        public DataTable Fetch_Account_Transactions(BEL be)
        {
            cmd = new SqlCommand("Fetch_Account_Transactions", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Account_No", be.@Account_No);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        // FETCH PURCHASE CLOSING BALANCE

        public DataSet Fetch_Purchase_Closing_Balance(BEL be)
        {
            //cmd = new SqlCommand("Fetch_Customer_Details", con);
            cmd = new SqlCommand("Select Closing_Balance from Purchase_Invoice where Invoice_No ='" + be.Account_No + "'", con);
            cmd.CommandType = CommandType.Text;
            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        be.Closing_Balance = (reader["Closing_Balance"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        // SALES MASTER

        // BIND PURCHASE LIST

        public DataTable Bind_Sales_Master(BEL be)
        {
            cmd = new SqlCommand("Bind_Sales_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", be.Search);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // GET SALES ACC NO

        public DataSet Get_Sales_Acc_No(BEL be)
        {
            cmd = new SqlCommand("Get_Sales_Acc_No", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        be.Account_No = (reader["Account_No"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        // GET SALES INVOICE NO

        public DataSet Get_Sales_Invoice_No(string Invoice_Date)
        {
            cmd = new SqlCommand("Get_Sales_Invoice_No", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Invoice_Date", Invoice_Date);
            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                         string Invoice_No = (reader["Invoice_No"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        // SAVE SALES INVOICE

        public bool Save_Sales_Invoice(BEL be)
        {
            bool status = false;
            cmd = new SqlCommand("Save_Sales_Invoice", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Invoice_No", be.Invoice_No);
            cmd.Parameters.AddWithValue("@Invoice_Date", DateTime.ParseExact(be.Invoice_Date, "dd/MM/yyyy", null));
            cmd.Parameters.AddWithValue("@Customer_Id", be.Supplier_Id);
            cmd.Parameters.AddWithValue("@Customer_Name", be.Supplier_Name);
            cmd.Parameters.AddWithValue("@Scheme_Code", be.Scheme_Code);
            cmd.Parameters.AddWithValue("@Sales_Value", be.Sales_Value);
            cmd.Parameters.AddWithValue("@Addition", be.Addition);
            cmd.Parameters.AddWithValue("@Deduction", be.Deduction);
            cmd.Parameters.AddWithValue("@Grand_Total", be.Grand_Total);
            cmd.Parameters.AddWithValue("@Closing_Balance", be.Closing_Balance);
            cmd.Parameters.AddWithValue("@Transaction_Id", be.Transaction_Id);
            cmd.Parameters.AddWithValue("@Transaction_Date", DateTime.ParseExact(be.Transaction_Date, "dd/MM/yyyy", null));
            cmd.Parameters.AddWithValue("@Account_No", be.Account_No);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }

        // SAVE SALES DETAILS

        public bool Save_Sales_Details(string Invoice_No,string Invoice_Date,string Account_No, string Code, string Product_Name, string Unit_Name, string Quantity, string Rate, string Amount, string CGST_PER, string CGST_AMT, string SGST_PER, string SGST_AMT, string IGST_PER, string IGST_AMT)
        {
            bool status = false;
            cmd = new SqlCommand("Save_Sales_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Invoice_No", Invoice_No);
            cmd.Parameters.AddWithValue("@Invoice_Date", Invoice_Date);
            cmd.Parameters.AddWithValue("@Account_No", Account_No);
            cmd.Parameters.AddWithValue("@Product_Code", Code);
            cmd.Parameters.AddWithValue("@Product_Name", Product_Name);
            cmd.Parameters.AddWithValue("@Unit_Name", Unit_Name);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Rate", Rate);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@CGST_PER", CGST_PER);
            cmd.Parameters.AddWithValue("@CGST_AMT", CGST_AMT);
            cmd.Parameters.AddWithValue("@SGST_PER", SGST_PER);
            cmd.Parameters.AddWithValue("@SGST_AMT", SGST_AMT);
            cmd.Parameters.AddWithValue("@IGST_PER", IGST_PER);
            cmd.Parameters.AddWithValue("@IGST_AMT", IGST_AMT);


            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }

        // BIND SALES BALANCE

        public DataTable Bind_Sales_Balance(BEL be)
        {
            cmd = new SqlCommand("Bind_Sales_Balance", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Account_No", be.Search);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // FETCH SALES CLOSING BALANCE

        public DataSet Fetch_Sales_Closing_Balance(BEL be)
        {
            cmd = new SqlCommand("Select Closing_Balance from Sales_Invoice where Account_No ='" + be.Account_No + "'", con);
            cmd.CommandType = CommandType.Text;
            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        be.Closing_Balance = (reader["Closing_Balance"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        // VOUCHER RECEIPT

        public DataTable Bind_GL_Master(BEL be)
        {
            cmd = new SqlCommand("Bind_GL_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@GL_Code", be.Search);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        // VIEW TRANSACTIONS

        public DataTable View_Transactions(BEL be)
        {
            cmd = new SqlCommand("View_Transactions", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@From_Date", DateTime.ParseExact(be.From_Date, "dd/MM/yyyy", null));
            cmd.Parameters.AddWithValue("@To_Date", DateTime.ParseExact(be.To_Date, "dd/MM/yyyy", null));
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        // FETCH GL TRANSACTIONS

        public DataTable Fetch_GL_Transactions(BEL be)
        {
            cmd = new SqlCommand("Fetch_GL_Transactions", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Transaction_Id", be.Transaction_Id);
            cmd.Parameters.AddWithValue("@Transaction_Date", be.Transaction_Date);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        // FETCH AC TRANSACTIONS

        public DataTable Fetch_AC_Transactions(BEL be)
        {
            cmd = new SqlCommand("Fetch_AC_Transactions", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Transaction_Id", be.Transaction_Id);
            cmd.Parameters.AddWithValue("@Transaction_Date", be.Transaction_Date);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // DELETE DAILY TRANSACTION

        public void Delete_Daily_Transaction(string Transaction_Id, string Transaction_Date)
        {
            cmd = new SqlCommand("Delete_Daily_Transaction", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Transaction_Id", Transaction_Id);
            cmd.Parameters.AddWithValue("@Transaction_Date", Transaction_Date);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
        }


        // FETCH ACCOUNT NO FOR DELETE TRANSACTION

        public DataSet Fetch_Account_No_Delete_Transaction(BEL be)
        {
            cmd = new SqlCommand("Select Isnull(Account_No,0) as Account_No from Daily_Transaction where Transaction_Id='" + be.Transaction_Id + "' and Transaction_Date='" + be.Transaction_Date + "' and Flag='AC' group by Account_No", con);
            cmd.CommandType = CommandType.Text;
            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        be.Account_No = (reader["Account_No"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        // FETCH GL MASTER

        public DataTable Fetch_GL_Master(BEL be)
        {
            cmd = new SqlCommand("Fetch_GL_Master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Search", be.Search);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // FETCH GL MASTER TRAN

        public DataTable Fetch_GL_Master_Tran(BEL be)
        {
            cmd = new SqlCommand("Fetch_GL_Master_Tran", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Account_No", be.Account_No);
            cmd.Parameters.AddWithValue("@From_Date", DateTime.ParseExact(be.From_Date, "dd/MM/yyyy", null));
            cmd.Parameters.AddWithValue("@To_Date", DateTime.ParseExact(be.To_Date, "dd/MM/yyyy", null));
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}