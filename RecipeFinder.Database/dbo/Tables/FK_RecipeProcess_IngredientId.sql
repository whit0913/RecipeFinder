ALTER TABLE [dbo].[RecipeProcess]
	ADD CONSTRAINT [FK_RecipeProcess_IngredientId]
	FOREIGN KEY (IngredientId)
	REFERENCES [Ingredient] (IngredientId)
