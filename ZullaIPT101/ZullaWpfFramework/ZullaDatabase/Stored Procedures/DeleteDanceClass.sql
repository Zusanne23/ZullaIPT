CREATE PROCEDURE [dbo].[DeleteDanceClass]
    @Id INT
AS
BEGIN
    DELETE FROM [dbo].[DanceClass]
    WHERE Id = @Id;
END;
GO
