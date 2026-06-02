<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServiceRepairStatistics.aspx.cs" Inherits="_ServiceRepairStatistics" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Service Repair Statistics</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
</head>

<body class="bg-light">
    <form id="form1" runat="server">

        <nav class="navbar navbar-dark bg-dark">
            <div class="container">
                <span class="navbar-brand">
                    <i class="bi bi-bar-chart"></i> Service Repair Statistics
                </span>
            </div>
        </nav>

        <div class="container mt-4">

            <div class="card shadow mb-4">
                <div class="card-header bg-info text-white">
                    <h4 class="mb-0">Services Grouped By Status</h4>
                </div>

                <div class="card-body">
                    <asp:GridView ID="GridViewStatus" runat="server"
                        CssClass="table table-bordered table-striped"
                        HeaderStyle-CssClass="table-dark">
                    </asp:GridView>
                </div>
            </div>

            <div class="card shadow mb-4">
                <div class="card-header bg-primary text-white">
                    <h4 class="mb-0">Services Grouped By Date</h4>
                </div>

                <div class="card-body">
                    <asp:GridView ID="GridViewDate" runat="server"
                        CssClass="table table-bordered table-striped"
                        HeaderStyle-CssClass="table-dark">
                    </asp:GridView>
                </div>
            </div>

            <asp:Button ID="btnBack" runat="server" Text="Back To List"
                CssClass="btn btn-secondary" OnClick="btnBack_Click" />

            <asp:Button ID="btnMainMenu" runat="server" Text="Return To Main Menu"
                CssClass="btn btn-dark" OnClick="btnMainMenu_Click" />

        </div>

    </form>
</body>
</html>