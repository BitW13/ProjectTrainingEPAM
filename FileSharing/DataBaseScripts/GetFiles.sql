USE [FileSharingDb]
GO
/****** Object:  StoredProcedure [dbo].[GetFiles]    Script Date: 12/31/2018 2:30:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetFiles]
AS
BEGIN
	SET NOCOUNT ON
	SELECT * FROM dbo.Files
END
