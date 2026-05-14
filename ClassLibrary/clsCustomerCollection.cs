using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
        public class clsCustomerCollection
        {
            List<clsCustomer> mCustomerList = new List<clsCustomer>();
            clsCustomer mThisCustomer = new clsCustomer();

            public List<clsCustomer> CustomerList
            {
                get { return mCustomerList; }
                set { mCustomerList = value; }
            }

            public int Count
            {
                get { return mCustomerList.Count; }
            }

            public clsCustomer ThisCustomer
            {
                get { return mThisCustomer; }
                set { mThisCustomer = value; }
            }

            public clsCustomerCollection()
            {
                PopulateFromDB("");
            }

            void PopulateFromDB(string lastNameFilter)
            {
                clsDataConnection DB = new clsDataConnection();
                 int count = 0;

                if (string.IsNullOrEmpty(lastNameFilter))
                    count = DB.Execute("sproc_tbl_CustomerSelectAll");
                else
                {
                    DB.AddParameter("@LastName", lastNameFilter);
                    count = DB.Execute("sproc_tbl_CustomerFilterByLastName");
                }

                mCustomerList.Clear();
                foreach (DataRow row in DB.DataTable.Rows)
                {
                    clsCustomer c = new clsCustomer();
                    c.CustomerID = Convert.ToInt32(row["CustomerID"]);
                    c.FirstName = Convert.ToString(row["FirstName"]);
                    c.LastName = Convert.ToString(row["LastName"]);
                    c.Email = Convert.ToString(row["Email"]);
                    c.Phone = Convert.ToString(row["Phone"]);
                    c.DateRegistered = Convert.ToDateTime(row["DateRegistered"]);
                    c.IsActive = Convert.ToBoolean(row["IsActive"]);
                    mCustomerList.Add(c);
                }
            }
        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            int count = 0;
            DB.AddParameter("@FirstName", mThisCustomer.FirstName);
            DB.AddParameter("@LastName", mThisCustomer.LastName);
            DB.AddParameter("@Email", mThisCustomer.Email);
            DB.AddParameter("@Phone", mThisCustomer.Phone);
            count = DB.Execute("sproc_tbl_CustomerAdd");
            return Convert.ToInt32(DB.DataTable.Rows[0]["CustomerID"]);
        }

        public void Update()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@CustomerID", mThisCustomer.CustomerID);
            DB.AddParameter("@FirstName", mThisCustomer.FirstName);
            DB.AddParameter("@LastName", mThisCustomer.LastName);
            DB.AddParameter("@Email", mThisCustomer.Email);
            DB.AddParameter("@Phone", mThisCustomer.Phone);
            DB.AddParameter("@IsActive", mThisCustomer.IsActive);
            DB.Execute("sproc_tbl_CustomerUpdate");
        }

        public void Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@CustomerID", mThisCustomer.CustomerID);
            DB.Execute("sproc_tbl_CustomerDelete");
        }

        public void ReportByLastName(string LastName)
        {
            PopulateFromDB(LastName);
        }
    }
}
