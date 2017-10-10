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
ALTER PROCEDURE TransactionCrud
	@Operation	int,
	@Id int = null,
	@NombreDest varchar(255) = null,
	@Fecha Date =null,
	@IsFraud bit =null,
	@Palabra varchar(255) = null

AS
BEGIN
	If @Operation = 1
	BEGIN
		
		insert into Transaccion values (@NombreDest, @Fecha, @IsFraud)
		Select * from Transaccion where Id = SCOPE_IDENTITY()

	END

	IF @Operation = 2
	BEGIN
		select * from Transaccion where NombreDest like '%'+ @Palabra +'%'
	END

	IF @Operation = 3
	BEGIN
		select * from Transaccion where Fecha =@Palabra
	END

	IF @Operation = 4
	BEGIN
		select * from Transaccion where IsFraud = @Palabra
	END
END
GO
