USE [FileSharingDb]
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 12/16/2018 10:43:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetUserById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.Users 
	WHERE dbo.Users.Id = @Id
END
