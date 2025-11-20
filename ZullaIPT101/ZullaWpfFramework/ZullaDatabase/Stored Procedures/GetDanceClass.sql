CREATE PROCEDURE [dbo].[GetDanceClass]
    @Id NVARCHAR(50) = NULL
AS
BEGIN
    SELECT * FROM [dbo].[DanceClass] AS a WHERE a.[Id] = @Id;
END;

