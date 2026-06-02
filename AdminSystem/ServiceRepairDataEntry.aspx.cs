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

            if (Request.QueryString["ServiceID"] != null)
            {
                txtServiceID.Text = Request.QueryString["ServiceID"];
                btnFind_Click(sender, e);
            }
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

            string vehicleID = ddlVehicle.SelectedValue;
            string partID = ddlPart.SelectedValue;
            string serviceDate = txtDate.Text;

            string description = ddlServiceType.SelectedValue == "Other"
                ? txtOtherService.Text
                : ddlServiceType.SelectedValue;

            string laborName = txtLaborName.Text;
            string status = ddlStatus.SelectedValue;

            string error = sr.Valid(vehicleID, partID, serviceDate, description, laborName, status);

            if (error == "")
            {
                sr.VehicleID = Convert.ToInt32(vehicleID);
                sr.PartID = string.IsNullOrWhiteSpace(partID) ? (int?)null : Convert.ToInt32(partID);
                sr.ServiceDate = Convert.ToDateTime(serviceDate);
                sr.Description = description;
                sr.LaborName = laborName;
                sr.Status = status;

                ServiceRepairCollection services = new ServiceRepairCollection();

                if (string.IsNullOrWhiteSpace(txtServiceID.Text))
                {
                    services.ThisService = sr;
                    int newServiceID = services.Add();
                    lblMessage.Text = "Service repair record created successfully. New Service ID: " + newServiceID;
                }
                else
                {
                    sr.ServiceID = Convert.ToInt32(txtServiceID.Text);
                    services.ThisService = sr;
                    services.Update();
                    lblMessage.Text = "Service repair record updated successfully.";
                }

                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = error;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        try
        {
            ServiceRepair sr = new ServiceRepair();

            if (string.IsNullOrWhiteSpace(txtServiceID.Text))
            {
                lblMessage.Text = "Please enter a Service ID.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            bool found = sr.Find(Convert.ToInt32(txtServiceID.Text));

            if (found)
            {
                ddlVehicle.SelectedValue = sr.VehicleID.ToString();
                ddlPart.SelectedValue = sr.PartID == null ? "" : sr.PartID.ToString();
                txtDate.Text = sr.ServiceDate.ToString("yyyy-MM-dd");

                if (
                    sr.Description == "Oil Change" ||
                    sr.Description == "Brake Repair" ||
                    sr.Description == "Tyre Replacement" ||
                    sr.Description == "Engine Check" ||
                    sr.Description == "MOT Check"
                )
                {
                    ddlServiceType.SelectedValue = sr.Description;
                    pnlOtherService.Visible = false;
                    txtOtherService.Text = "";
                }
                else
                {
                    ddlServiceType.SelectedValue = "Other";
                    pnlOtherService.Visible = true;
                    txtOtherService.Text = sr.Description;
                }

                txtLaborName.Text = sr.LaborName;
                ddlStatus.SelectedValue = sr.Status;

                lblMessage.Text = "Service record found.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "Service record not found.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch
        {
            lblMessage.Text = "Service ID must be numeric.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceRepairList.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceRepairList.aspx");
    }

    protected void btnMainMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("TeamMainMenu.aspx");
    }
}