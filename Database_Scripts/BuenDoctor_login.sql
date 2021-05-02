USE [MASTER]
GO
DROP DATABASE [BuenDoctorLogin]
CREATE DATABASE [BuenDoctorLogin]
GO
USE [BuenDoctorLogin]
GO
-------------------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [USER]
(
    [USER_ID] NVARCHAR(10) NOT NULL,
    [PASSWORD_HASH] VARBINARY(128) NULL,
    [PASSWORD_SALT] VARBINARY(128) NULL,
    [STATUS] BIT DEFAULT 1 NOT NULL,
    CONSTRAINT [USER_PK] PRIMARY KEY ([USER_ID]),
    CONSTRAINT [USER_STATUS_CK] CHECK([STATUS] = 1 OR [STATUS] = 0)
);
GO
SET ANSI_PADDING OFF
GO