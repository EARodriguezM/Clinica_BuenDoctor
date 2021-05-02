CREATE LOGIN [SHREK] WITH PASSWORD='dummy', CHECK_POLICY = OFF;
GO

USE master;
GO
DENY VIEW ANY DATABASE TO SHREK;
GO

USE master;
GO
ALTER AUTHORIZATION ON DATABASE::[BuenDoctorData] TO SHREK;
GO

USE master;
GO
ALTER AUTHORIZATION ON DATABASE::[BuenDoctorLogin] TO SHREK;
GO