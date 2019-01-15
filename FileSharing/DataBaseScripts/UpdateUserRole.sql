USE FileSharingDb;
GO
CREATE PROCEDURE [dbo].[UpdateUserRole]
	@Id int,
	@Name nvarchar(50)
AS
BEGIN
	UPDATE dbo.UserRoles
	SET Name = @Name
	WHERE dbo.UserRoles.Id = @Id
END
GO
