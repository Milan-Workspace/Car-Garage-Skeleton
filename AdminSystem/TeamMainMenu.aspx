<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeamMainMenu.aspx.cs" Inherits="TeamMainMenu" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Garage Management System</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
</head>
<body class="bg-light">
    <form id="form1" runat="server">

        <nav class="navbar navbar-dark bg-dark">
            <div class="container">
                <span class="navbar-brand mb-0 h1">
                    <i class="bi bi-tools"></i> Garage Management System
                </span>
            </div>
        </nav>

        <div class="container mt-5">
            <div class="text-center mb-4">
                <h2>Team Main Menu</h2>
                <p class="text-muted">Select a component to continue</p>
            </div>

            <div class="card shadow p-4">
                <div class="row g-3">

                    <div class="col-md-4">
                        <asp:Button ID="btnCustomer" runat="server" Text="Customer Management"
                            CssClass="btn btn-primary w-100" OnClick="btnCustomer_Click" />
                    </div>

                    <div class="col-md-4">
                        <asp:Button ID="btnVehicle" runat="server" Text="Vehicle Management"
                            CssClass="btn btn-success w-100" OnClick="btnVehicle_Click" />
                    </div>

                    <div class="col-md-4">
                        <asp:Button ID="btnServiceRepair" runat="server" Text="Service & Repair"
                            CssClass="btn btn-warning w-100" OnClick="btnServiceRepair_Click" />
                    </div>

                    <div class="col-md-4">
                        <asp:Button ID="btnInventory" runat="server" Text="Inventory Management"
                            CssClass="btn btn-info w-100" OnClick="btnInventory_Click" />
                    </div>

                    <div class="col-md-4">
                        <asp:Button ID="btnInvoice" runat="server" Text="Invoicing"
                            CssClass="btn btn-danger w-100" OnClick="btnInvoice_Click" />
                    </div>

                </div>
            </div>
        </div>

    </form>
</body>
</html>