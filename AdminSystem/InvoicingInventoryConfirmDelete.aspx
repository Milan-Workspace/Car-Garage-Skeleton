<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoicingInventoryConfirmDelete.aspx.cs" Inherits="_1_ConfirmDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Are you sure you want to delete this record?
            <asp:Button ID="yes" Text="Yes" runat="server" />
            <asp:Button ID="no" Text="No" runat="server" />
        </div>
    </form>
</body>
</html>
