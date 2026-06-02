using System;
using System.Web.UI;
using ClassLibrary;

public partial class _ServiceRepairConfirmDelete : Page
{
    int ServiceID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ServiceID"] != null)
        {
            ServiceID = Convert.ToInt32(Session["ServiceID"]);
        }
        else
        {
            lblMessage.Text = "No service record selected.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        ServiceRepairCollection services = new ServiceRepairCollection();

        services.ThisService.ServiceID = ServiceID;
        services.Delete();

        Response.Redirect("ServiceRepairList.aspx");
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceRepairList.aspx");
    }
}