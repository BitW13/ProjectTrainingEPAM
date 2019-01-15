USE FileSharingDb;
GO
CREATE PROCEDURE [dbo].[GetUserByLogin] 
	@Login nvarchar(50)
AS
BEGIN
	SELECT * FROM dbo.Users
	WHERE dbo.Users.Login = @Login
END
GO
