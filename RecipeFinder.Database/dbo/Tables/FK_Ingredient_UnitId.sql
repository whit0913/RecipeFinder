ALTER TABLE [dbo].[Ingredient]
	ADD CONSTRAINT [FK_Ingredient_UnitId]
	FOREIGN KEY (UnitId)
	REFERENCES [Unit] (UnitId)
