IF EXISTS (SELECT * FROM sysobjects WHERE name='SP_INSERT_POST') BEGIN
	DROP PROCEDURE SP_INSERT_POST
END
GO
CREATE PROCEDURE SP_INSERT_POST
	@ID		INT,
	@USER_ID		INT,
	@BODY nvarchar(4000),
	@TITLE nvarchar(500)
AS


INSERT INTO [Posts]
           ([Id]
		   ,[UserId]
           ,[Body]
           ,[Title])
     VALUES
          (@ID, @USER_ID, @BODY, @TITLE)