USE [EBookDB]
GO
/****** Object:  StoredProcedure [dbo].[Spr_GetTOrderInfo]    Script Date: 6/15/2024 5:46:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Spr_GetTOrderInfo] 
	-- Add the parameters for the stored procedure here
	@morderID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Torder.*,
		   book.bookimg,
		   book.Name as BookName
	FROM TOrder Torder LEFT JOIN Book book 
	ON Torder.bookid =book.id where morderid = @morderID
END
