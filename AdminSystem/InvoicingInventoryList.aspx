<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoicingInventoryList.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Invoice List</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <div class="row">
                <div class="col-12 col-md-8 col-lg-6 mx-auto">
                    <div class="card shadow-sm">
                        <div class="card-header bg-dark text-white">
                            Invoice List
                        </div>

                        <div class="card-body">
                           <asp:ListBox ID="lstInvoiceList" runat="server" CssClass="form-select mb-3" Height="200px"></asp:ListBox>

                            <div class="d-flex gap-2">
                                <asp:Button ID="btnAdd" Text="Add" runat="server" CssClass="btn btn-success"/>
                                <asp:Button ID="btnEdit" Text="Edit" runat="server" CssClass="btn btn-primary"/>
                                <asp:Button ID="btnDelete" Text="Delete" runat="server" Csslass="btn btn-danger"/>
                            </div>

                            <asp:Label ID="lblError" runat="server" CssClass="text-danger d-block mt-3"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
