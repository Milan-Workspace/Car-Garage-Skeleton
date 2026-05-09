using System;
using System.Web.UI;
using ClassLibrary;

public partial class _1_DataEntry : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            LoadVehicles();
            LoadParts();
        }
    }

    private void LoadVehicles()
    {
        ServiceRepairBL bl = new ServiceRepairBL();

        ddlVehicle.DataSource = bl.GetVehicles();
        ddlVehicle.DataTextField = "VehicleDisplay";
        ddlVehicle.DataValueField = "VehicleID";
        ddlVehicle.DataBind();

        ddlVehicle.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select Vehicle --", ""));
    }

    private void LoadParts()
    {
        ServiceRepairBL bl = new ServiceRepairBL();

        ddlPart.DataSource = bl.GetParts();
        ddlPart.DataTextField = "PartDisplay";
        ddlPart.DataValueField = "InventoryId";
        ddlPart.DataBind();

        ddlPart.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- No Part Used --", ""));
    }

    protected void ddlServiceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlOtherService.Visible = ddlServiceType.SelectedValue == "Other";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ServiceRepair sr = new ServiceRepair();

            sr.VehicleID = Convert.ToInt32(ddlVehicle.SelectedValue);

            if (string.IsNullOrWhiteSpace(ddlPart.SelectedValue))
            {
                sr.PartID = null;
            }
            else
            {
                sr.PartID = Convert.ToInt32(ddlPart.SelectedValue);
            }

            sr.ServiceDate = Convert.ToDateTime(txtDate.Text);

            if (ddlServiceType.SelectedValue == "Other")
            {
                sr.Description = txtOtherService.Text;
            }
            else
            {
                sr.Description = ddlServiceType.SelectedValue;
            }

            sr.LaborName = txtLaborName.Text;
            sr.Status = ddlStatus.SelectedValue;

            ServiceRepairBL bl = new ServiceRepairBL();
            bl.AddService(sr);

            lblMessage.Text = "Service repair record created successfully.";
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
}