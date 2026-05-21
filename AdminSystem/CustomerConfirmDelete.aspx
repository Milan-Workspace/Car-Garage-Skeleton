<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerConfirmDelete.aspx.cs" Inherits="_1_ConfirmDelete" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirm Delete</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" />
</head>
<body>
<form id="form1" runat="server">
<div class="container mt-4">
    <h2>Confirm Delete</h2>
    <div class="alert alert-danger">
        <p>Are you sure you want to delete this customer?</p>
        <strong><asp:Label ID="lblCustomerName" runat="server" /></strong>
    </div>
    <asp:Button ID="btnYes" runat="server" Text="Yes - Delete" CssClass="btn btn-danger" OnClick="btnYes_Click" />
    <asp:Button ID="btnNo" runat="server" Text="No - Cancel" CssClass="btn btn-secondary ms-2" OnClick="btnNo_Click" />
</div>
</form>
</body>
</html>