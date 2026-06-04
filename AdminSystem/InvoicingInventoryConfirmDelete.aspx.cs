using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_ConfirmDelete : System.Web.UI.Page
{
    Int32 invoiceId;

    protected void Page_Load(object sender, EventArgs e)
    {
        invoiceId = Convert.ToInt32(Session["InvoiceId"]);
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        clsInvoicingCollection allInvoices = new clsInvoicingCollection();
        allInvoices.ThisInvoice.Find(invoiceId);
        allInvoices.Delete();
        Response.Redirect("InvoicingInventoryList.aspx");
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        Response.Redirect("InvoicingInventoryList.aspx");
    }
}