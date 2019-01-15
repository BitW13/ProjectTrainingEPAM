USE FileSharingDb;
GO
CREATE PROCEDURE [dbo].[GetUserRoleById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.UserRoles
	WHERE dbo.UserRoles.Id = @Id
END
GO
