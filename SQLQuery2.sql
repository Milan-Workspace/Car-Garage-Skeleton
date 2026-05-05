-- Rename EmployeeID to PartID
EXEC sp_rename 'dbo.ServiceRecord.EmployeeID', 'PartID', 'COLUMN';
GO

-- Add foreign key for Vehicle
ALTER TABLE dbo.ServiceRecord
ADD CONSTRAINT FK_ServiceRecord_Vehicles
FOREIGN KEY (VehicleID)
REFERENCES dbo.Vehicles(VehicleID);
GO

-- Add foreign key for Part (Inventory)
ALTER TABLE dbo.ServiceRecord
ADD CONSTRAINT FK_ServiceRecord_Inventories
FOREIGN KEY (PartID)
REFERENCES dbo.Inventories(PartID);
GO