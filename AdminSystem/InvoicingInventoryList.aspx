<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoicingInventoryList.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    This is the Invoice List Page
    <form id="form1" runat="server">
        <asp:ListBox ID="lstInvoiceList" runat="server" Height="150px" Width="225px"></asp:ListBox>
        <asp:Button ID="btnAdd" Text="Add" runat="server" />
        <asp:Button ID="btnEdit" Text="Edit" runat="server" />
        <asp:Button ID="btnDelete" Text="Delete" runat="server" />
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </form>
</body>
</html>

