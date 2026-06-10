<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerList.aspx.cs" Inherits="_1_List" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer List</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" />
</head>
<body>
<form id="form1" runat="server">
<div class="container mt-4">
    <h2>Customer List</h2>
    <div class="row mb-3">
        <div class="col-md-4">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search by last name..." />
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click" />
        </div>
        <div class="col-md-4 text-end">
            <asp:Button ID="btnAdd" runat="server" Text="Add Customer" CssClass="btn btn-success" OnClick="btnAdd_Click" />
        </div>
    </div>
    <asp:GridView ID="gvCustomers" runat="server" CssClass="table table-bordered table-striped"
        AutoGenerateColumns="false" DataKeyNames="CustomerID">
        <Columns>
            <asp:BoundField DataField="CustomerID" HeaderText="ID" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
            <asp:BoundField DataField="DateRegistered" HeaderText="Date Registered" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-sm btn-warning"
                        CommandArgument='<%# Eval("CustomerID") %>' OnClick="btnEdit_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-sm btn-danger"
                        CommandArgument='<%# Eval("CustomerID") %>' OnClick="btnDelete_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
</form>
</body>
</html>