-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BookAddOrEdit]
	@BookID int,
	@Title varchar(50),
	@Author varchar(50),
	@Price int

AS

BEGIN
	SET NOCOUNT ON;

	IF @BookID=0
	BEGIN 
		INSERT INTO Books(Title,Author,Price)
		VALUES(@Title,@Author,@Price)
	END
	ELSE
	BEGIN 
		UPDATE Books
		SET
			Title=@Title,
			Author=@Author,
			Price=@Price
			WHERE BookID=@BookID
	END
END
GO
