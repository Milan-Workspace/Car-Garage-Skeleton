<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoicingInventoryDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Invoice Data Entry</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <div class="row">
                <div class="col-12 col-md-8 col-lg-6 mx-auto">
                    <div class="card shadow-sm">
                        <div class="card-header bg-primary text-white">
                            Invoice Data Entry
                        </div>

                        <div class="card-body">
                            <div class="mb-3">
                                <asp:Label ID="lblService" runat="server">Select Service:</asp:Label>
                                <asp:DropDownList ID="ddlServices" runat="server"></asp:DropDownList>
                            </div>

                            <div class="mb-3">
                                <asp:Label ID="lblIssueDate" runat="server">Issue Date:</asp:Label>
                                <asp:TextBox ID="txtIssueDate" runat="server" TextMode="Date"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:Label ID="lblPaymentDate" runat="server">Payment Date:</asp:Label>
                                <asp:TextBox ID="txtPaymentDate" runat="server" TextMode="Date"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:Label ID="lblIsPaid" runat="server">Is Paid:</asp:Label>
                                <asp:CheckBox ID="chkIsPaid" runat="server" />
                            </div>

                            <div class="mb-3">
                                <asp:Label ID="lblTotalAmount" runat="server">Total Amount:</asp:Label>
                                <asp:TextBox ID="txtTotalAmount" runat="server" TextMode="Number" Step="0.01"></asp:TextBox>
                            </div>

                             <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>

                            <div class="d-flex gap-2">
                                <asp:Button ID="btnOk" runat="server" Text="OK" onClick="btnOK_Click" CssClass="btn btn-primary"/>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-secondary"/>
                                <asp:Button ID="btnSubmit" runat="server" Text="Create Invoice" onClick="btnSubmit_Click" CssClass="btn btn-success ms-auto"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
