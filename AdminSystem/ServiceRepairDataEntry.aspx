<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServiceRepairDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Service Repair Data Entry</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Service & Repair Data Entry</h2>

        Vehicle:<br />
        <asp:DropDownList ID="ddlVehicle" runat="server"></asp:DropDownList>
        <br /><br />

        Service Type:<br />
        <asp:DropDownList ID="ddlServiceType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlServiceType_SelectedIndexChanged">
            <asp:ListItem Text="Oil Change" Value="Oil Change"></asp:ListItem>
            <asp:ListItem Text="Brake Repair" Value="Brake Repair"></asp:ListItem>
            <asp:ListItem Text="Tyre Replacement" Value="Tyre Replacement"></asp:ListItem>
            <asp:ListItem Text="Engine Check" Value="Engine Check"></asp:ListItem>
            <asp:ListItem Text="MOT Check" Value="MOT Check"></asp:ListItem>
            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
        </asp:DropDownList>
        <br /><br />

        <asp:Panel ID="pnlOtherService" runat="server" Visible="false">
            Other Service:<br />
            <asp:TextBox ID="txtOtherService" runat="server"></asp:TextBox>
            <br /><br />
        </asp:Panel>

        Part Used:<br />
        <asp:DropDownList ID="ddlPart" runat="server"></asp:DropDownList>
        <br /><br />

        Service Date:<br />
        <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
        <br /><br />

        Labor Name:<br />
        <asp:TextBox ID="txtLaborName" runat="server"></asp:TextBox>
        <br /><br />

        Status:<br />
        <asp:DropDownList ID="ddlStatus" runat="server">
            <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
            <asp:ListItem Text="In Progress" Value="In Progress"></asp:ListItem>
            <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
        </asp:DropDownList>
        <br /><br />

        <asp:Button ID="btnSave" runat="server" Text="Create Service" OnClick="btnSave_Click" />
        <br /><br />

        <asp:Label ID="lblMessage" runat="server"></asp:Label>

    </form>
</body>
</html>oky 