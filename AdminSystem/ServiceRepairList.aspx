<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServiceRepairList.aspx.cs" Inherits="_ServiceRepairList" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Service Repair List</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
</head>

<body class="bg-light">
    <form id="form1" runat="server">

        <nav class="navbar navbar-dark bg-dark">
            <div class="container">
                <span class="navbar-brand">
                    <i class="bi bi-list-check"></i> Service Repair Records
                </span>
            </div>
        </nav>

        <div class="container mt-4">

            <div class="card shadow">
                <div class="card-header bg-primary text-white">
                    <h4 class="mb-0">All Service Repair Records</h4>
                </div>

                <div class="card-body">

                    <div class="row mb-3">
                        <div class="col-md-4">
                            <label class="form-label">Filter by Status</label>
                            <asp:DropDownList ID="ddlFilterStatus" runat="server" CssClass="form-select">
                                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                <asp:ListItem Text="In Progress" Value="In Progress"></asp:ListItem>
                                <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col-md-4 d-flex align-items-end">
                            <asp:Button ID="btnFilter" runat="server" Text="Apply Filter"
                                CssClass="btn btn-primary me-2" OnClick="btnFilter_Click" />

                            <asp:Button ID="btnClearFilter" runat="server" Text="Clear Filter"
                                CssClass="btn btn-outline-secondary" OnClick="btnClearFilter_Click" />
                        </div>
                    </div>

                    <asp:GridView ID="gvServices" runat="server"
                        AutoGenerateColumns="False"
                        DataKeyNames="ServiceID"
                        OnRowCommand="gvServices_RowCommand"
                        CssClass="table table-bordered table-striped table-hover"
                        HeaderStyle-CssClass="table-dark">

                        <Columns>
                            <asp:BoundField DataField="ServiceID" HeaderText="Service ID" />
                            <asp:BoundField DataField="VehicleID" HeaderText="Vehicle ID" />
                            <asp:BoundField DataField="Registrationnumber" HeaderText="Registration" />
                            <asp:BoundField DataField="Description" HeaderText="Service" />
                            <asp:BoundField DataField="LaborName" HeaderText="Labor Name" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:BoundField DataField="ServiceDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />

                            <asp:ButtonField Text="Edit" CommandName="EditRecord" ButtonType="Button" />
                            <asp:ButtonField Text="Delete" CommandName="DeleteRecord" ButtonType="Button" />
                        </Columns>
                    </asp:GridView>

                    <div class="d-flex gap-2 flex-wrap mt-3">
                        <asp:Button ID="btnAdd" runat="server" Text="Add New Service"
                            CssClass="btn btn-success" OnClick="btnAdd_Click" />

                        <asp:Button ID="btnStats" runat="server" Text="Statistics Page"
                            CssClass="btn btn-info" OnClick="btnStats_Click" />

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