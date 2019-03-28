CREATE TABLE [dbo].[Author]
(
	[AuthorId] INT NOT NULL PRIMARY KEY, 
    [AuthorFirstName] NVARCHAR(50) NOT NULL, 
    [AuthorLastName] NVARCHAR(50) NOT NULL, 
    [AuthorTFN] NVARCHAR(50) NOT NULL
)