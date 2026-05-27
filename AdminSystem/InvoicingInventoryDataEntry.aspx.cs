using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_DataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadServices();
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        clsInvoicing invoicing = new clsInvoicing();
        string serviceId = ddlServices.SelectedValue;
        string issueDate = txtIssueDate.Text;
        string paymentDate = txtPaymentDate.Text;
        string totalAmount = txtTotalAmount.Text;
        bool isPaid = chkIsPaid.Checked;

        string Error = "";
        Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);

        if (Error == "")
        {
            invoicing.ServiceId = int.Parse(ddlServices.SelectedValue);
            invoicing.IssueDate = DateTime.Parse(txtIssueDate.Text);
            invoicing.PaymentDate = DateTime.Parse(txtPaymentDate.Text);
            invoicing.IsPaid = chkIsPaid.Checked;
            invoicing.TotalAmount = decimal.Parse(txtTotalAmount.Text);

            Session["invoicing"] = invoicing;
            Response.Redirect("InvoicingInventoryViewer.aspx");
        }
        else
        {
            lblError.Text = Error;
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