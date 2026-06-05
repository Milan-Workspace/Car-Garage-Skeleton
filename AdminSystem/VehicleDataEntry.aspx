<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VehicleDataEntry.aspx.cs" Inherits="VehicleDataEntry" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vehicle Data Entry</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family: Arial, sans-serif; padding: 20px;">
            <h2>Vehicle Data Entry</h2>
            
            <p>
                Make:<br />
                <asp:TextBox ID="txtMake" runat="server" Width="200px"></asp:TextBox>
            </p>
            
            <p>
                Model:<br />
                <asp:TextBox ID="txtModel" runat="server" Width="200px"></asp:TextBox>
            </p>
            
            <p>
                Engine Size (cc):<br />
                <asp:TextBox ID="txtEngineSize" runat="server" Width="200px"></asp:TextBox>
            </p>
            
            <p>
                Date Added (dd/mm/yyyy):<br />
                <asp:TextBox ID="txtDateAdded" runat="server" Width="200px"></asp:TextBox>
            </p>
            
            <p>
                <asp:CheckBox ID="chkActive" runat="server" Text=" Vehicle is Active" />
            </p>
            
            <p>
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </p>
            
            <p>
                <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="btnOK_Click" Height="30px" Width="80px" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Height="30px" Width="80px" />
            </p>
        </div>
    </form>
</body>
</html>
