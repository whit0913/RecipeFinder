CREATE TABLE [dbo].[RecipeProcess]
(
	[RecipeId] INT NOT NULL PRIMARY KEY, 
    [StepNumber] INT NOT NULL, 
    [RelatedStep] INT NULL DEFAULT NULL, 
    [ActionId] INT NULL DEFAULT NULL, 
    [IngredientId] INT NULL DEFAULT NULL, 
    [SpecialInstructions] VARCHAR(MAX) NULL DEFAULT NULL
)
