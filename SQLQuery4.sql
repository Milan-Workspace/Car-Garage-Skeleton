ALTER TABLE dbo.ServiceRecord
ADD CONSTRAINT FK_ServiceRecord_Inventories
FOREIGN KEY (PartID)
REFERENCES dbo.Inventories(PartID);