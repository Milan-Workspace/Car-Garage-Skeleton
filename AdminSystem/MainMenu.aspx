<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeamMainMenu.aspx.cs" Inherits="TeamMainMenu" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Garage Management System</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" />
</head>
<body class="bg-light">
<form id="form1" runat="server">
<div class="container mt-5">
    <div class="text-center mb-5">
        <h1 class="fw-bold">Car Garage Management System</h1>
        <p class="text-muted fs-5">Select a section to get started</p>
    </div>
    <div class="row g-4">

        <!-- Customer Management -->
        <div class="col-md-6">
            <div class="card h-100 shadow-sm border-primary">
                <div class="card-header bg-primary text-white">
                    <h4 class="mb-0">Customer Management</h4>
                </div>
                <div class="card-body d-flex flex-column gap-2">
                    <a href="CustomerList.aspx" class="btn btn-outline-primary">Customer List</a>
                    <a href="CustomerDataEntry.aspx" class="btn btn-outline-primary">Add Customer</a>
                    <a href="CustomerStatistics.aspx" class="btn btn-outline-primary">Customer Statistics</a>
                </div>
            </div>
        </div>

        <!-- Vehicle Management -->
        <div class="col-md-6">
            <div class="card h-100 shadow-sm border-secondary">
                <div class="card-header bg-secondary text-white">
                    <h4 class="mb-0">Vehicle Management</h4>
                </div>
                <div class="card-body d-flex flex-column gap-2">
                    <button class="btn btn-outline-secondary" disabled="disabled">Vehicle List</button>
                    <button class="btn btn-outline-secondary" disabled="disabled">Add Vehicle</button>
                    <button class="btn btn-outline-secondary" disabled="disabled">Vehicle Statistics</button>
                </div>
            </div>
        </div>

        <!-- Service & Repair -->
        <div class="col-md-6">
            <div class="card h-100 shadow-sm border-warning">
                <div class="card-header bg-warning text-dark">
                    <h4 class="mb-0">Service & Repair</h4>
                </div>
                <div class="card-body d-flex flex-column gap-2">
                    <button class="btn btn-outline-warning" disabled="disabled">Service List</button>
                    <button class="btn btn-outline-warning" disabled="disabled">Add Service</button>
                    <button class="btn btn-outline-warning" disabled="disabled">Service Statistics</button>
                </div>
            </div>
        </div>

        <!-- Invoicing & Inventory -->
        <div class="col-md-6">
            <div class="card h-100 shadow-sm border-success">
                <div class="card-header bg-success text-white">
                    <h4 class="mb-0">Invoicing & Inventory</h4>
                </div>
                <div class="card-body d-flex flex-column gap-2">
                    <button class="btn btn-outline-success" disabled="disabled">Invoice List</button>
                    <button class="btn btn-outline-success" disabled="disabled">Add Invoice</button>
                    <button class="btn btn-outline-success" disabled="disabled">Invoice Statistics</button>
                </div>
            </div>
        </div>

    </div>
</div>
</form>
</body>
</html>