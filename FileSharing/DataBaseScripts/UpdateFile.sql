USE FileSharingDb;
GO
CREATE PROCEDURE [dbo].[UpdateFile]
	@Id int,
	@Name nvarchar(50),
	@Size real,
	@Description nvarchar(50),
	@CategoryId int,
	@Url nvarchar(MAX),
	@Date smalldatetime,
	@IsPublic bit,
	@UserId int
AS
BEGIN
	UPDATE dbo.Files
	SET Name = @Name,
		Size = @Size,
		Description = @Description,
		CategoryId = @CategoryId,
		Url = @Url,
		Date = @Date,
		IsPublic = @IsPublic,
		UserId = @UserId
	WHERE dbo.Files.Id = @Id
END
GO
