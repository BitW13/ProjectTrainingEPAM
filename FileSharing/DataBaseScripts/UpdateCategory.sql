USE FileSharingDb;
GO
CREATE PROCEDURE [dbo].[UpdateCaregory]
	@Id int,
	@Name nvarchar(50)
AS
BEGIN
	UPDATE dbo.Categories
	SET Name = @Name
	Where dbo.Categories.Id = @Id
END
GO
