# Car Garage Management System

A web-based Car Garage Management System built as a team project for module CTEC2714 at De Montfort University.

## Team Members

| Developer | Component |
|---|---|
| Tarik | Customer Management |
| Milan | Invoicing & Inventory |
| Muhammad | Vehicle Management |
| Kevinson | Service & Repair |

## Tech Stack

- **Frontend:** ASP.NET Web Forms, Bootstrap 5
- **Backend:** C# (.NET Framework 4.8)
- **Database:** SQL Server (DMU hosted)
- **Architecture:** Three-Layer (Presentation → Business Logic → Data)
- **Version Control:** GitHub

## Project Structure

```
Car-Garage-Skeleton/
├── AdminSystem/          # Presentation layer - ASP.NET Web Forms (.aspx pages)
├── ClassLibrary/         # Business logic layer - C# classes
├── Testing1/             # Unit tests - Customer component
├── Testing2/             # Unit tests - Vehicle component
├── Testing3/             # Unit tests - Service & Repair component
├── Testing4/             # Unit tests - Invoicing & Inventory component
└── Skeleton.sln          # Visual Studio solution file
```

## Features

- **Customer Management** — Add, edit, soft-delete, list, search and filter customers
- **Vehicle Management** — Register and manage vehicles linked to customers
- **Service & Repair** — Create and track service records linked to vehicles
- **Invoicing & Inventory** — Generate invoices and manage parts inventory

## Database

The system uses a shared SQL Server database hosted on DMU servers. Five tables:

- `tbl.customers` — Customer records
- `Vehicles` — Vehicle records linked to customers
- `ServiceRecord` — Service and repair records
- `Invoices` — Invoice records linked to services
- `Inventories` — Parts and inventory

## Setup Instructions

### Prerequisites
- Visual Studio 2022
- .NET Framework 4.8
- Access to DMU SQL Server (on campus or via DMU Horizon)

4. Add an `app.config` to the `ClassLibrary` and `Testing1` projects with the same connection string

5. Right click **AdminSystem** → Set as Startup Project → press F5 to run

### GitHub Workflow

1. Create a clean folder
2. Clone the repo fresh
3. Create a new branch
4. Do your work
5. Commit with a meaningful message
6. Push your branch
7. Create a pull request on GitHub
8. Merge into main
9. Delete your branch and local folder

## Notes

- `Web.config` and `app.config` files are not tracked by Git — each developer maintains their own local copy
- Always work on a branch, never commit directly to main
- The main branch must always be error free
