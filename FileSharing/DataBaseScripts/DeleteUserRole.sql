USE FileSharingDb;
GO
CREATE PROCEDURE [dbo].[DeleteUserRole]
	@Id int
AS
BEGIN
	DELETE FROM dbo.UserRoles
	WHERE dbo.UserRoles.Id = @Id
END
GO
