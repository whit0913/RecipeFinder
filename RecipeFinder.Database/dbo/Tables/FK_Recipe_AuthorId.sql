ALTER TABLE [dbo].[Recipe]
	ADD CONSTRAINT [FK_Recipe_AuthorId]
	FOREIGN KEY (AuthorId)
	REFERENCES [Author] (AuthorId)
