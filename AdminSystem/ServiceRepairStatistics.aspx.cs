using System;
using System.Data;
using System.Web.UI;
using ClassLibrary;

public partial class _ServiceRepairStatistics : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayStatistics();
        }
    }

    private void DisplayStatistics()
    {
        ServiceRepairCollection services = new ServiceRepairCollection();

        DataTable statusStats = services.StatisticsByStatus();
        GridViewStatus.DataSource = statusStats;
        GridViewStatus.DataBind();

        DataTable dateStats = services.StatisticsByDate();
        GridViewDate.DataSource = dateStats;
        GridViewDate.DataBind();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceRepairList.aspx");
    }

    protected void btnMainMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("TeamMainMenu.aspx");
    }
}