<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerStatistics.aspx.cs" Inherits="CustomerStatistics" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Statistics</title>
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
    <h2>Customer Statistics</h2>
    <table class="table table-bordered w-50 mt-3">
        <tr class="table-primary">
            <th>Statistic</th>
            <th>Value</th>
        </tr>
        <tr>
            <td>Total Customers</td>
            <td><asp:Label ID="lblTotal" runat="server" /></td>
        </tr>
        <tr>
            <td>Active Customers</td>
            <td><asp:Label ID="lblActive" runat="server" /></td>
        </tr>
        <tr>
            <td>Inactive Customers</td>
            <td><asp:Label ID="lblInactive" runat="server" /></td>
        </tr>
    </table>
    <asp:Button ID="btnBack" runat="server" Text="Back to Customer List" CssClass="btn btn-secondary mt-2" OnClick="btnBack_Click" />
</div>
</form>
</body>
</html>