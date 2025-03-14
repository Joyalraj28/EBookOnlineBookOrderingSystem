USE [EBookDB]
GO
/****** Object:  StoredProcedure [dbo].[Spr_GetOrderInfo]    Script Date: 6/15/2024 6:42:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Spr_GetOrderInfo]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT MO.id,
		   MO.price,
		   MO.paymenttype,
		   us.username,
		   us.email,
		   MO.paymentdate,
		   IIF(MO.Status= 1,'Complete',IIF(MO.Status = 2,'Pending','Cancel')) as Status
		   FROM MOrder MO LEFT JOIN Users us on MO.userid = us.id
END
