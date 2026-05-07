using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1_DataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadServices();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("usp_InsertInvoice", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceId", int.Parse(ddlServices.SelectedValue));
                cmd.Parameters.AddWithValue("@IssueDate", DateTime.Parse(txtIssueDate.Text));
                cmd.Parameters.AddWithValue("@PaymentDate", DateTime.Parse(txtPaymentDate.Text));
                cmd.Parameters.AddWithValue("@IsPaid", chkIsPaid.Checked);
                cmd.Parameters.AddWithValue("@TotalAmount", decimal.Parse(txtTotalAmount.Text));
                conn.Open();
                cmd.ExecuteNonQuery();
                Response.Redirect("InvoicingInventoryList.aspx");
            }
        }
    }

    private void LoadServices()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("sp_SelectAllServiceRecords", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                ddlServices.DataSource = dt;
                ddlServices.DataTextField = "Description";
                ddlServices.DataValueField = "ServiceId";
                ddlServices.DataBind();
                ddlServices.Items.Insert(0, new ListItem("-- Select a Service --", "0"));
            }
        }
    }
}