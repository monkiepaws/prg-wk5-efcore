CREATE TABLE [dbo].[Book]
(
	[ISBN] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(MAX) NOT NULL, 
    [YearPublished] INT NULL, 
    [AuthorId] INT NOT NULL, 
    CONSTRAINT [FK_Book_To_Author] FOREIGN KEY ([AuthorId]) REFERENCES [Author]([AuthorId]) 
)