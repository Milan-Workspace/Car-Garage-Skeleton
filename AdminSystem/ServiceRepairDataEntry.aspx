<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServiceRepairDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Service Repair Data Entry</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
</head>

<body class="bg-light">
    <form id="form1" runat="server">

        <nav class="navbar navbar-dark bg-dark">
            <div class="container">
                <span class="navbar-brand">
                    <i class="bi bi-wrench-adjustable"></i> Service & Repair
                </span>
            </div>
        </nav>

        <div class="container mt-4">

            <div class="card shadow">
                <div class="card-header bg-primary text-white">
                    <h4 class="mb-0">Service & Repair Data Entry</h4>
                </div>

                <div class="card-body">

                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label class="form-label">Service ID</label>
                            <div class="input-group">
                                <asp:TextBox ID="txtServiceID" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Button ID="btnFind" runat="server" Text="Find"
                                    CssClass="btn btn-primary" OnClick="btnFind_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="mb-3">
                        <label class="form-label">Vehicle</label>
                        <asp:DropDownList ID="ddlVehicle" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <label class="form-label">Service Type</label>
                        <asp:DropDownList ID="ddlServiceType" runat="server"
                            CssClass="form-select"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="ddlServiceType_SelectedIndexChanged">
                            <asp:ListItem Text="Oil Change" Value="Oil Change"></asp:ListItem>
                            <asp:ListItem Text="Brake Repair" Value="Brake Repair"></asp:ListItem>
                            <asp:ListItem Text="Tyre Replacement" Value="Tyre Replacement"></asp:ListItem>
                            <asp:ListItem Text="Engine Check" Value="Engine Check"></asp:ListItem>
                            <asp:ListItem Text="MOT Check" Value="MOT Check"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <asp:Panel ID="pnlOtherService" runat="server" Visible="false">
                        <div class="mb-3">
                            <label class="form-label">Other Service</label>
                            <asp:TextBox ID="txtOtherService" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </asp:Panel>

                    <div class="mb-3">
                        <label class="form-label">Part Used</label>
                        <asp:DropDownList ID="ddlPart" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <label class="form-label">Service Date</label>
                        <asp:TextBox ID="txtDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label class="form-label">Labor Name</label>
                        <asp:TextBox ID="txtLaborName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label class="form-label">Status</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select">
                            <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                            <asp:ListItem Text="In Progress" Value="In Progress"></asp:ListItem>
                            <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="d-flex gap-2 flex-wrap">
                        <asp:Button ID="btnSave" runat="server" Text="Create / Update Service"
                            CssClass="btn btn-success" OnClick="btnSave_Click" />

                        <asp:Button ID="btnViewAll" runat="server" Text="View All Services"
                            CssClass="btn btn-primary" OnClick="btnViewAll_Click" />

                        <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                            CssClass="btn btn-outline-secondary" OnClick="btnCancel_Click" />

                        <asp:Button ID="btnMainMenu" runat="server" Text="Return To Main Menu"
                            CssClass="btn btn-dark" OnClick="btnMainMenu_Click" />
                    </div>

                    <br />

                    <asp:Label ID="lblMessage" runat="server" CssClass="fw-bold"></asp:Label>

                </div>
            </div>

        </div>
    </form>
</body>
</html>