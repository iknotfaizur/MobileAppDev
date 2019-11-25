using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS
{
    public class BEL
    {

        private string _Id;

        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }


        private string _Search;

        public string Search
        {
            get
            {
                return _Search;
            }
            set
            {
                _Search = value;
            }
        }


        // COMPANY MASTER

        private string _Branch_Code;

        public string Branch_Code
        {
            get
            {
                return _Branch_Code;
            }
            set
            {
                _Branch_Code = value;
            }
        }

        private string _Company_Name;

        public string Company_Name
        {
            get
            {
                return _Company_Name;
            }
            set
            {
                _Company_Name = value;
            }
        }


        // UNIT MASTER


        private string _Unit_Name;

        public string Unit_Name
        {
            get
            {
                return _Unit_Name;
            }
            set
            {
                _Unit_Name = value;
            }
        }

        // CATEGORY MASTER


        private string _Category;

        public string Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
            }
        }


        // PRODUCT MASTER


        private string _Product_Code;

        public string Product_Code
        {
            get
            {
                return _Product_Code;
            }
            set
            {
                _Product_Code = value;
            }
        }

        private string _Product_Name;

        public string Product_Name
        {
            get
            {
                return _Product_Name;
            }
            set
            {
                _Product_Name = value;
            }
        }


        private string _Product_Category;

        public string Product_Category
        {
            get
            {
                return _Product_Category;
            }
            set
            {
                _Product_Category = value;
            }
        }


        private string _Purchase_Price;

        public string Purchase_Price
        {
            get
            {
                return _Purchase_Price;
            }
            set
            {
                _Purchase_Price = value;
            }
        }


        private string _Market_Price;

        public string Market_Price
        {
            get
            {
                return _Market_Price;
            }
            set
            {
                _Market_Price = value;
            }
        }


        private string _Sales_Price;

        public string Sales_Price
        {
            get
            {
                return _Sales_Price;
            }
            set
            {
                _Sales_Price = value;
            }
        }


        private string _CGST_PER;

        public string CGST_PER
        {
            get
            {
                return _CGST_PER;
            }
            set
            {
                _CGST_PER = value;
            }
        }


        private string _SGST_PER;

        public string SGST_PER
        {
            get
            {
                return _SGST_PER;
            }
            set
            {
                _SGST_PER = value;
            }
        }


        private string _IGST_PER;

        public string IGST_PER
        {
            get
            {
                return _IGST_PER;
            }
            set
            {
                _IGST_PER = value;
            }
        }


        // SUPPLIER MASTER

        private string _Supplier_Id;

        public string Supplier_Id
        {
            get
            {
                return _Supplier_Id;
            }
            set
            {
                _Supplier_Id = value;
            }
        }

        private string _Supplier_Name;

        public string Supplier_Name
        {
            get
            {
                return _Supplier_Name;
            }
            set
            {
                _Supplier_Name = value;
            }
        }

        private string _Address_Line_1;

        public string Address_Line_1
        {
            get
            {
                return _Address_Line_1;
            }
            set
            {
                _Address_Line_1 = value;
            }
        }

        private string _Address_Line_2;

        public string Address_Line_2
        {
            get
            {
                return _Address_Line_2;
            }
            set
            {
                _Address_Line_2 = value;
            }
        }

        private string _Town_City;

        public string Town_City
        {
            get
            {
                return _Town_City;
            }
            set
            {
                _Town_City = value;
            }
        }

        private string _District;

        public string District
        {
            get
            {
                return _District;
            }
            set
            {
                _District = value;
            }
        }

        private string _State;

        public string State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
            }
        }

        private string _Pincode;

        public string Pincode
        {
            get
            {
                return _Pincode;
            }
            set
            {
                _Pincode = value;
            }
        }

        private string _Contact_Person;

        public string Contact_Person
        {
            get
            {
                return _Contact_Person;
            }
            set
            {
                _Contact_Person = value;
            }
        }

        private string _Contact_No_1;

        public string Contact_No_1
        {
            get
            {
                return _Contact_No_1;
            }
            set
            {
                _Contact_No_1 = value;
            }
        }

        private string _Contact_No_2;

        public string Contact_No_2
        {
            get
            {
                return _Contact_No_2;
            }
            set
            {
                _Contact_No_2 = value;
            }
        }

        private string _Email;

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        private string _Gst_No;

        public string Gst_No
        {
            get
            {
                return _Gst_No;
            }
            set
            {
                _Gst_No = value;
            }
        }

        private string _Remarks;

        public string Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {
                _Remarks = value;
            }
        }

        // CUSTOMER MASTER


        private string _Customer_Id;

        public string Customer_Id
        {
            get
            {
                return _Customer_Id;
            }
            set
            {
                _Customer_Id = value;
            }
        }

        private string _Customer_Name;

        public string Customer_Name
        {
            get
            {
                return _Customer_Name;
            }
            set
            {
                _Customer_Name = value;
            }
        }

        // PURCHASE MASTER

        private string _Invoice_No;

        public string Invoice_No
        {
            get
            {
                return _Invoice_No;
            }
            set
            {
                _Invoice_No = value;
            }
        }

        private string _Invoice_Date;

        public string Invoice_Date
        {
            get
            {
                return _Invoice_Date;
            }
            set
            {
                _Invoice_Date = value;
            }
        }

        private string _Scheme_Code;

        public string Scheme_Code
        {
            get
            {
                return _Scheme_Code;
            }
            set
            {
                _Scheme_Code = value;
            }
        }

        private string _Purchase_Value;

        public string Purchase_Value
        {
            get
            {
                return _Purchase_Value;
            }
            set
            {
                _Purchase_Value = value;
            }
        }

        private string _Addition;

        public string Addition
        {
            get
            {
                return _Addition;
            }
            set
            {
                _Addition = value;
            }
        }

        private string _Deduction;

        public string Deduction
        {
            get
            {
                return _Deduction;
            }
            set
            {
                _Deduction = value;
            }
        }

        private string _Grand_Total;

        public string Grand_Total
        {
            get
            {
                return _Grand_Total;
            }
            set
            {
                _Grand_Total = value;
            }
        }

        private string _Closing_Balance;

        public string Closing_Balance
        {
            get
            {
                return _Closing_Balance;
            }
            set
            {
                _Closing_Balance = value;
            }
        }

        private string _Account_Status;

        public string Account_Status
        {
            get
            {
                return _Account_Status;
            }
            set
            {
                _Account_Status = value;
            }
        }

        private string _Transaction_Id;

        public string Transaction_Id
        {
            get
            {
                return _Transaction_Id;
            }
            set
            {
                _Transaction_Id = value;
            }
        }

        private string _Transaction_Date;

        public string Transaction_Date
        {
            get
            {
                return _Transaction_Date;
            }
            set
            {
                _Transaction_Date = value;
            }
        }


        private string _Receipt_No;

        public string Receipt_No
        {
            get
            {
                return _Receipt_No;
            }
            set
            {
                _Receipt_No = value;
            }
        }


        // PURCHASE DETAILS

        private string _Quantity;

        public string Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
            }
        }


        private string _Rate;

        public string Rate
        {
            get
            {
                return _Rate;
            }
            set
            {
                _Rate = value;
            }
        }


        private string _Amount;

        public string Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
            }
        }


        private string _CGST_AMT;

        public string CGST_AMT
        {
            get
            {
                return _CGST_AMT;
            }
            set
            {
                _CGST_AMT = value;
            }
        }


        private string _SGST_AMT;

        public string SGST_AMT
        {
            get
            {
                return _SGST_AMT;
            }
            set
            {
                _SGST_AMT = value;
            }
        }


        private string _IGST_AMT;

        public string IGST_AMT
        {
            get
            {
                return _IGST_AMT;
            }
            set
            {
                _IGST_AMT = value;
            }
        }

        // DAILY TRANSACTION

        private string _Account_No;

        public string Account_No
        {
            get
            {
                return _Account_No;
            }
            set
            {
                _Account_No = value;
            }
        }

        private string _Transaction_Amount;

        public string Transaction_Amount
        {
            get
            {
                return _Transaction_Amount;
            }
            set
            {
                _Transaction_Amount = value;
            }
        }

        private string _Transaction_Type;

        public string Transaction_Type
        {
            get
            {
                return _Transaction_Type;
            }
            set
            {
                _Transaction_Type = value;
            }
        }

        private string _Flag;

        public string Flag
        {
            get
            {
                return _Flag;
            }
            set
            {
                _Flag = value;
            }
        }

        private string _Transaction_Particulars;

        public string Transaction_Particulars
        {
            get
            {
                return _Transaction_Particulars;
            }
            set
            {
                _Transaction_Particulars = value;
            }
        }

        private string _Account_Desc;

        public string Account_Desc
        {
            get
            {
                return _Account_Desc;
            }
            set
            {
                _Account_Desc = value;
            }
        }


        // CUST ACC LINK

        private string _Sup_Cus_Id;

        public string Sup_Cus_Id
        {
            get
            {
                return _Sup_Cus_Id;
            }
            set
            {
                _Sup_Cus_Id = value;
            }
        }

        private string _Sup_Cus_Name;

        public string Sup_Cus_Name
        {
            get
            {
                return _Sup_Cus_Name;
            }
            set
            {
                _Sup_Cus_Name = value;
            }
        }

        private string _Account_Type;

        public string Account_Type
        {
            get
            {
                return _Account_Type;
            }
            set
            {
                _Account_Type = value;
            }
        }

        // CALENDAR DATE

        private string _Calendar_Date;

        public string Calendar_Date
        {
            get
            {
                return _Calendar_Date;
            }
            set
            {
                _Calendar_Date = value;
            }
        }

        // SALES MASTER

        private string _Sales_Value;

        public string Sales_Value
        {
            get
            {
                return _Sales_Value;
            }
            set
            {
                _Sales_Value = value;
            }
        }

        // VIEW TRANSACTIONS

        private string _From_Date;

        public string From_Date
        {
            get
            {
                return _From_Date;
            }
            set
            {
                _From_Date = value;
            }
        }


        private string _To_Date;

        public string To_Date
        {
            get
            {
                return _To_Date;
            }
            set
            {
                _To_Date = value;
            }
        }
    }
}