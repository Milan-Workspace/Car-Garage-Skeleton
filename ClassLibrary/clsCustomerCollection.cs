using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                if (string.IsNullOrEmpty(lastNameFilter))
                {
                    cmd = new SqlCommand("sproc_tbl_CustomerSelectAll", conn);
                }
                else
                {
                    cmd = new SqlCommand("sproc_tbl_CustomerFilterByLastName", conn);
                    cmd.Parameters.AddWithValue("@LastName", lastNameFilter);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                mCustomerList.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    clsCustomer c = new clsCustomer();
                    c.CustomerID = Convert.ToInt32(row["CustomerID"]);
                    c.FirstName = Convert.ToString(row["FirstName"]);
                    c.LastName = Convert.ToString(row["LastName"]);
                    c.Email = Convert.ToString(row["Email"]);
                    c.Phone = Convert.ToString(row["PhoneNumber"]);
                    c.DateRegistered = Convert.ToDateTime(row["DateRegistered"]);
                    c.IsActive = Convert.ToBoolean(row["isActive"]);
                    mCustomerList.Add(c);
                }
            }
        }

        public void Add()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sproc_tbl_CustomerAdd", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", mThisCustomer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", mThisCustomer.LastName);
                    cmd.Parameters.AddWithValue("@Email", mThisCustomer.Email);
                    cmd.Parameters.AddWithValue("@Phone", mThisCustomer.Phone);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sproc_tbl_CustomerUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", mThisCustomer.CustomerID);
                    cmd.Parameters.AddWithValue("@FirstName", mThisCustomer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", mThisCustomer.LastName);
                    cmd.Parameters.AddWithValue("@Email", mThisCustomer.Email);
                    cmd.Parameters.AddWithValue("@Phone", mThisCustomer.Phone);
                    cmd.Parameters.AddWithValue("@IsActive", mThisCustomer.IsActive);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sproc_tbl_CustomerDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", mThisCustomer.CustomerID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ReportByLastName(string LastName)
        {
            PopulateFromDB(LastName);
        }
    }
}