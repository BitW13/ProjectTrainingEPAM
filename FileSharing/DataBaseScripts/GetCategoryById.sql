USE FileSharingDb;
GO
CREATE PROCEDURE [dbo].[GetCategoryById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.Categories
	WHERE dbo.Categories.Id = @Id
END
GO
