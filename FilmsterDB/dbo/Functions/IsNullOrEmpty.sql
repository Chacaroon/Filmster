
CREATE function [dbo].[IsNullOrEmpty](@x varchar(max)) returns bit as
BEGIN
return iif(@x IS NOT NULL AND LEN(@x) > 0, 0, 1)
END