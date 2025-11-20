CREATE TABLE [dbo].[DanceClass]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [DanceStyle] NVARCHAR(50) NOT NULL, 
    [Instructor] NVARCHAR(50) NOT NULL, 
    [Schedule] NVARCHAR(50) NOT NULL
)
