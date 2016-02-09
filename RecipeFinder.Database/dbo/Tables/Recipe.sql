CREATE TABLE [dbo].[Recipe]
(
	[RecipeId] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(64) NOT NULL, 
    [Description] VARCHAR(256) NULL, 
    [PrepTime] INT NOT NULL, 
    [CookTime] INT NOT NULL, 
    [AuthorId] INT NULL, 
    [EthnicId] INT NOT NULL, 
    [IsFavorite] BIT NOT NULL DEFAULT 0
)
