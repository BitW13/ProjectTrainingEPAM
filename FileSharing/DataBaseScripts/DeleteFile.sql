USE FileSharingDb;
GO
CREATE PROCEDURE [dbo].[DeleteFile]
	@Id int
AS
BEGIN
	DELETE FROM dbo.Files
	WHERE dbo.Files.Id = @Id
END
GO
