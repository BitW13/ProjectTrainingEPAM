USE [FileSharingDb]
GO
/****** Object:  StoredProcedure [dbo].[CreateCategory]    Script Date: 12/16/2018 11:14:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[CreateCategory]
	@Name nvarchar(50)
AS
BEGIN
	INSERT INTO dbo.Categories (Name)
	VALUES (@Name);
END
