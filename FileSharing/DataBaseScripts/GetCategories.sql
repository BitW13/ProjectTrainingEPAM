USE FileSharingDb;
GO
CREATE PROCEDURE [dbo].[GetCategories]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.Categories
END
GO
