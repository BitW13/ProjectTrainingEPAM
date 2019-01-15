USE FileSharingDb;
GO
CREATE PROCEDURE [dbo].[DeleteUser]
	@Id int
AS
BEGIN
	DELETE FROM dbo.Users
	WHERE dbo.Users.Id = @Id
END
GO
