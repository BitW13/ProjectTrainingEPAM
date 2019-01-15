USE FileSharingDb;
GO
CREATE PROCEDURE [dbo].[CreateUserRole] 
	@Name nvarchar(50)
AS
BEGIN
	INSERT INTO dbo.UserRoles (Name)
	VALUES (@Name)
END
GO
