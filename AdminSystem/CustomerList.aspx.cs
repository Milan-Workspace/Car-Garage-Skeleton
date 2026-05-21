using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            Session["CustomerID"] = null;
            DisplayCustomers("");
        }
    }

    void DisplayCustomers(string lastNameFilter)
    {
        clsCustomerCollection Customers = new clsCustomerCollection();
        if (lastNameFilter != "")
            Customers.ReportByLastName(lastNameFilter);
        gvCustomers.DataSource = Customers.CustomerList;
        gvCustomers.DataBind();
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

    protected void btnView_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Session["CustomerID"] = btn.CommandArgument;
        Response.Redirect("CustomerViewer.aspx");
    }
}