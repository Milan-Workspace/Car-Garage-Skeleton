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
        if (!IsPostBack)
        {
            DisplayInvoices();
        }
    }

    void DisplayInvoices()
    {
        clsInvoicingCollection invoices = new clsInvoicingCollection();

        // Display Invoice Count in Browser for Debugging
        Response.Write("Count = " + invoices.Count);

        lstInvoiceList.DataSource = invoices.InvoicingList;
        lstInvoiceList.DataValueField = "InvoiceId";
        lstInvoiceList.DataTextField = "InvoiceSummary";
        lstInvoiceList.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Session["InvoiceId"] = -1;
        Response.Redirect("InvoicingInventoryDataEntry.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Int32 invoiceId;

        if (lstInvoiceList.SelectedIndex != -1)
        {
            invoiceId = Convert.ToInt32(lstInvoiceList.SelectedValue);
            Session["InvoiceId"] = invoiceId;
            Response.Redirect("InvoicingInventoryDataEntry.aspx");
        }
        else
        {
            lblError.Text = "Please select a record from the list to edit";
        }
    }
}