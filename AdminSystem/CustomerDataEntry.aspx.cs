using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1_DataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CustomerID"] != null)
            {
                DisplayCustomer();
            }
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
                    txtFirstName.Text = reader["FirstName"].ToString();
                    txtLastName.Text = reader["LastName"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtPhone.Text = reader["PhoneNumber"].ToString();
                    chkIsActive.Checked = Convert.ToBoolean(reader["isActive"]);
                }
            }
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        string firstName = txtFirstName.Text;
        string lastName = txtLastName.Text;
        string email = txtEmail.Text;
        string phone = txtPhone.Text;

        ClassLibrary.clsCustomer ACustomer = new ClassLibrary.clsCustomer();
        string error = ACustomer.Valid(firstName, lastName, email, phone);

        if (error != "")
        {
            lblError.Text = "Please fix the following errors: " + error;
            return;
        }

        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            if (Session["CustomerID"] == null)
            {
                using (SqlCommand cmd = new SqlCommand("sproc_tbl_CustomerAdd", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand("sproc_tbl_CustomerUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", Convert.ToInt32(Session["CustomerID"]));
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        Response.Redirect("CustomerList.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerList.aspx");
    }
}