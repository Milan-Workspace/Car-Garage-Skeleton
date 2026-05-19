<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoicingInventoryDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    This is the Invoice Data Entry Page
    <form id="form1" runat="server">
        <div>
            <label>Select Service:</label>
            <asp:DropDownList ID="ddlServices" runat="server"></asp:DropDownList>
        </div>

        <div>
            <label>Issue Date:</label>
            <asp:TextBox ID="txtIssueDate" runat="server" TextMode="Date"></asp:TextBox>
        </div>

        <div>
            <label>Payment Date:</label>
            <asp:TextBox ID="txtPaymentDate" runat="server" TextMode="Date"></asp:TextBox>
        </div>

        <div>
            <label>Total Amount:</label>
            <asp:TextBox ID="txtTotalAmount" runat="server" TextMode="Number" Step="0.01"></asp:TextBox>
        </div>

        <div>
            <label>Is Paid:</label>
            <asp:CheckBox ID="chkIsPaid" runat="server" />
        </div>

        <asp:Button ID="btnSubmit" runat="server" Text="Create Invoice" onClick="btnSubmit_Click" />
    </form>
</body>
</html>
