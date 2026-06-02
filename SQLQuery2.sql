CREATE OR ALTER PROCEDURE dbo.sp_UpdateServiceRecord
    @ServiceID INT,
    @VehicleID INT,
    @PartID INT = NULL,
    @ServiceDate DATE,
    @Description NVARCHAR(255),
    @LaborName NVARCHAR(50),
    @Status NVARCHAR(20)
AS
BEGIN
    UPDATE dbo.ServiceRecord
    SET VehicleID = @VehicleID,
        PartID = @PartID,
        ServiceDate = @ServiceDate,
        Description = @Description,
        LaborName = @LaborName,
        Status = @Status
    WHERE ServiceID = @ServiceID;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_DeleteServiceRecord
    @ServiceID INT
AS
BEGIN
    DELETE FROM dbo.ServiceRecord
    WHERE ServiceID = @ServiceID;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_FilterServiceRecordsByStatus
    @Status NVARCHAR(20)
AS
BEGIN
    SELECT
        SR.ServiceID,
        SR.VehicleID,
        V.Registrationnumber,
        V.Make,
        V.Model,
        SR.PartID,
        I.ItemName AS PartName,
        I.UnitPrice AS PartPrice,
        SR.ServiceDate,
        SR.Description,
        SR.LaborName,
        SR.Status
    FROM dbo.ServiceRecord SR
    INNER JOIN dbo.Vehicles V ON SR.VehicleID = V.VehicleId
    LEFT JOIN dbo.Inventories I ON SR.PartID = I.InventoryId
    WHERE SR.Status = @Status
    ORDER BY SR.ServiceDate DESC;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_ServiceStatsByStatus
AS
BEGIN
    SELECT Status, COUNT(*) AS TotalServices
    FROM dbo.ServiceRecord
    GROUP BY Status;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_ServiceStatsByDate
AS
BEGIN
    SELECT ServiceDate, COUNT(*) AS TotalServices
    FROM dbo.ServiceRecord
    GROUP BY ServiceDate
    ORDER BY ServiceDate DESC;
END
GO