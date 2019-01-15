USE [FileSharingDb]
GO
CREATE PROCEDURE [dbo].[GetUserRoleByName]
	@Name nvarchar(50)
AS
BEGIN
	SELECT * FROM dbo.UserRoles
	WHERE dbo.UserRoles.Name = @Name
END
