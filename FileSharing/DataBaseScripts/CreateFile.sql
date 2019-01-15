USE [FileSharingDb]
GO
CREATE PROCEDURE [dbo].[CreateFile]
	@Name nvarchar(50),
	@Size real,
	@Description nvarchar(MAX),
	@CategoryId int,
	@Url nvarchar(MAX),
	@Date smalldatetime,
	@IsPublic bit,
	@UserId int
AS
BEGIN
	INSERT INTO dbo.Files (Name, Size, Description, CategoryId, Url, Date, IsPublic, UserId)
	VALUES (@Name, @Size, @Description, @CategoryId, @Url, @Date, @IsPublic, @UserId)
END
GO
