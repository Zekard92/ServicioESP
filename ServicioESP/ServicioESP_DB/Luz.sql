CREATE TABLE [dbo].[Luz]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[Name] nvarchar(100) not null default '-', 
    [State] BIT NOT NULL default 0
)
