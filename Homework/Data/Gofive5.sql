USE [master]
GO
/****** Object:  Database [GofiveDB]    Script Date: 4/4/2024 12:48:10 AM ******/
CREATE DATABASE [GofiveDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GofiveDB', FILENAME = N'C:\Database_test\GofiveDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GofiveDB_log', FILENAME = N'C:\Database_test\GofiveDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GofiveDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GofiveDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GofiveDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GofiveDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GofiveDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GofiveDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GofiveDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [GofiveDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GofiveDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GofiveDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GofiveDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GofiveDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GofiveDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GofiveDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GofiveDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GofiveDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GofiveDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GofiveDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GofiveDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GofiveDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GofiveDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GofiveDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GofiveDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GofiveDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GofiveDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GofiveDB] SET  MULTI_USER 
GO
ALTER DATABASE [GofiveDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GofiveDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GofiveDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GofiveDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GofiveDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GofiveDB] SET QUERY_STORE = OFF
GO
USE [GofiveDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/4/2024 12:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddUsers]    Script Date: 4/4/2024 12:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddUsers](
	[userid] [nvarchar](450) NOT NULL,
	[firstname] [nvarchar](max) NOT NULL,
	[lastname] [nvarchar](max) NOT NULL,
	[email] [nvarchar](max) NOT NULL,
	[phone] [nvarchar](max) NULL,
	[username] [nvarchar](max) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[roleId] [nvarchar](450) NOT NULL,
	[permissionId] [nvarchar](450) NOT NULL,
	[createdate] [nvarchar](max) NULL,
 CONSTRAINT [PK_AddUsers] PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 4/4/2024 12:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[permissionId] [nvarchar](450) NOT NULL,
	[permissionName] [nvarchar](max) NOT NULL,
	[isReadable] [bit] NOT NULL,
	[isWritable] [bit] NOT NULL,
	[isDeletable] [bit] NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[permissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registers]    Script Date: 4/4/2024 12:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registers](
	[username] [nvarchar](450) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Registers] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 4/4/2024 12:48:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[roleId] [nvarchar](450) NOT NULL,
	[roleName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240403163320_inotial', N'8.0.2')
GO
INSERT [dbo].[AddUsers] ([userid], [firstname], [lastname], [email], [phone], [username], [password], [roleId], [permissionId], [createdate]) VALUES (N'1', N'William', N'Young', N'william.young@example.com', N'9876543210', N'williamyoung', N'williampass', N'role-tester', N'per-employee', N'03 Apr, 2024')
INSERT [dbo].[AddUsers] ([userid], [firstname], [lastname], [email], [phone], [username], [password], [roleId], [permissionId], [createdate]) VALUES (N'2', N'Olivia', N'Harris', N'olivia.harris@example.com', N'9876543210', N'oliviaharris', N'oliviapass', N'role-backend', N'per-employee', N'03 Apr, 2024')
INSERT [dbo].[AddUsers] ([userid], [firstname], [lastname], [email], [phone], [username], [password], [roleId], [permissionId], [createdate]) VALUES (N'3', N'James', N'Martin', N'james.martin@example.com', N'9876543210', N'jamesmartin', N'jamespass', N'role-fullstack', N'per-employee', N'03 Apr, 2024')
INSERT [dbo].[AddUsers] ([userid], [firstname], [lastname], [email], [phone], [username], [password], [roleId], [permissionId], [createdate]) VALUES (N'4', N'Charlotte', N'Anderson', N'charlotte.anderson@example.com', N'9876543210', N'charlotteanderson', N'charlottepass', N'role-pm', N'per-employee', N'03 Apr, 2024')
INSERT [dbo].[AddUsers] ([userid], [firstname], [lastname], [email], [phone], [username], [password], [roleId], [permissionId], [createdate]) VALUES (N'5', N'Daniel', N'Martinez', N'daniel.martinez@example.com', N'9876543210', N'danielmartinez', N'danielpass', N'role-fullstack', N'per-employee', N'03 Apr, 2024')
INSERT [dbo].[AddUsers] ([userid], [firstname], [lastname], [email], [phone], [username], [password], [roleId], [permissionId], [createdate]) VALUES (N'6', N'Mia', N'Taylor', N'mia.taylor@example.com', N'9876543210', N'miataylor', N'miapass', N'role-backend', N'per-employee', N'03 Apr, 2024')
INSERT [dbo].[AddUsers] ([userid], [firstname], [lastname], [email], [phone], [username], [password], [roleId], [permissionId], [createdate]) VALUES (N'7', N'Jane', N'Smith', N'jane.smith@example.com', N'0987654321', N'janesmith', N'securepass', N'role-pm', N'per-admin', N'03 Apr, 2024')
INSERT [dbo].[AddUsers] ([userid], [firstname], [lastname], [email], [phone], [username], [password], [roleId], [permissionId], [createdate]) VALUES (N'8', N'Alice', N'Johnson', N'alice.johnson@example.com', N'9876543210', N'alicejohnson', N'strongpassword', N'role-tester', N'per-employee', N'03 Apr, 2024')
INSERT [dbo].[AddUsers] ([userid], [firstname], [lastname], [email], [phone], [username], [password], [roleId], [permissionId], [createdate]) VALUES (N'9', N'Bob', N'Smith', N'bob.smith@example.com', N'1234567890', N'bobsmith', N'pass123', N'role-fullstack', N'per-admin', N'03 Apr, 2024')
GO
INSERT [dbo].[Permissions] ([permissionId], [permissionName], [isReadable], [isWritable], [isDeletable]) VALUES (N'per-admin', N'Admin', 1, 0, 0)
INSERT [dbo].[Permissions] ([permissionId], [permissionName], [isReadable], [isWritable], [isDeletable]) VALUES (N'per-employee', N'Employee', 1, 0, 0)
INSERT [dbo].[Permissions] ([permissionId], [permissionName], [isReadable], [isWritable], [isDeletable]) VALUES (N'per-superadmin', N'Super Admin', 1, 1, 1)
GO
INSERT [dbo].[Roles] ([roleId], [roleName]) VALUES (N'role-backend', N'Back-end Developer')
INSERT [dbo].[Roles] ([roleId], [roleName]) VALUES (N'role-frontend', N'Front-end Developer')
INSERT [dbo].[Roles] ([roleId], [roleName]) VALUES (N'role-fullstack', N'Full Stack Developer')
INSERT [dbo].[Roles] ([roleId], [roleName]) VALUES (N'role-pm', N'Project Manager')
INSERT [dbo].[Roles] ([roleId], [roleName]) VALUES (N'role-tester', N'Tester')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AddUsers_permissionId]    Script Date: 4/4/2024 12:48:10 AM ******/
CREATE NONCLUSTERED INDEX [IX_AddUsers_permissionId] ON [dbo].[AddUsers]
(
	[permissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AddUsers_roleId]    Script Date: 4/4/2024 12:48:10 AM ******/
CREATE NONCLUSTERED INDEX [IX_AddUsers_roleId] ON [dbo].[AddUsers]
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AddUsers]  WITH CHECK ADD  CONSTRAINT [FK_AddUsers_Permissions_permissionId] FOREIGN KEY([permissionId])
REFERENCES [dbo].[Permissions] ([permissionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AddUsers] CHECK CONSTRAINT [FK_AddUsers_Permissions_permissionId]
GO
ALTER TABLE [dbo].[AddUsers]  WITH CHECK ADD  CONSTRAINT [FK_AddUsers_Roles_roleId] FOREIGN KEY([roleId])
REFERENCES [dbo].[Roles] ([roleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AddUsers] CHECK CONSTRAINT [FK_AddUsers_Roles_roleId]
GO
USE [master]
GO
ALTER DATABASE [GofiveDB] SET  READ_WRITE 
GO
