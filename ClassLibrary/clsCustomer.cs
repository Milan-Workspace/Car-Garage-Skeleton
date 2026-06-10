using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsCustomer
    {
            private Int32 mCustomerID;
            private string mFirstName;
            private string mLastName;
            private string mEmail;
            private string mPhone;
            private DateTime mDateRegistered;
            private Boolean mIsActive;

            public int CustomerID
            {
                get { return mCustomerID; }
                set { mCustomerID = value; }
            }

            public string FirstName
            {
                get { return mFirstName; }
                set { mFirstName = value; }
            }

            public string LastName
            {
                get { return mLastName; }
                set { mLastName = value; }
            }

            public string Email
            {
                get { return mEmail; }
                set { mEmail = value; }
            }

            public string Phone
            {
                get { return mPhone; }
                set { mPhone = value; }
            }

            public DateTime DateRegistered
            {
                get { return mDateRegistered; }
                set { mDateRegistered = value; }
            }

            public bool IsActive
            {
                get { return mIsActive; }
                set { mIsActive = value; }
            }

        public bool Find(int customerID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("sproc_tbl_CustomerSelectByID", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    conn.Open();
                    System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        mCustomerID = Convert.ToInt32(reader["CustomerID"]);
                        mFirstName = reader["FirstName"].ToString();
                        mLastName = reader["LastName"].ToString();
                        mEmail = reader["Email"].ToString();
                        mPhone = reader["PhoneNumber"].ToString();
                        mDateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                        mIsActive = Convert.ToBoolean(reader["isActive"]);
                        return true;
                    }
                    return false;
                }
            }
        }

        public string Valid(string firstName, string lastName,
                              string email, string phone)
            {
                string Error = "";

                if (firstName.Length == 0)
                    Error += "First name may not be blank. ";
                if (firstName.Length > 50)
                    Error += "First name must be less than 50 chars. ";

                if (lastName.Length == 0)
                    Error += "Last name may not be blank. ";
                if (lastName.Length > 50)
                    Error += "Last name must be less than 50 chars. ";

                if (email.Length == 0)
                    Error += "Email may not be blank. ";
                if (email.Length > 100)
                    Error += "Email must be less than 100 chars. ";
                if (!email.Contains("@"))
                    Error += "Email must contain @. ";

                if (phone.Length == 0)
                    Error += "Phone may not be blank. ";
                if (phone.Length > 15)
                    Error += "Phone must be less than 15 chars. ";

                return Error;
            }
        }
}
