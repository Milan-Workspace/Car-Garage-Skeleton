<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerViewer.aspx.cs" Inherits="_1Viewer" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Viewer</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" />
</head>
<body>
<form id="form1" runat="server">
    <nav class="navbar navbar-dark bg-dark mb-4">
    <div class="container">
        <a class="navbar-brand" href="TeamMainMenu.aspx">Garage Management System</a>
        <a class="btn btn-outline-light" href="MainMenu.aspx">Main Menu</a>
    </div>
    </nav>
<div class="container mt-4">
    <h2>Customer Details</h2>
    <table class="table table-bordered w-50">
        <tr><th>Customer ID</th><td><asp:Label ID="lblCustomerID" runat="server" /></td></tr>
        <tr><th>First Name</th><td><asp:Label ID="lblFirstName" runat="server" /></td></tr>
        <tr><th>Last Name</th><td><asp:Label ID="lblLastName" runat="server" /></td></tr>
        <tr><th>Email</th><td><asp:Label ID="lblEmail" runat="server" /></td></tr>
        <tr><th>Phone</th><td><asp:Label ID="lblPhone" runat="server" /></td></tr>
        <tr><th>Date Registered</th><td><asp:Label ID="lblDateRegistered" runat="server" /></td></tr>
        <tr><th>Active</th><td><asp:Label ID="lblIsActive" runat="server" /></td></tr>
    </table>
    <asp:Button ID="btnBack" runat="server" Text="Back to Customer List" CssClass="btn btn-secondary" OnClick="btnBack_Click" />
    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-warning ms-2" OnClick="btnEdit_Click" />
</div>
</form>
</body>
</html>