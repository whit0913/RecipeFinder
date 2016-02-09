ALTER TABLE [dbo].[Ingredient]
	ADD CONSTRAINT [FK_Ingredient_RecipeId]
	FOREIGN KEY (RecipeId)
	REFERENCES [Recipe] (RecipeId)
