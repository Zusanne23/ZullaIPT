CREATE PROCEDURE [dbo].[CreateDanceClass]
    @Title NVARCHAR(50),
    @DanceStyle NVARCHAR(50),
    @Instructor NVARCHAR(50),
    @Schedule NVARCHAR(50)
AS
BEGIN
    INSERT INTO [dbo].[DanceClass] (Title, DanceStyle, Instructor, Schedule)
    VALUES (@Title, @DanceStyle, @Instructor, @Schedule);
END;
