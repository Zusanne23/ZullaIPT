
CREATE PROCEDURE [dbo].[UpdateDanceClass]
    @Id INT,
    @Title NVARCHAR(50),
    @DanceStyle NVARCHAR(50),
    @Instructor NVARCHAR(50),
    @Schedule NVARCHAR(50)
AS
BEGIN
    UPDATE [dbo].[DanceClass]
    SET 
        Title = @Title,
        DanceStyle = @DanceStyle,
        Instructor = @Instructor,
        Schedule = @Schedule
    WHERE Id = @Id;
END;
GO
