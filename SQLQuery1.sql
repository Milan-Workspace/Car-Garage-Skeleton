CREATE OR ALTER PROCEDURE dbo.sp_DeleteServiceRecord
    @ServiceID INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    DELETE FROM dbo.Invoices
    WHERE ServiceID = @ServiceID;

    DELETE FROM dbo.ServiceRecord
    WHERE ServiceID = @ServiceID;

    COMMIT TRANSACTION;
END
GO