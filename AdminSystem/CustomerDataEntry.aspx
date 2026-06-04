<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerDataEntry.aspx.cs" Inherits="_1_DataEntry" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Data Entry</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" />
</head>
<body>
<form id="form1" runat="server">
    <nav class="navbar navbar-dark bg-dark mb-4">
    <div class="container">
        <a class="navbar-brand" href="MainMenu.aspx">Garage Management System</a>
        <a class="btn btn-outline-light" href="MainMenu.aspx">Main Menu</a>
    </div>
    </nav>
<div class="container mt-4">
    <h2>Customer Data Entry</h2>
    <div class="mb-3">
        <label class="form-label">First Name</label>
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-3">
        <label class="form-label">Last Name</label>
        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-3">
        <label class="form-label">Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-3">
        <label class="form-label">Phone</label>
        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-3">
    <asp:CheckBox ID="chkIsActive" runat="server" Text="Active" Checked="true" />
    </div>

    <asp:Button ID="btnOK" runat="server" Text="OK" CssClass="btn btn-primary" OnClick="btnOK_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary ms-2" OnClick="btnCancel_Click" />
    <br /><br />
    <asp:Label ID="lblError" runat="server" ForeColor="Red" />
</div>
</form>
</body>
</html>