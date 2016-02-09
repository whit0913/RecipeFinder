ALTER TABLE [dbo].[RecipeProcess]
	ADD CONSTRAINT [FK_RecipeProcess_ActionId]
	FOREIGN KEY (ActionId)
	REFERENCES [Action] (ActionId)
