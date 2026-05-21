using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1Viewer : System.Web.UI.Page
{
    private string GetServiceDescription(int serviceId)
    {
        string result = "";

        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(cs))
        {
            string query = "SELECT Description from dbo.ServiceRecord WHERE ServiceId = @ServiceId";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ServiceId", serviceId);
                conn.Open();

                object value = cmd.ExecuteScalar();
                if (value != null)
                {
                    result = value.ToString();
                }
            }
        }

        return result;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        clsInvoicing invoicing = new clsInvoicing();
        invoicing = (clsInvoicing)Session["invoicing"];
        string serviceDescription = GetServiceDescription(invoicing.ServiceId);

        Response.Write("Service: " + serviceDescription + "<br>");
        Response.Write("Issue Date: " + invoicing.IssueDate + "<br>");
        Response.Write("Payment Date: " + invoicing.PaymentDate + "<br>");
        Response.Write("Is Paid: " + invoicing.IsPaid + "<br>");
        Response.Write("Total Amount: " + invoicing.TotalAmount + "<br>");
    }
}