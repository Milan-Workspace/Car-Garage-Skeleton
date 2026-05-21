using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class _1Viewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CustomerID"] != null)
                DisplayCustomer();
            else
                Response.Redirect("CustomerList.aspx");
        }
    }

    void DisplayCustomer()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("sproc_tbl_CustomerSelectByID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", Convert.ToInt32(Session["CustomerID"]));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblCustomerID.Text = reader["CustomerID"].ToString();
                    lblFirstName.Text = reader["FirstName"].ToString();
                    lblLastName.Text = reader["LastName"].ToString();
                    lblEmail.Text = reader["Email"].ToString();
                    lblPhone.Text = reader["PhoneNumber"].ToString();
                    lblDateRegistered.Text = Convert.ToDateTime(reader["DateRegistered"]).ToString("dd/MM/yyyy");
                    lblIsActive.Text = Convert.ToBoolean(reader["isActive"]) ? "Yes" : "No";
                }
            }
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerList.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerDataEntry.aspx");
    }
}