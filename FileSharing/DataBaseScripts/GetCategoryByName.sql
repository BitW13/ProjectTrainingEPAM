USE FileSharingDb;
GO
CREATE PROCEDURE [dbo].[GetCategoryByName]
	@Name nvarchar(50)
AS
BEGIN
	SELECT * FROM dbo.Categories
	WHERE dbo.Categories.Name = @Name
END
GO
