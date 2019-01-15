USE FileSharingDb;
GO
CREATE PROCEDURE [dbo].[UpdateUser]
	@Id int,
	@Login nvarchar(50),
	@Password nvarchar(50),
	@Email nvarchar(50),
	@UserRoleId int
AS
BEGIN
	UPDATE dbo.Users
	SET Login = @Login, Password = @Password, Email = @Email, UserRoleId = @UserRoleId
	WHERE dbo.Users.Id = @Id
END
GO
