CREATE TABLE [dbo].[Ingredient]
(
	[IngredientId] INT NOT NULL PRIMARY KEY, 
    [RecipeId] INT NOT NULL, 
    [FoodId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [UnitId] INT NOT NULL
)
