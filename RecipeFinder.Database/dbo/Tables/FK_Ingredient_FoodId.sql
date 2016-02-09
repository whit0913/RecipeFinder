ALTER TABLE [dbo].[Ingredient]
	ADD CONSTRAINT [FK_Ingredient_FoodId]
	FOREIGN KEY (FoodId)
	REFERENCES [Food] (FoodId)
