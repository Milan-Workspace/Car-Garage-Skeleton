using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["CustomerID"] = null;
            DisplayCustomers("");
        }
    }

    void DisplayCustomers(string lastNameFilter)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd;
            if (lastNameFilter == "")
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
            gvCustomers.DataSource = dt;
            gvCustomers.DataBind();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DisplayCustomers(txtSearch.Text);
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtSearch.Text = "";
        DisplayCustomers("");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Session["CustomerID"] = null;
        Response.Redirect("CustomerDataEntry.aspx");
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Session["CustomerID"] = btn.CommandArgument;
        Response.Redirect("CustomerViewer.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Session["CustomerID"] = btn.CommandArgument;
        Response.Redirect("CustomerDataEntry.aspx");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Session["CustomerID"] = btn.CommandArgument;
        Response.Redirect("CustomerConfirmDelete.aspx");
    }
}