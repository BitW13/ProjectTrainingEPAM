USE FileSharingDb;
GO
CREATE PROCEDURE [dbo].[GetFileById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.Files 
	WHERE dbo.Files.Id = @Id
END
GO
