using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _ServiceRepairList : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayServices();
        }
    }

    private void DisplayServices()
    {
        ServiceRepairBL bl = new ServiceRepairBL();
        gvServices.DataSource = bl.GetAllServiceRecords();
        gvServices.DataBind();
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        ServiceRepairBL bl = new ServiceRepairBL();

        if (ddlFilterStatus.SelectedValue == "All")
        {
            gvServices.DataSource = bl.GetAllServiceRecords();
        }
        else
        {
            gvServices.DataSource = bl.FilterByStatus(ddlFilterStatus.SelectedValue);
        }

        gvServices.DataBind();
    }

    protected void btnClearFilter_Click(object sender, EventArgs e)
    {
        ddlFilterStatus.SelectedValue = "All";
        DisplayServices();
    }

    protected void gvServices_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rowIndex = Convert.ToInt32(e.CommandArgument);
        int serviceID = Convert.ToInt32(gvServices.DataKeys[rowIndex].Value);

        if (e.CommandName == "EditRecord")
        {
            Response.Redirect("ServiceRepairDataEntry.aspx?ServiceID=" + serviceID);
        }

        if (e.CommandName == "DeleteRecord")
        {
            Session["ServiceID"] = serviceID;
            Response.Redirect("ServiceRepairConfirmDelete.aspx");
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceRepairDataEntry.aspx");
    }

    protected void btnStats_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceRepairStatistics.aspx");
    }

    protected void btnMainMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("TeamMainMenu.aspx");
    }
}