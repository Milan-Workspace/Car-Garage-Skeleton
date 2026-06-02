<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServiceRepairConfirmDelete.aspx.cs" Inherits="_ServiceRepairConfirmDelete" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Confirm Delete</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
</head>

<body class="bg-light">
    <form id="form1" runat="server">

        <div class="container mt-5">
            <div class="card shadow border-danger">
                <div class="card-header bg-danger text-white">
                    <h4 class="mb-0"><i class="bi bi-exclamation-triangle"></i> Confirm Delete</h4>
                </div>

                <div class="card-body">
                    <p class="lead">Are you sure you want to delete this service record?</p>

                    <asp:Button ID="btnYes" runat="server" Text="Yes, Delete"
                        CssClass="btn btn-danger" OnClick="btnYes_Click" />

                    <asp:Button ID="btnNo" runat="server" Text="No, Cancel"
                        CssClass="btn btn-secondary" OnClick="btnNo_Click" />

                    <br /><br />
                    <asp:Label ID="lblMessage" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
            </div>
        </div>

    </form>
</body>
</html>