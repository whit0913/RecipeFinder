CREATE TABLE [dbo].[Food]
(
	[FoodId] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(64) NOT NULL, 
    [Description] VARCHAR(256) NULL, 
    [FoodGroupId] INT NOT NULL
)
