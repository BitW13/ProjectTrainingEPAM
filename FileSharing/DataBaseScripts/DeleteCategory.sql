USE FileSharingDb;
GO
CREATE PROCEDURE [dbo].[DeleteCategory]
	@Id int
AS
BEGIN
	DELETE FROM dbo.Categories
	WHERE dbo.Categories.Id = @Id
END
GO
