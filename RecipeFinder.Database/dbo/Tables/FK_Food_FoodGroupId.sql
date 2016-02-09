ALTER TABLE [dbo].[Food]
	ADD CONSTRAINT [FK_Food_FoodGroupId]
	FOREIGN KEY (FoodGroupId)
	REFERENCES [FoodGroup] (FoodGroupId)
