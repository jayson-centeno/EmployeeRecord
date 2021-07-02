DECLARE @dbname nvarchar(128)
SET @dbname = N'EmployeeRecord'

IF (NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = @dbname OR name = @dbname)))
BEGIN
	CREATE DATABASE [EmployeeRecord] 
	CONTAINMENT = NONE
	 ON  PRIMARY 
	( NAME = N'EmployeeRecord', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EmployeeRecord.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
	 LOG ON 
	( NAME = N'EmployeeRecord_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EmployeeRecord_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
	 WITH CATALOG_COLLATION = DATABASE_DEFAULT
END
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
BEGIN
	EXEC [EmployeeRecord].[dbo].[sp_fulltext_database] @action = 'enable'

	ALTER DATABASE [EmployeeRecord] SET ANSI_NULL_DEFAULT OFF 
	ALTER DATABASE [EmployeeRecord] SET ANSI_NULLS OFF 
	ALTER DATABASE [EmployeeRecord] SET ANSI_PADDING OFF 
	ALTER DATABASE [EmployeeRecord] SET ANSI_WARNINGS OFF 
	ALTER DATABASE [EmployeeRecord] SET ARITHABORT OFF 
	ALTER DATABASE [EmployeeRecord] SET AUTO_CLOSE OFF 
	ALTER DATABASE [EmployeeRecord] SET AUTO_SHRINK OFF 
	ALTER DATABASE [EmployeeRecord] SET AUTO_UPDATE_STATISTICS ON 
	ALTER DATABASE [EmployeeRecord] SET CURSOR_CLOSE_ON_COMMIT OFF 
	ALTER DATABASE [EmployeeRecord] SET CURSOR_DEFAULT  GLOBAL 
	ALTER DATABASE [EmployeeRecord] SET CONCAT_NULL_YIELDS_NULL OFF 
	ALTER DATABASE [EmployeeRecord] SET NUMERIC_ROUNDABORT OFF 
	ALTER DATABASE [EmployeeRecord] SET QUOTED_IDENTIFIER OFF 
	ALTER DATABASE [EmployeeRecord] SET RECURSIVE_TRIGGERS OFF 
	ALTER DATABASE [EmployeeRecord] SET  DISABLE_BROKER 
	ALTER DATABASE [EmployeeRecord] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
	ALTER DATABASE [EmployeeRecord] SET DATE_CORRELATION_OPTIMIZATION OFF 
	ALTER DATABASE [EmployeeRecord] SET TRUSTWORTHY OFF 
	ALTER DATABASE [EmployeeRecord] SET ALLOW_SNAPSHOT_ISOLATION OFF 
	ALTER DATABASE [EmployeeRecord] SET PARAMETERIZATION SIMPLE 
	ALTER DATABASE [EmployeeRecord] SET READ_COMMITTED_SNAPSHOT OFF 
	ALTER DATABASE [EmployeeRecord] SET HONOR_BROKER_PRIORITY OFF 
	ALTER DATABASE [EmployeeRecord] SET RECOVERY FULL 
	ALTER DATABASE [EmployeeRecord] SET  MULTI_USER 
	ALTER DATABASE [EmployeeRecord] SET PAGE_VERIFY CHECKSUM  
	ALTER DATABASE [EmployeeRecord] SET DB_CHAINING OFF 
	ALTER DATABASE [EmployeeRecord] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
	ALTER DATABASE [EmployeeRecord] SET TARGET_RECOVERY_TIME = 60 SECONDS 
	ALTER DATABASE [EmployeeRecord] SET DELAYED_DURABILITY = DISABLED 
	ALTER DATABASE [EmployeeRecord] SET QUERY_STORE = OFF
	ALTER DATABASE [EmployeeRecord] SET  READ_WRITE 

END
GO

USE [master]
GO

IF (SUSER_ID('EmployeeRecord') IS NULL)
BEGIN
	
	CREATE LOGIN [EmployeeRecord] WITH PASSWORD=N'EmployeeRecord@123', 
		DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
	ALTER SERVER ROLE [sysadmin] ADD MEMBER [EmployeeRecord]

END
GO

