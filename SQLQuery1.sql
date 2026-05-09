ALTER PROCEDURE dbo.sp_InsertServiceRecord
    @VehicleID INT,
    @PartID INT = NULL,
    @ServiceDate DATE,
    @Description NVARCHAR(255),
    @LaborName NVARCHAR(50),
    @Status NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    -- 🔒 Check stock BEFORE inserting
    IF @PartID IS NOT NULL
    BEGIN
        IF NOT EXISTS (
            SELECT 1
            FROM dbo.Inventories
            WHERE InventoryId = @PartID
            AND Quantity > 0
        )
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Part is out of stock.', 16, 1);
            RETURN;
        END
    END

    -- ✅ Insert service
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

    -- 🔽 Reduce stock AFTER successful insert
    IF @PartID IS NOT NULL
    BEGIN
        UPDATE dbo.Inventories
        SET Quantity = Quantity - 1
        WHERE InventoryId = @PartID;
    END

    COMMIT TRANSACTION;
END