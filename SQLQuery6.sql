CREATE PROCEDURE dbo.sp_InsertServiceRecord
    @VehicleID INT,
    @PartID INT = NULL,
    @ServiceDate DATE,
    @Description NVARCHAR(255),
    @LaborName NVARCHAR(50),
    @Status NVARCHAR(20)
AS
BEGIN
    INSERT INTO dbo.ServiceRecord
    (
        VehicleID,
        PartID,
        ServiceDate,
        Description,
        LaborName,
        Status
    )
    VALUES
    (
        @VehicleID,
        @PartID,
        @ServiceDate,
        @Description,
        @LaborName,
        @Status
    );
END
GO