USE ThangLong
GO
/****** Object:  UserDefinedFunction [dbo].[ufn_sys_BravoEquations]    Script Date: 03/18/2015 17:10:04 ******/
CREATE FUNCTION [dbo].[TLU_sys_GenerateToKen](@Parameter [nvarchar](4000))
RETURNS [nvarchar](4000) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [TLU.Security].[TLU.Security.GenerateToken].[RandomToken]