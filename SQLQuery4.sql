CREATE OR ALTER PROCEDURE dbo.sp_FilterServiceRecordsByStatus
    @Status NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        SR.ServiceID,
        SR.VehicleID,
        V.Registrationnumber,
        V.[Make],
        V.[Model],
        SR.PartID,
        I.ItemName AS PartName,
        I.UnitPrice AS PartPrice,
        SR.ServiceDate,
        SR.Description,
        SR.LaborName,
        SR.Status
    FROM dbo.ServiceRecord AS SR
    INNER JOIN dbo.Vehicles AS V
        ON SR.VehicleID = V.VehicleId
    LEFT JOIN dbo.Inventories AS I
        ON SR.PartID = I.InventoryId
    WHERE SR.Status = @Status
    ORDER BY SR.ServiceDate DESC;
END