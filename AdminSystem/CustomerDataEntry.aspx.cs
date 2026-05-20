using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_DataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (Session["CustomerID"] != null)
            {
                DisplayCustomer();
            }
        }
    }

    void DisplayCustomer()
    {
        clsCustomer ACustomer = new clsCustomer();
        int CustomerID = Convert.ToInt32(Session["CustomerID"]);
        ACustomer.Find(CustomerID);
        txtFirstName.Text = ACustomer.FirstName;
        txtLastName.Text = ACustomer.LastName;
        txtEmail.Text = ACustomer.Email;
        txtPhone.Text = ACustomer.Phone;
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        clsCustomer ACustomer = new clsCustomer();

        string FirstName = txtFirstName.Text;
        string LastName = txtLastName.Text;
        string Email = txtEmail.Text;
        string Phone = txtPhone.Text;

        string Error = ACustomer.Valid(FirstName, LastName, Email, Phone);

        if (Error == "")
        {
            ACustomer.FirstName = FirstName;
            ACustomer.LastName = LastName;
            ACustomer.Email = Email;
            ACustomer.Phone = Phone;
            ACustomer.IsActive = true;
            ACustomer.DateRegistered = DateTime.Now;

            clsCustomerCollection CustomerList = new clsCustomerCollection();
            CustomerList.ThisCustomer = ACustomer;

            if (Session["CustomerID"] == null)
                CustomerList.Add();
            else
                CustomerList.Update();

            Response.Redirect("CustomerList.aspx");
        }
        else
        {
            lblError.Text = "Please fix the following errors: " + Error;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerList.aspx");
    }
}