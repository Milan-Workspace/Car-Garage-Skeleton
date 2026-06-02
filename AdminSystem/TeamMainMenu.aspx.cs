using System;
using System.Web.UI;

public partial class TeamMainMenu : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnCustomer_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerList.aspx");
    }

    protected void btnVehicle_Click(object sender, EventArgs e)
    {
        Response.Redirect("VehicleList.aspx");
    }

    protected void btnServiceRepair_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceRepairList.aspx");
    }

    protected void btnInventory_Click(object sender, EventArgs e)
    {
        Response.Redirect("InvoicingInventoryList.aspx");
    }

    protected void btnInvoice_Click(object sender, EventArgs e)
    {
        Response.Redirect("InvoicingInventoryList.aspx");
    }
}