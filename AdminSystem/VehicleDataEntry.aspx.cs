using ClassLibrary; // Essential to link your middle layer
using System;
using System.Data.SqlClient;

public partial class VehicleDataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        // Create a new instance of clsVehicle
        clsVehicle AnVehicle = new clsVehicle();

        // Capture the text inputs from the web form textboxes
        string Make = txtMake.Text;
        string Model = txtModel.Text;
        string DateAdded = txtDateAdded.Text;
        string EngineSize = txtEngineSize.Text;

        // Variable to store any error messages
        string Error = "";

        // Validate the data using the Middle Layer method we just wrote
        Error = AnVehicle.Valid(Make, Model, DateAdded);

        if (Error == "")
        {
            // If there are no errors, capture the data into the object properties
            AnVehicle.Make = Make;
            AnVehicle.Model = Model;
            AnVehicle.EngineSize = Convert.ToInt32(EngineSize);
            AnVehicle.DateAdded = Convert.ToDateTime(DateAdded);
            AnVehicle.Active = chkActive.Checked;

            // Store the vehicle in the session object
            Session["AnVehicle"] = AnVehicle;

            // Navigate to the viewer page to check it works
            Response.Redirect("VehicleViewer.aspx");
        }
        else
        {
            // Display the error message on the form's Error Label
            lblError.Text = Error;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        // Redirect the user back to the Main Menu
        Response.Redirect("TeamMainMenu.aspx");
    }
}