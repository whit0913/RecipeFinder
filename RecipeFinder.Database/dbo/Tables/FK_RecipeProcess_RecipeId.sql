ALTER TABLE [dbo].[RecipeProcess]
	ADD CONSTRAINT [FK_RecipeProcess_RecipeId]
	FOREIGN KEY (RecipeId)
	REFERENCES [Recipe] (RecipeId)
