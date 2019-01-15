USE FileSharingDb;
GO
CREATE PROCEDURE [dbo].[CreateUser]
	@Login nvarchar(50),
	@Password nvarchar(50),
	@Email nvarchar(50),
	@UserRoleId int
AS
BEGIN
	INSERT INTO dbo.Users (Login, Password, Email, UserRoleId)
	VALUES (@Login, @Password, @Email, @UserRoleId)
END
GO
