USE [master]
GO
/****** Object:  Database [PersonalBusinessManagement]    Script Date: 2022-06-21 12:54:00 PM ******/
CREATE DATABASE [PersonalBusinessManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PersonalBusinessManagement', FILENAME = N'C:\Users\NAYEL\PersonalBusinessManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PersonalBusinessManagement_log', FILENAME = N'C:\Users\NAYEL\PersonalBusinessManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PersonalBusinessManagement] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PersonalBusinessManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PersonalBusinessManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PersonalBusinessManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PersonalBusinessManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PersonalBusinessManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PersonalBusinessManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [PersonalBusinessManagement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PersonalBusinessManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PersonalBusinessManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PersonalBusinessManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PersonalBusinessManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PersonalBusinessManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PersonalBusinessManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PersonalBusinessManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PersonalBusinessManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PersonalBusinessManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PersonalBusinessManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PersonalBusinessManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PersonalBusinessManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PersonalBusinessManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PersonalBusinessManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PersonalBusinessManagement] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PersonalBusinessManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PersonalBusinessManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PersonalBusinessManagement] SET  MULTI_USER 
GO
ALTER DATABASE [PersonalBusinessManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PersonalBusinessManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PersonalBusinessManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PersonalBusinessManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PersonalBusinessManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PersonalBusinessManagement] SET QUERY_STORE = OFF
GO
USE [PersonalBusinessManagement]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [PersonalBusinessManagement]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2022-06-21 12:54:00 PM ******/
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
/****** Object:  Table [dbo].[Project]    Script Date: 2022-06-21 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1250) NULL,
	[Delivered] [bit] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220531025519_Initial', N'6.0.5')
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (1, N'VP Product Management', N'Glucocorticoid-remediable aldosteronism', 1)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (2, N'Librarian', N'Irritant contact dermatitis due to food in contact with skin', 0)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (3, N'Quality Engineer', N'Pathological fracture in other disease, left ulna, subsequent encounter for fracture with nonunion', 1)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (4, N'Analyst Programmer', N'Drowning and submersion due to unspecified watercraft sinking', 1)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (5, N'Account Coordinator', N'Burn of first degree of unspecified upper arm, subsequent encounter', 0)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (6, N'Budget/Accounting Analyst I', N'Enteropathic arthropathies, left shoulder', 1)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (7, N'Associate Professor', N'Heat exposure on board passenger ship, initial encounter', 0)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (8, N'Civil Engineer', N'Other recurrent vertebral dislocation, lumbar region', 0)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (9, N'Professor', N'Complete oblique atypical femoral fracture, left leg, subsequent encounter for fracture with delayed healing', 1)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (10, N'Senior Sales Associate', N'Military operations involving other destruction of aircraft', 1)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (11, N'Internal Auditor', N'Infective myositis, right hand', 1)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (12, N'Human Resources Manager', N'Pedestrian on skateboard injured in collision with other nonmotor vehicle in traffic accident, sequela', 1)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (13, N'Administrative Assistant II', N'Toxic effect of sulfur dioxide, intentional self-harm, subsequent encounter', 0)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (14, N'Media Manager I', N'Other osteoporosis with current pathological fracture, left ankle and foot, subsequent encounter for fracture with nonunion', 0)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (15, N'Statistician IV', N'Fracture of unspecified carpal bone, right wrist', 0)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (16, N'Cost Accountant', N'Intentional self-harm by hot household appliances, sequela', 0)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (17, N'Senior Cost Accountant', N'Infection and inflammatory reaction due to implanted electronic neurostimulator of spinal cord, electrode (lead)', 1)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (18, N'VP Accounting', N'Nondisplaced fracture of base of neck of unspecified femur, subsequent encounter for closed fracture with malunion', 1)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (19, N'Pharmacist', N'Other specified diabetes mellitus with other skin ulcer', 0)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (20, N'Technical Writer', N'Unspecified occupant of pick-up truck or van injured in collision with unspecified motor vehicles in traffic accident', 1)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (21, N'Financial Analyst', N'Contusion of eyeball and orbital tissues, unspecified eye, sequela', 1)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (22, N'Physical Therapy Assistant', N'Sprain of interphalangeal joint of unspecified great toe, sequela', 0)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (23, N'Quality Engineer', N'Unspecified fracture of patella', 0)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (24, N'Data Coordiator', N'Toxic effect of venom of other Australian snake, intentional self-harm', 0)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (25, N'Mechanical Systems Engineer', N'Malignant neoplasm of descended left testis', 1)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (26, N'Clinical Specialist', N'Anaplastic large cell lymphoma, ALK-negative, lymph nodes of head, face, and neck', 0)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (27, N'Payment Adjustment Coordinator', N'Strain of right Achilles tendon', 1)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (28, N'Design Engineer', N'Poisoning by local astringents and local detergents, undetermined, sequela', 0)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (29, N'Senior Cost Accountant', N'Toxic effects of unspecified organic solvent', 1)
INSERT [dbo].[Project] ([Id], [Name], [Description], [Delivered]) VALUES (30, N'Dental Hygienist', N'Displaced fracture of epiphysis (separation) (upper) of left femur, subsequent encounter for closed fracture with malunion', 0)
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
USE [master]
GO
ALTER DATABASE [PersonalBusinessManagement] SET  READ_WRITE 
GO
