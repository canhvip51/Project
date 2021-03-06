USE [master]
GO
/****** Object:  Database [SHOESSHOP]    Script Date: 7/3/2021 1:03:12 PM ******/
CREATE DATABASE [SHOESSHOP] ON  PRIMARY 
( NAME = N'SHOESSHOP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL2008\MSSQL\DATA\SHOESSHOP.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SHOESSHOP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL2008\MSSQL\DATA\SHOESSHOP_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SHOESSHOP] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SHOESSHOP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SHOESSHOP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SHOESSHOP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SHOESSHOP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SHOESSHOP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SHOESSHOP] SET ARITHABORT OFF 
GO
ALTER DATABASE [SHOESSHOP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SHOESSHOP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SHOESSHOP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SHOESSHOP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SHOESSHOP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SHOESSHOP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SHOESSHOP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SHOESSHOP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SHOESSHOP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SHOESSHOP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SHOESSHOP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SHOESSHOP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SHOESSHOP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SHOESSHOP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SHOESSHOP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SHOESSHOP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SHOESSHOP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SHOESSHOP] SET RECOVERY FULL 
GO
ALTER DATABASE [SHOESSHOP] SET  MULTI_USER 
GO
ALTER DATABASE [SHOESSHOP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SHOESSHOP] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SHOESSHOP', N'ON'
GO
USE [SHOESSHOP]
GO
/****** Object:  User [tuananh]    Script Date: 7/3/2021 1:03:12 PM ******/
CREATE USER [tuananh] FOR LOGIN [tuananh] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [sushop]    Script Date: 7/3/2021 1:03:12 PM ******/
CREATE USER [sushop] FOR LOGIN [sushop] WITH DEFAULT_SCHEMA=[dbo]
GO
sys.sp_addrolemember @rolename = N'db_owner', @membername = N'tuananh'
GO
sys.sp_addrolemember @rolename = N'db_owner', @membername = N'sushop'
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 7/3/2021 1:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsDelete] [int] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 7/3/2021 1:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NULL,
	[Amount] [int] NULL,
	[Status] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CookieId] [int] NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Config]    Script Date: 7/3/2021 1:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Config](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_Config] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cookie]    Script Date: 7/3/2021 1:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cookie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KeyCode] [nvarchar](max) NULL,
	[ExpiredDate] [datetime] NULL,
 CONSTRAINT [PK_Cookie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Import]    Script Date: 7/3/2021 1:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Import](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Status] [int] NULL,
	[ImportUnitId] [int] NULL,
 CONSTRAINT [PK_Import] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImportDetail]    Script Date: 7/3/2021 1:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImportId] [int] NULL,
	[WarehouseId] [int] NULL,
	[Amount] [int] NULL,
	[Price] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_ImportDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImportUnit]    Script Date: 7/3/2021 1:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportUnit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[IsDelete] [int] NULL,
	[IsUpdate] [datetime] NULL,
	[Phone] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_ImportUnit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 7/3/2021 1:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Total] [int] NULL,
	[Discount] [int] NULL,
	[SaleId] [int] NULL,
	[Code] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[AddressTo] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[BuyerName] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
	[KeyCode] [nvarchar](max) NULL,
	[ProvinceId] [int] NULL,
	[CustomerPay] [int] NULL,
	[Refuse] [nvarchar](max) NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 7/3/2021 1:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[WarehouseId] [int] NULL,
	[Price] [int] NULL,
	[Amount] [int] NULL,
	[IsDelete] [int] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 7/3/2021 1:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[Describe] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[IsDelete] [int] NULL,
	[Discount] [int] NULL,
	[Price] [int] NULL,
	[Type] [int] NULL,
	[AvatarUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImg]    Script Date: 7/3/2021 1:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImg](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [nvarchar](max) NULL,
	[ProductId] [int] NULL,
	[Color] [nvarchar](max) NULL,
	[IsDelete] [int] NULL,
	[Status] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_ProductImg] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 7/3/2021 1:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KeyCode] [nvarchar](max) NULL,
	[ExpiredDate] [datetime] NULL,
	[Amount] [int] NULL,
	[StartDate] [datetime] NULL,
	[Discount] [int] NULL,
	[IsDelete] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Promotion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Province]    Script Date: 7/3/2021 1:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Province](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Province] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Size]    Script Date: 7/3/2021 1:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[US] [float] NULL,
	[VN] [float] NULL,
	[UK] [float] NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_Size] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 7/3/2021 1:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UrlFile] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[IsDelete] [int] NULL,
	[Status] [int] NULL,
	[OrderNumber] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Slide] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/3/2021 1:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Role] [int] NULL,
	[Status] [int] NULL,
	[IsDelete] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[FullName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[ProviceId] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 7/3/2021 1:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [int] NULL,
	[SizeId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[Status] [int] NULL,
	[IsDelete] [int] NULL,
	[ProductImgId] [int] NULL,
	[Discount] [int] NULL,
	[Code] [nvarchar](max) NULL,
	[Sold] [int] NULL,
 CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([Id], [Name], [IsDelete], [CreateDate]) VALUES (1, N'Adidas', NULL, CAST(N'2021-05-12T17:22:40.883' AS DateTime))
INSERT [dbo].[Brand] ([Id], [Name], [IsDelete], [CreateDate]) VALUES (2, N'Nike', NULL, CAST(N'2021-05-12T17:22:49.420' AS DateTime))
INSERT [dbo].[Brand] ([Id], [Name], [IsDelete], [CreateDate]) VALUES (3, N'Converse', NULL, CAST(N'2021-05-12T17:23:16.393' AS DateTime))
INSERT [dbo].[Brand] ([Id], [Name], [IsDelete], [CreateDate]) VALUES (5, N'Puma', NULL, CAST(N'2021-05-17T14:02:45.110' AS DateTime))
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([Id], [WarehouseId], [Amount], [Status], [CreateDate], [UpdateDate], [CookieId]) VALUES (10, 20, 1, 1, CAST(N'2021-06-13T19:58:37.547' AS DateTime), NULL, 8)
INSERT [dbo].[Cart] ([Id], [WarehouseId], [Amount], [Status], [CreateDate], [UpdateDate], [CookieId]) VALUES (15, 5, 1, 1, CAST(N'2021-07-01T09:09:01.720' AS DateTime), NULL, 12)
INSERT [dbo].[Cart] ([Id], [WarehouseId], [Amount], [Status], [CreateDate], [UpdateDate], [CookieId]) VALUES (16, 2, 2, 1, CAST(N'2021-07-01T09:33:50.927' AS DateTime), CAST(N'2021-07-01T09:44:14.883' AS DateTime), 13)
INSERT [dbo].[Cart] ([Id], [WarehouseId], [Amount], [Status], [CreateDate], [UpdateDate], [CookieId]) VALUES (17, 3, 1, 1, CAST(N'2021-07-01T10:10:23.043' AS DateTime), CAST(N'2021-07-01T10:34:50.690' AS DateTime), 14)
INSERT [dbo].[Cart] ([Id], [WarehouseId], [Amount], [Status], [CreateDate], [UpdateDate], [CookieId]) VALUES (18, 10, 2, 1, CAST(N'2021-07-01T10:27:32.340' AS DateTime), CAST(N'2021-07-01T10:27:41.513' AS DateTime), 15)
INSERT [dbo].[Cart] ([Id], [WarehouseId], [Amount], [Status], [CreateDate], [UpdateDate], [CookieId]) VALUES (20, 19, 2, 1, CAST(N'2021-07-01T15:27:56.620' AS DateTime), CAST(N'2021-07-01T15:47:31.663' AS DateTime), 17)
INSERT [dbo].[Cart] ([Id], [WarehouseId], [Amount], [Status], [CreateDate], [UpdateDate], [CookieId]) VALUES (25, 21, 1, 1, CAST(N'2021-07-01T21:56:53.117' AS DateTime), NULL, 20)
INSERT [dbo].[Cart] ([Id], [WarehouseId], [Amount], [Status], [CreateDate], [UpdateDate], [CookieId]) VALUES (26, 21, 1, 1, CAST(N'2021-07-01T21:58:25.070' AS DateTime), NULL, 21)
INSERT [dbo].[Cart] ([Id], [WarehouseId], [Amount], [Status], [CreateDate], [UpdateDate], [CookieId]) VALUES (30, 21, 1, 1, CAST(N'2021-07-01T22:03:44.977' AS DateTime), NULL, 22)
INSERT [dbo].[Cart] ([Id], [WarehouseId], [Amount], [Status], [CreateDate], [UpdateDate], [CookieId]) VALUES (31, 9, 1, 1, CAST(N'2021-07-01T22:16:10.807' AS DateTime), NULL, 21)
INSERT [dbo].[Cart] ([Id], [WarehouseId], [Amount], [Status], [CreateDate], [UpdateDate], [CookieId]) VALUES (32, 11, 1, 1, CAST(N'2021-07-01T22:16:16.237' AS DateTime), NULL, 21)
INSERT [dbo].[Cart] ([Id], [WarehouseId], [Amount], [Status], [CreateDate], [UpdateDate], [CookieId]) VALUES (38, 8, 3, 1, CAST(N'2021-07-02T23:03:59.043' AS DateTime), CAST(N'2021-07-02T23:07:28.063' AS DateTime), 25)
SET IDENTITY_INSERT [dbo].[Cart] OFF
GO
SET IDENTITY_INSERT [dbo].[Config] ON 

INSERT [dbo].[Config] ([Id], [Name], [Value]) VALUES (1, N'TIMEOUT_COOKIE_MINUSTE', N'30')
INSERT [dbo].[Config] ([Id], [Name], [Value]) VALUES (2, N'TIMEOUT_COOKIE_HOURS', N'1')
INSERT [dbo].[Config] ([Id], [Name], [Value]) VALUES (3, N'DEFAULT_PASS', N'123456')
SET IDENTITY_INSERT [dbo].[Config] OFF
GO
SET IDENTITY_INSERT [dbo].[Cookie] ON 

INSERT [dbo].[Cookie] ([Id], [KeyCode], [ExpiredDate]) VALUES (8, N'0fcaefe3-8be6-40d0-96da-810f1086cb2c', CAST(N'2021-06-13T20:58:37.547' AS DateTime))
INSERT [dbo].[Cookie] ([Id], [KeyCode], [ExpiredDate]) VALUES (12, N'f7c0e81f-b7a1-4438-930a-554d8b150955', CAST(N'2021-07-01T10:09:01.720' AS DateTime))
INSERT [dbo].[Cookie] ([Id], [KeyCode], [ExpiredDate]) VALUES (13, N'0ebbb3dd-7ca9-41df-a3bc-1fb38f09b4d2', CAST(N'2021-07-01T10:44:14.883' AS DateTime))
INSERT [dbo].[Cookie] ([Id], [KeyCode], [ExpiredDate]) VALUES (14, N'3269c0f8-c61b-49dc-9902-c5f4b3c41bc6', CAST(N'2021-07-01T11:34:50.673' AS DateTime))
INSERT [dbo].[Cookie] ([Id], [KeyCode], [ExpiredDate]) VALUES (15, N'284574e9-9b1b-4185-81bd-bc6f3ee7da48', CAST(N'2021-07-01T11:27:41.493' AS DateTime))
INSERT [dbo].[Cookie] ([Id], [KeyCode], [ExpiredDate]) VALUES (17, N'4cdf5b4b-5cb1-4ba5-b5b9-f4a94293097b', CAST(N'2021-07-01T16:47:31.637' AS DateTime))
INSERT [dbo].[Cookie] ([Id], [KeyCode], [ExpiredDate]) VALUES (20, N'953af99f-1c39-4097-a3a5-7f299ba5efea', CAST(N'2021-07-01T22:56:53.113' AS DateTime))
INSERT [dbo].[Cookie] ([Id], [KeyCode], [ExpiredDate]) VALUES (21, N'0d2fbe7e-c346-46b0-b086-115ea605ce26', CAST(N'2021-07-01T23:16:16.237' AS DateTime))
INSERT [dbo].[Cookie] ([Id], [KeyCode], [ExpiredDate]) VALUES (22, N'1cae59b8-69d3-4452-b17c-721b02955cec', CAST(N'2021-07-01T23:03:44.977' AS DateTime))
INSERT [dbo].[Cookie] ([Id], [KeyCode], [ExpiredDate]) VALUES (25, N'01dc8bf3-36c6-498e-a397-33bed5d7442f', CAST(N'2021-07-03T00:07:28.047' AS DateTime))
SET IDENTITY_INSERT [dbo].[Cookie] OFF
GO
SET IDENTITY_INSERT [dbo].[Import] ON 

INSERT [dbo].[Import] ([Id], [Price], [CreateDate], [Status], [ImportUnitId]) VALUES (1, 9950000, CAST(N'2021-06-10T10:41:03.027' AS DateTime), 1, 3)
INSERT [dbo].[Import] ([Id], [Price], [CreateDate], [Status], [ImportUnitId]) VALUES (2, 10200000, CAST(N'2021-06-10T10:56:23.377' AS DateTime), 1, 2)
INSERT [dbo].[Import] ([Id], [Price], [CreateDate], [Status], [ImportUnitId]) VALUES (3, 2450000, CAST(N'2021-06-10T11:06:36.517' AS DateTime), 1, 3)
INSERT [dbo].[Import] ([Id], [Price], [CreateDate], [Status], [ImportUnitId]) VALUES (4, 1320000, CAST(N'2021-06-10T11:16:53.333' AS DateTime), 1, 3)
INSERT [dbo].[Import] ([Id], [Price], [CreateDate], [Status], [ImportUnitId]) VALUES (5, 1320000, CAST(N'2021-06-10T11:17:49.763' AS DateTime), 1, 3)
INSERT [dbo].[Import] ([Id], [Price], [CreateDate], [Status], [ImportUnitId]) VALUES (6, 2700000, CAST(N'2021-06-10T11:20:45.760' AS DateTime), 1, 2)
INSERT [dbo].[Import] ([Id], [Price], [CreateDate], [Status], [ImportUnitId]) VALUES (7, 550000, CAST(N'2021-06-16T11:22:12.033' AS DateTime), 1, 3)
INSERT [dbo].[Import] ([Id], [Price], [CreateDate], [Status], [ImportUnitId]) VALUES (10, 4900000, CAST(N'2021-07-01T20:08:55.737' AS DateTime), 1, 3)
INSERT [dbo].[Import] ([Id], [Price], [CreateDate], [Status], [ImportUnitId]) VALUES (11, 9500000, CAST(N'2021-07-01T22:23:05.307' AS DateTime), 1, 3)
INSERT [dbo].[Import] ([Id], [Price], [CreateDate], [Status], [ImportUnitId]) VALUES (12, 5000000, CAST(N'2021-07-02T22:51:16.247' AS DateTime), 1, 3)
SET IDENTITY_INSERT [dbo].[Import] OFF
GO
SET IDENTITY_INSERT [dbo].[ImportDetail] ON 

INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (1, 1, 8, 2, 700000, CAST(N'2021-06-10T10:40:34.440' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (2, 1, 7, 3, 1050000, CAST(N'2021-06-10T10:40:36.270' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (3, 1, 6, 4, 1400000, CAST(N'2021-06-10T10:40:36.270' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (4, 1, 5, 4, 1600000, CAST(N'2021-06-10T10:40:36.270' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (5, 1, 4, 3, 1200000, CAST(N'2021-06-10T10:40:36.270' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (6, 1, 3, 3, 1200000, CAST(N'2021-06-10T10:40:36.270' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (7, 1, 2, 2, 800000, CAST(N'2021-06-10T10:40:36.270' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (8, 1, 1, 5, 2000000, CAST(N'2021-06-10T10:40:36.270' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (9, 2, 18, 1, 400000, CAST(N'2021-06-10T10:56:23.377' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (10, 2, 17, 5, 2000000, CAST(N'2021-06-10T10:56:23.377' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (11, 2, 16, 3, 1200000, CAST(N'2021-06-10T10:56:23.377' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (12, 2, 15, 4, 1600000, CAST(N'2021-06-10T10:56:23.377' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (13, 2, 14, 3, 1200000, CAST(N'2021-06-10T10:56:23.377' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (14, 2, 13, 2, 800000, CAST(N'2021-06-10T10:56:23.377' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (15, 2, 12, 1, 300000, CAST(N'2021-06-10T10:56:23.377' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (16, 2, 11, 3, 900000, CAST(N'2021-06-10T10:56:23.377' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (17, 2, 10, 4, 1200000, CAST(N'2021-06-10T10:56:23.377' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (18, 2, 9, 2, 600000, CAST(N'2021-06-10T10:56:23.377' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (19, 3, 6, 3, 1050000, CAST(N'2021-06-10T11:06:36.517' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (20, 3, 8, 4, 1400000, CAST(N'2021-06-10T11:06:36.517' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (21, 4, 19, 3, 1200000, CAST(N'2021-06-10T11:16:53.333' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (22, 4, 6, 3, 120000, CAST(N'2021-06-10T11:16:53.333' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (23, 5, 19, 3, 1200000, CAST(N'2021-06-10T11:17:49.763' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (24, 5, 6, 3, 120000, CAST(N'2021-06-10T11:17:49.763' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (25, 6, 21, 4, 1200000, CAST(N'2021-06-10T11:20:45.760' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (26, 6, 20, 2, 600000, CAST(N'2021-06-10T11:20:45.760' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (27, 6, 10, 3, 900000, CAST(N'2021-06-10T11:20:45.760' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (28, 7, 22, 2, 550000, CAST(N'2021-06-16T11:22:12.033' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (29, 10, 27, 3, 2400000, CAST(N'2021-07-01T20:08:55.737' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (30, 10, 26, 2, 1500000, CAST(N'2021-07-01T20:08:55.737' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (31, 10, 25, 3, 1000000, CAST(N'2021-07-01T20:08:55.737' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (32, 11, 32, 4, 2000000, CAST(N'2021-07-01T22:23:05.307' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (33, 11, 31, 5, 2500000, CAST(N'2021-07-01T22:23:05.307' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (34, 11, 30, 5, 2500000, CAST(N'2021-07-01T22:23:05.307' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (35, 11, 25, 5, 2500000, CAST(N'2021-07-01T22:23:05.307' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (36, 12, 35, 2, 1500000, CAST(N'2021-07-02T22:51:16.247' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (37, 12, 34, 4, 2500000, CAST(N'2021-07-02T22:51:16.247' AS DateTime), 1)
INSERT [dbo].[ImportDetail] ([Id], [ImportId], [WarehouseId], [Amount], [Price], [CreateDate], [Status]) VALUES (38, 12, 33, 2, 1000000, CAST(N'2021-07-02T22:51:16.247' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[ImportDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[ImportUnit] ON 

INSERT [dbo].[ImportUnit] ([Id], [Address], [CreateDate], [IsDelete], [IsUpdate], [Phone], [Name]) VALUES (1, N'Tầng 4 - Số 12 Ngõ 12 Phạm Tuấn Tài - Cầu Giấy - Hà Nội', CAST(N'2021-05-13T15:42:15.433' AS DateTime), NULL, NULL, N'0977399844          ', N'TUẤN LINH - XƯỞNG GIÀY')
INSERT [dbo].[ImportUnit] ([Id], [Address], [CreateDate], [IsDelete], [IsUpdate], [Phone], [Name]) VALUES (2, N'Số 37, ngõ 16 Hoàng Cầu, Đống Đa, Hà Nội', CAST(N'2021-05-13T15:47:49.857' AS DateTime), NULL, NULL, N'2435190744          ', N'NHẬP HÀNG TRUNG QUỐC')
INSERT [dbo].[ImportUnit] ([Id], [Address], [CreateDate], [IsDelete], [IsUpdate], [Phone], [Name]) VALUES (3, N'Số 87 Nguyễn Văn Trỗi - Thanh Xuân - Hà Nội', CAST(N'2021-05-13T15:51:40.673' AS DateTime), NULL, CAST(N'2021-06-01T15:11:06.873' AS DateTime), N'08535323125         ', N'ĐẶT HÀNG QUẢNG CHÂU')
SET IDENTITY_INSERT [dbo].[ImportUnit] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (1, 2930000, 0, 3, N'SHOESSHOP202106101424387057', 2, CAST(N'2021-06-10T14:24:33.770' AS DateTime), NULL, N'Hoàng Mai, Hà Nội', N'0965713472', N'Lê Cảnh', NULL, NULL, 1, 0, NULL, 1)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (2, 5280000, 0, 3, N'SHOESSHOP202106101434105158', 5, CAST(N'2021-06-10T14:34:10.770' AS DateTime), CAST(N'2021-06-10T14:48:07.130' AS DateTime), N'Hoàng Mai Hà Nội', N'0965713472', N'Lê Cảnh', NULL, NULL, 1, 0, NULL, 1)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (3, 2930000, 0, NULL, N'SHOESSHOP202106101520126650', 1, CAST(N'2021-06-10T15:20:12.037' AS DateTime), NULL, N'Hoàng Mai Hà Nội', N'0965713472', N'Cảnh Lê', N'Giao thứ 7 chủ nhật', NULL, 1, 0, NULL, 1)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (4, 5280000, 0, NULL, N'SHOESSHOP202106101529216957', 3, CAST(N'2021-06-10T15:29:21.817' AS DateTime), CAST(N'2021-06-10T15:56:43.217' AS DateTime), N'Tây Sơn Đống Đa', N'0965713472', N'Cảnh Lê', NULL, NULL, 1, 0, NULL, 2)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (5, 2930000, 0, NULL, N'SHOESSHOP202106101531449163', 1, CAST(N'2021-06-10T15:31:44.603' AS DateTime), NULL, N'Nguyễn Khang Cầu Giấy', N'0123445789', N'Cảnh Lê', NULL, NULL, 1, 0, NULL, 1)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (6, 5280000, 0, NULL, N'SHOESSHOP202106101534568551', 3, CAST(N'2021-06-10T15:34:56.687' AS DateTime), CAST(N'2021-06-10T15:46:48.260' AS DateTime), N'Kim Giang', N'0965713472', N'Cảnh Lê', NULL, NULL, 1, 0, NULL, 1)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (7, 11405000, 0, NULL, N'SHOESSHOP202106101606008564', 1, CAST(N'2021-06-10T16:06:00.393' AS DateTime), CAST(N'2021-06-21T10:32:51.993' AS DateTime), N'Hoàng Mai Hà Nội', N'0123445789', N'Lê Thắng', NULL, NULL, 1, 0, NULL, 1)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (9, 2930000, 0, 3, N'SHOESSHOP202106102316081080', 2, CAST(N'2021-06-10T23:16:06.893' AS DateTime), NULL, N'Hoàng Mai Hà Nội', N'0123445789', N'Cảnh Lê', NULL, NULL, 1, 0, NULL, 1)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (10, 2930000, 0, 3, N'SHOESSHOP202106102323441668', 5, CAST(N'2021-06-10T23:23:44.153' AS DateTime), NULL, N'Nguyễn Khang Cầu Giấy', N'0123445789', N'Cảnh Lê', NULL, NULL, 1, 3000000, NULL, 3)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (11, 3240000, 0, NULL, N'SHOESSHOP202106110009433888', 5, CAST(N'2021-06-11T00:09:43.123' AS DateTime), CAST(N'2021-06-14T01:37:28.690' AS DateTime), N'Kim Giang', N'0123445789', N'Cảnh Lê', NULL, NULL, 1, 0, NULL, 2)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (12, 0, 0, NULL, N'SHOESSHOP202106132009148973', 3, CAST(N'2021-06-13T20:09:14.927' AS DateTime), CAST(N'2021-06-13T20:16:02.823' AS DateTime), N'Hà Nội', N'0362670380', N'Cảnh Lê', NULL, NULL, 1, 0, NULL, 1)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (13, 5174000, 0, 3, N'SHOESSHOP202106132016448905', 2, CAST(N'2021-06-13T20:16:44.240' AS DateTime), NULL, N'Hà Nội', N'0362670380', N'Cảnh Lê', NULL, NULL, 1, 0, NULL, 1)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (14, 3175000, 0, 3, N'SHOESSHOP202106140138352269', 5, CAST(N'2021-06-14T01:38:35.217' AS DateTime), CAST(N'2021-06-14T14:58:37.630' AS DateTime), N'Vĩnh Phúc', N'0965713472', N'Lê Thắng', NULL, NULL, 26, 3200000, NULL, 3)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (15, 9107000, 0, NULL, N'SHOESSHOP202106220031564645', 3, CAST(N'2021-06-22T00:31:56.700' AS DateTime), CAST(N'2021-07-01T09:17:56.770' AS DateTime), N'Hoàng Mai Hà Nội', N'0965713472', N'Lê Thắng Cảnh', N'Giao giờ hành chính', NULL, 1, 0, NULL, 1)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (16, 5221000, 10, NULL, N'SHOESSHOP202107011522289915', 3, CAST(N'2021-07-01T15:22:28.227' AS DateTime), CAST(N'2021-07-01T15:39:23.647' AS DateTime), N'Hà Nội', N'0987654321', N'Lê Lê', N'Nhận hàng vào thứ 2', N'DISCOUNT', 1, 0, NULL, 1)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (17, 5222000, 10, NULL, N'SHOESSHOP202107011705163045', 3, CAST(N'2021-07-01T17:05:17.687' AS DateTime), CAST(N'2021-07-01T19:57:04.367' AS DateTime), N'Hà Nội', N'0988654321', N'Minh Nghĩa', N' Nhận hàng tại Mễ Trì', N'DISCOUNT', 1, 0, NULL, 1)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (18, 7925000, 13, NULL, N'SHOESSHOP202107012021482061', 1, CAST(N'2021-07-01T20:21:48.453' AS DateTime), NULL, N'Số nhà 199, đường Sơn La, thành phố Điện Biên không phải Lào Cai', N'0949288977', N'Michael Jáck Sì Trum', N'Hê lô', N'SAYHELLO', 10, 0, NULL, 2)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (19, 5820000, 0, NULL, N'SHOESSHOP202107022106502327', 5, CAST(N'2021-07-02T21:06:50.863' AS DateTime), CAST(N'2021-07-02T22:54:14.517' AS DateTime), N'Hà Nội', N'0967325167', N'Khải Trịnh', NULL, NULL, 1, 0, NULL, 1)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (20, 6384000, 0, NULL, N'SHOESSHOP202107022109101265', 3, CAST(N'2021-07-02T21:09:10.610' AS DateTime), CAST(N'2021-07-02T22:48:46.157' AS DateTime), N'Hoàng Mai, Hà Nội', N'0342214123', N'Minh Khải', NULL, NULL, 1, 0, NULL, 2)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (21, 5222000, 10, NULL, N'SHOESSHOP202107031226165789', 3, CAST(N'2021-07-03T12:26:16.513' AS DateTime), CAST(N'2021-07-03T12:27:36.417' AS DateTime), N'Thanh Trì', N'0896752222', N'Đạt', NULL, N'DISCOUNT', 1, 0, NULL, 1)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (22, 2901000, 0, NULL, N'SHOESSHOP202107031230099872', 1, CAST(N'2021-07-03T12:30:09.833' AS DateTime), NULL, N'Thanh Trì', N'0896752222', N'Đạt', NULL, NULL, 1, 0, NULL, 1)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (24, 2901000, 0, NULL, N'SHOESSHOP202107031235196271', 3, CAST(N'2021-07-03T12:35:19.603' AS DateTime), CAST(N'2021-07-03T12:37:32.207' AS DateTime), N'Hà Nội', N'0988654321', N'Khải Trịnh', NULL, NULL, 1, 0, NULL, 1)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (25, 2901000, 0, NULL, N'SHOESSHOP202107031236376055', 3, CAST(N'2021-07-03T12:36:37.890' AS DateTime), CAST(N'2021-07-03T12:45:39.837' AS DateTime), N'Hoàng Mai Hà Nội', N'0965713472', N'Lê Thắng Cảnh', NULL, NULL, 1, 0, NULL, 1)
INSERT [dbo].[Order] ([Id], [Total], [Discount], [SaleId], [Code], [Status], [CreateDate], [UpdateDate], [AddressTo], [Phone], [BuyerName], [Note], [KeyCode], [ProvinceId], [CustomerPay], [Refuse], [Type]) VALUES (26, 41279000, 0, NULL, N'SHOESSHOP202107031240067171', 3, CAST(N'2021-07-03T12:40:06.340' AS DateTime), CAST(N'2021-07-03T12:40:42.337' AS DateTime), N'Hà Nội', N'0123456789', N'Hà', NULL, NULL, 1, 0, NULL, 1)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (1, 1, 19, 2930000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (2, 2, 21, 5280000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (3, 3, 7, 2930000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (4, 4, 11, 5280000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (5, 5, 8, 2930000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (6, 6, 10, 5280000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (7, 7, 20, 5280000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (8, 7, 4, 3240000, 2, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (9, 9, 19, 2930000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (10, 10, 19, 2930000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (11, 11, 3, 3240000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (12, 12, 10, 0, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (13, 13, 21, 5174000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (14, 14, 3, 3175000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (15, 15, 21, 5121000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (16, 15, 18, 3986000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (17, 16, 19, 2901000, 2, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (18, 17, 19, 2901000, 2, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (19, 18, 21, 5122000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (20, 18, 15, 3987000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (21, 19, 32, 2910000, 2, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (22, 20, 19, 2901000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (23, 20, 31, 3483000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (24, 21, 8, 2901000, 2, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (25, 22, 6, 2901000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (26, 24, 6, 2901000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (27, 25, 6, 2901000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (28, 26, 19, 2901000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (29, 26, 26, 2901000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (30, 26, 8, 2901000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (31, 26, 7, 2901000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (32, 26, 6, 2901000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (33, 26, 9, 5122000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (34, 26, 10, 5122000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (35, 26, 11, 5122000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (36, 26, 12, 5122000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (37, 26, 1, 3143000, 1, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [WarehouseId], [Price], [Amount], [IsDelete]) VALUES (38, 26, 4, 3143000, 1, NULL)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [BrandId], [Name], [Describe], [Status], [CreateDate], [UpdateDate], [IsDelete], [Discount], [Price], [Type], [AvatarUrl]) VALUES (1, 2, N'Nike Air Force 1 ''07 LV8', N'<p><strong>Nike Air Force 1 &#39;07 LV8</strong><strong>.</strong></p><p>Nike Air Force 1 &#39;07 LV8 cập nhật phi&ecirc;n bản gốc &#39;82 lấy cảm hứng từ v&ograve;ng đệm với &iacute;t nhất 20% nội dung t&aacute;i chế theo trọng lượng v&agrave; đế ngo&agrave;i bằng n&uacute;t chai.&nbsp;Với họa tiết c&acirc;y lựu bao gồm m&agrave;u nhuộm từ thực vật thật, thiết kế th&ecirc;u thực vật v&agrave; đồ họa th&ocirc;ng tin khoa học, đ&oacute; l&agrave; một n&eacute;t tự nhi&ecirc;n của t&aacute;c phẩm cổ điển m&agrave; ch&uacute;ng ta đều biết v&agrave; y&ecirc;u th&iacute;ch.</p><p><strong>Thiết kế tưởng tượng lại</strong></p><p>Mang phong c&aacute;ch cổ điển của Nike b-ball v&agrave;o một lĩnh vực bền vững, cổ điển n&agrave;y c&oacute; &iacute;t nhất 20% th&agrave;nh phần t&aacute;i chế theo trọng lượng.&nbsp;Một đế ngo&agrave;i bằng n&uacute;t chai v&agrave; dubrae sẽ cập nhật phong c&aacute;ch của bạn.</p><p><strong>Chi tiết&nbsp;</strong></p><p>H&igrave;nh minh họa thực vật th&ecirc;u về một quả lựu tr&ecirc;n lưỡi gật đầu với thuốc nhuộm thực vật được sử dụng trong gi&agrave;y.&nbsp;Bảng m&agrave;u tự nhi&ecirc;n t&ocirc;n vinh thi&ecirc;n nhi&ecirc;n v&agrave; l&agrave;m nổi bật c&ocirc;ng tr&igrave;nh x&acirc;y dựng độc đ&aacute;o.</p><p><strong>Nhiều lợi &iacute;ch hơn</strong></p><ul><li>C&aacute;c lớp phủ được kh&acirc;u ở ph&iacute;a tr&ecirc;n th&ecirc;m phong c&aacute;ch di sản, độ bền v&agrave; hỗ trợ.</li><li>Được thiết kế ban đầu cho v&ograve;ng đệm hiệu suất, đệm Nike Air bổ sung th&ecirc;m độ nhẹ, thoải m&aacute;i cả ng&agrave;y.</li><li>Cổ &aacute;o c&oacute; đệm, cắt thấp tr&ocirc;ng b&oacute;ng bẩy v&agrave; tạo cảm gi&aacute;c tuyệt vời.</li><li>Phần đế t&aacute;i chế m&agrave;u Volt tạo cảm gi&aacute;c cực kỳ mềm mại v&agrave; n&acirc;ng đỡ.</li></ul><p><br></p>', 1, CAST(N'2021-06-09T23:08:12.067' AS DateTime), CAST(N'2021-06-15T20:00:36.590' AS DateTime), NULL, 1, 2930000, 1, N'ccd7986c-e1f0-421e-9a22-fec3651199abair-force-1-07-lv8-shoe-ldZ4Ml.jpg')
INSERT [dbo].[Product] ([Id], [BrandId], [Name], [Describe], [Status], [CreateDate], [UpdateDate], [IsDelete], [Discount], [Price], [Type], [AvatarUrl]) VALUES (2, 2, N'Nike Air Max 97 SE', N'<p><strong>Nike Air Max 97 SE</strong></p><p>Vẫn giữ nguy&ecirc;n thiết kế gợn s&oacute;ng lấy cảm hứng từ những chuyến t&agrave;u cao tốc của Nhật Bản, Nike Air Max 97 cho ph&eacute;p bạn đẩy phong c&aacute;ch của m&igrave;nh l&ecirc;n ph&iacute;a trước với tốc độ tối đa. để gi&uacute;p bạn đi xe trong sự thoải m&aacute;i hạng nhất.</p><p><strong>Những lợi &iacute;ch</strong></p><ul><li>Ban đầu được thiết kế để chạy hiệu suất, bộ phận Max Air c&oacute; chiều d&agrave;i đầy đủ mang đến cho bạn lớp đệm mềm mại, thoải m&aacute;i dưới b&agrave;n ch&acirc;n.</li><li>Mặt tr&ecirc;n bằng vải denim kh&oacute;i giữ cho vẻ ngo&agrave;i linh hoạt v&agrave; độ bền của OG.</li><li>Đế giữa bằng bọt tạo cảm gi&aacute;c đ&agrave;n hồi v&agrave; mềm mại.</li><li>Đế ngo&agrave;i bằng cao su mang lại cho bạn lực k&eacute;o bền bỉ.</li></ul><p><br></p>', 1, CAST(N'2021-06-09T23:29:22.197' AS DateTime), CAST(N'2021-06-15T19:09:08.513' AS DateTime), NULL, 3, 5280000, 1, N'9bc524f2-bce7-4798-b3ef-f7d0b33b4932air-max-97-se-shoe-5C94fs.png')
INSERT [dbo].[Product] ([Id], [BrandId], [Name], [Describe], [Status], [CreateDate], [UpdateDate], [IsDelete], [Discount], [Price], [Type], [AvatarUrl]) VALUES (3, 2, N'Nike Air Force 1 Crater Flyknit', N'<p><strong>Nike Air Force 1 Crater Flyknit</strong></p><p>Sự hiện đại của bạn với biểu tượng chiếc v&ograve;ng, Nike Air Force 1 Crater Flyknit cập nhật phong c&aacute;ch b&oacute;ng b-ball cổ điển với &iacute;t nhất 20% vật liệu t&aacute;i chế theo trọng lượng. một bước ngoặt hiện đại. Đ&oacute; l&agrave; phong c&aacute;ch huyền thoại lu&ocirc;n đ&uacute;ng v&agrave; cho ph&eacute;p bạn l&ugrave;i lại một ch&uacute;t sau mỗi bước đi.</p><p><strong>Những lợi &iacute;ch</strong></p><ul><li>Được l&agrave;m từ &iacute;t nhất 20% vật liệu t&aacute;i chế theo trọng lượng, thiết kế n&agrave;y l&agrave; một phần trong cam kết của Nike nhằm gi&uacute;p bảo vệ tương lai của thể thao.</li><li>Phần tr&ecirc;n của Airy Flyknit c&oacute; vải t&aacute;i chế co gi&atilde;n để vừa vặn với b&agrave;n ch&acirc;n của bạn trong khi vẻ ngo&agrave;i giống như vải lanh của n&oacute; ph&ugrave; hợp với rung cảm m&ugrave;a h&egrave; của bạn.</li><li>Xốp miệng n&uacute;i lửa si&ecirc;u mềm l&agrave; một cuộc c&aacute;ch mạng về sự thoải m&aacute;i. N&oacute; được l&agrave;m từ vật liệu t&aacute;i chế, tạo th&ecirc;m sức mạnh cho bước ch&acirc;n của bạn v&agrave; c&oacute; thiết kế đế l&oacute;t ly OG nhưng c&oacute; r&atilde;nh s&acirc;u hơn để mang lại vẻ ngo&agrave;i hiện đại.</li><li>Được thiết kế ban đầu cho v&ograve;ng đệm hiệu suất, đệm Nike Air bổ sung th&ecirc;m độ nhẹ, thoải m&aacute;i cả ng&agrave;y.</li><li>Cổ &aacute;o c&oacute; đệm, cắt thấp tr&ocirc;ng thể thao v&agrave; tạo cảm gi&aacute;c tuyệt vời.</li><li>C&aacute;c chi tiết Nike Grind bổ sung lực k&eacute;o v&agrave; độ bền trong một thiết kế được chế t&aacute;c bền vững trong khi c&aacute;c điểm nhấn trong mờ tăng th&ecirc;m vẻ tinh tế ho&agrave;n hảo.</li></ul><p><br></p>', 1, CAST(N'2021-06-09T23:50:49.280' AS DateTime), CAST(N'2021-06-15T19:09:08.513' AS DateTime), NULL, 3, 3240000, 1, N'699de0af-ecb5-41a1-8667-c1fe8b3db58dair-force-1-crater-flyknit-shoe-T5VQb0.jpg')
INSERT [dbo].[Product] ([Id], [BrandId], [Name], [Describe], [Status], [CreateDate], [UpdateDate], [IsDelete], [Discount], [Price], [Type], [AvatarUrl]) VALUES (4, 2, N'Nike Waffle One', N'<p><strong>Nike Waffle One</strong></p><p>Mang đến một diện mạo mới cho nhượng quyền thương hiệu Waffle mang t&iacute;nh biểu tượng, Nike Waffle One c&acirc;n bằng mọi thứ bạn y&ecirc;u th&iacute;ch nhất về d&ograve;ng sản phẩm di sản m&agrave; Nike đang chạy với những cải tiến mới. . Đế giữa c&oacute; l&ograve; xo mới c&oacute; h&igrave;nh dạng n&ecirc;m cổ điển trong khi đế ngo&agrave;i Waffle được cập nhật cung cấp mức hỗ trợ v&agrave; lực k&eacute;o m&agrave; bạn phải tin tưởng.</p><p><strong>Những lợi &iacute;ch</strong></p><ul><li>Phần tr&ecirc;n hỗn hợp c&oacute; lưới trong suốt v&agrave; c&aacute;c sợi kiện mềm mại, tăng th&ecirc;m k&iacute;ch thước v&agrave; kết cấu cho gi&agrave;y trong khi vẫn giữ cho n&oacute; th&ocirc;ng tho&aacute;ng.</li><li>Đế giữa xếp chồng k&eacute;p giữ h&igrave;nh dạng n&ecirc;m cổ điển của nhượng quyền thương hiệu Waffle cho một chuyến đi mềm mại, c&oacute; đệm.</li><li>Kẹp g&oacute;t TPU mới tạo ra vẻ ngo&agrave;i năng động, tăng th&ecirc;m sự hỗ trợ v&agrave; năng lượng trong khi đường kh&acirc;u ziczac kết hợp sự hấp dẫn của DIY với sự sắc sảo của th&agrave;nh thị.</li><li>Đế ngo&agrave;i Waffle cao su mang t&iacute;nh biểu tượng đ&atilde; được cập nhật với c&aacute;c vấu đ&uacute;c mới để tăng th&ecirc;m khả năng hỗ trợ, lực k&eacute;o v&agrave; độ bền.</li><li>Cổ &aacute;o được cắt thấp c&oacute; c&aacute;c đường viền mềm mại để tạo kiểu d&aacute;ng đẹp v&agrave; tạo cảm gi&aacute;c thoải m&aacute;i.</li></ul><p><strong>Th&ocirc;ng tin chi tiết sản phẩm</strong></p><ul><li>Đế cao su</li><li>Kh&ocirc;ng nhằm mục đ&iacute;ch sử dụng l&agrave;m Thiết bị Bảo vệ C&aacute; nh&acirc;n (PPE)</li><li>M&agrave;u sắc hiển thị: M&agrave;u hoa v&acirc;n anh / Đen / Sữa dừa / V&agrave;ng đại học</li><li>Phong c&aacute;ch: DA7995-600</li><li>Quốc gia / Khu vực xuất xứ: Việt Nam</li></ul><p><br></p>', 1, CAST(N'2021-06-09T23:58:09.197' AS DateTime), CAST(N'2021-06-15T19:09:08.513' AS DateTime), NULL, 3, 3000000, 1, N'1f8d903b-f3fa-4812-a033-4ab14b4860a6waffle-one-shoe-1SFQwJ.png')
INSERT [dbo].[Product] ([Id], [BrandId], [Name], [Describe], [Status], [CreateDate], [UpdateDate], [IsDelete], [Discount], [Price], [Type], [AvatarUrl]) VALUES (5, 2, N'Nike Air Zoom Terra Kiger 7', N'<p><strong>Nike Air Zoom Terra Kiger 7</strong></p><p>Chạy đường m&ograve;n trong Nike Air Zoom Terra Kiger 7. Nhanh v&agrave; nhẹ, gi&agrave;y mang lại cảm gi&aacute;c tho&aacute;ng kh&iacute; v&agrave; an to&agrave;n khi bạn chạy tr&ecirc;n những con đường đầy đ&aacute;.</p><p><strong>Đẩy về ph&iacute;a trước</strong></p><p>C&ocirc;ng nghệ Nike React l&agrave; một loại bọt nhẹ v&agrave; bền mang lại cảm gi&aacute;c đi nhanh. Bộ phận Zoom Air ở b&agrave;n ch&acirc;n trước cung cấp th&ecirc;m khả năng phản hồi, trả lại năng lượng của bạn để gi&uacute;p hướng dẫn bạn đi xuống đường m&ograve;n.</p><p><strong>Lực k&eacute;o đa bề mặt</strong></p><p>C&aacute;c vấu k&eacute;o đa hướng ở g&oacute;t ch&acirc;n được l&agrave;m từ cao su chịu m&agrave;i m&ograve;n cao, gi&uacute;p tăng cường độ b&aacute;m tr&ecirc;n c&aacute;c vết l&otilde;m v&agrave; vết l&otilde;m.</p><p><strong>Nhẹ v&agrave; tho&aacute;ng kh&iacute;</strong></p><p>Lưới v&agrave; phần tr&ecirc;n tổng hợp mang lại cảm gi&aacute;c nhẹ nh&agrave;ng v&agrave; tăng cường khả năng th&ocirc;ng gi&oacute;.</p><p><strong>Hỗ trợ sẵn s&agrave;ng đi đường</strong></p><p>Hệ thống Dynamic Fit th&ocirc;ng qua giữa b&agrave;n ch&acirc;n gi&uacute;p &ocirc;m v&agrave; hỗ trợ b&agrave;n ch&acirc;n của bạn khi bạn chạy qua những con đường m&ograve;n đầy đ&aacute;.</p><p><strong>Nhiều lợi &iacute;ch hơn</strong></p><ul><li>Tấm đ&aacute; ở g&oacute;t ch&acirc;n gi&uacute;p che chắn b&agrave;n ch&acirc;n của bạn tr&ecirc;n địa h&igrave;nh gồ ghề.</li><li>Cổ &aacute;o mỏng, c&oacute; đệm tạo cảm gi&aacute;c thoải m&aacute;i mềm mại v&agrave; kiểu d&aacute;ng hợp l&yacute;.</li><li>Đệm lưỡi gi&uacute;p giảm &aacute;p lực do ph&ugrave; ch&acirc;n khi chạy qu&atilde;ng đường d&agrave;i.</li></ul><p><br></p>', 1, CAST(N'2021-06-10T00:08:48.973' AS DateTime), CAST(N'2021-06-15T19:09:08.513' AS DateTime), NULL, 3, 4110000, 1, N'11d5ac93-22da-420f-9029-58df60c216f8air-zoom-terra-kiger-7-trail-running-shoe-nm2pqh.jpg')
INSERT [dbo].[Product] ([Id], [BrandId], [Name], [Describe], [Status], [CreateDate], [UpdateDate], [IsDelete], [Discount], [Price], [Type], [AvatarUrl]) VALUES (6, 2, N'Nike Air Zoom Pegasus 38', N'<p><strong>Nike Air Zoom Pegasus 38</strong></p><p>Nike Air Zoom Pegasus 38 tiếp tục tạo ra một l&ograve; xo trong bước đi của bạn, sử dụng c&ugrave;ng một lớp bọt phản ứng tương tự như người tiền nhiệm của n&oacute;.</p><p><strong>C&aacute;i g&igrave; đ&oacute; cũ, c&aacute;i g&igrave; đ&oacute; mới</strong></p><p>B&agrave;n ch&acirc;n trước rộng hơn c&oacute; nghĩa l&agrave; c&oacute; nhiều kh&ocirc;ng gian hơn cho c&aacute;c ng&oacute;n ch&acirc;n của bạn, trong khi độ vừa vặn của gi&agrave;y duy tr&igrave; cảm gi&aacute;c thoải m&aacute;i m&agrave; bạn mong đợi từ Pegasus.</p><p><strong>M&ugrave;a xu&acirc;n với bước của bạn</strong></p><p>Bọt Nike React c&oacute; trọng lượng nhẹ, c&oacute; độ đ&agrave;n hồi v&agrave; độ bền cao, nhiều bọt hơn đồng nghĩa với việc đệm tốt hơn m&agrave; kh&ocirc;ng bị cồng kềnh.</p><p><strong>Ph&ugrave; hợp an to&agrave;n</strong></p><p>Vải l&oacute;t giữa b&agrave;n ch&acirc;n &ocirc;m chặt lấy b&agrave;n ch&acirc;n của bạn khi bạn xỏ d&acirc;y, cho ph&eacute;p bạn lựa chọn ph&ugrave; hợp v&agrave; cảm thấy của m&igrave;nh.</p><p><strong>Nhiều lợi &iacute;ch hơn</strong></p><ul><li>Nhiều bọt hơn ở lưỡi mang lại cảm gi&aacute;c thoải m&aacute;i v&agrave; mềm mại.</li><li>Đế cao su được l&agrave;m từ khoảng 9% vật liệu Nike Grind, c&oacute; thể dẫn đến biến đổi m&agrave;u sắc nhẹ.</li></ul>', 1, CAST(N'2021-06-10T00:15:36.887' AS DateTime), CAST(N'2021-06-15T19:09:08.513' AS DateTime), NULL, 3, 3590000, 2, N'6a05e2f9-a947-40c4-a4a2-aa018d4fcd37air-zoom-pegasus-38-running-shoe-D1tCt1.png')
INSERT [dbo].[Product] ([Id], [BrandId], [Name], [Describe], [Status], [CreateDate], [UpdateDate], [IsDelete], [Discount], [Price], [Type], [AvatarUrl]) VALUES (7, 2, N'Nike Air Force 1 Crater Flyknit', N'<p><strong>Nike Air Force 1 Crater Flyknit</strong></p><p>Lấy biểu tượng chiếc v&ograve;ng hiện đại, Nike Air Force 1 Crater Flyknit cập nhật phong c&aacute;ch b-ball cổ điển với &iacute;t nhất 20% vật liệu t&aacute;i chế theo trọng lượng.&nbsp;Phần tr&ecirc;n Flyknit si&ecirc;u tho&aacute;ng c&oacute; kết cấu giống như vải lanh trong khi phần giữa bằng bọt Crater c&oacute; lốm đốm tạo th&ecirc;m n&eacute;t hiện đại.&nbsp;Đ&oacute; l&agrave; phong c&aacute;ch huyền thoại lu&ocirc;n đ&uacute;ng v&agrave; cho ph&eacute;p bạn l&ugrave;i lại một ch&uacute;t sau mỗi bước đi.</p><p><strong>Những lợi &iacute;ch</strong></p><ul><li>Phần tr&ecirc;n của Airy Flyknit c&oacute; vải t&aacute;i chế co gi&atilde;n để vừa vặn với b&agrave;n ch&acirc;n của bạn trong khi vẻ ngo&agrave;i giống như vải lanh của n&oacute; ph&ugrave; hợp với rung cảm m&ugrave;a h&egrave; của bạn.</li><li>Bọt miệng n&uacute;i lửa hỗ trợ l&agrave; một cuộc c&aacute;ch mạng về sự thoải m&aacute;i.&nbsp;N&oacute; được l&agrave;m bằng một số vật liệu t&aacute;i chế v&agrave; th&ecirc;m m&ugrave;a xu&acirc;n cho bước đi của bạn.</li><li>Đế ngo&agrave;i c&oacute; thiết kế cupsole OG nhưng c&oacute; c&aacute;c r&atilde;nh s&acirc;u hơn để mang lại vẻ ngo&agrave;i hiện đại.</li><li>Được thiết kế ban đầu cho v&ograve;ng đệm hiệu suất, đệm Nike Air bổ sung th&ecirc;m độ nhẹ, thoải m&aacute;i cả ng&agrave;y.</li><li>Cổ &aacute;o c&oacute; đệm, cắt thấp tr&ocirc;ng thể thao v&agrave; tạo cảm gi&aacute;c tuyệt vời.</li><li>C&aacute;c chi tiết Nike Grind tăng th&ecirc;m lực k&eacute;o v&agrave; độ bền.</li></ul><p><strong>Th&ocirc;ng tin chi tiết sản phẩm</strong></p><ul><li>Đế l&oacute;t t&aacute;i chế, m&agrave;u Volt tạo cảm gi&aacute;c cực kỳ thoải m&aacute;i nhưng vẫn hỗ trợ</li><li>Tạo mẫu Flyknit t&aacute;i tạo c&aacute;c lớp phủ được kh&acirc;u m&agrave; bạn y&ecirc;u th&iacute;ch từ DNA AF-1</li><li>Viền truyền thống</li><li>Thiết kế Swoosh bằng da tổng hợp, nắp g&oacute;t v&agrave; k&iacute;nh che mắt</li></ul>', 1, CAST(N'2021-06-10T00:20:51.067' AS DateTime), CAST(N'2021-06-15T19:09:08.513' AS DateTime), NULL, 3, 3240000, 2, N'66ae0092-43c7-4c5f-b4af-34adb03da854air-force-1-crater-flyknit-shoe-T5VQb0redwhite.jpg')
INSERT [dbo].[Product] ([Id], [BrandId], [Name], [Describe], [Status], [CreateDate], [UpdateDate], [IsDelete], [Discount], [Price], [Type], [AvatarUrl]) VALUES (8, 2, N'Nike Wildhorse 7', N'<p><strong>Nike Wildhorse 7</strong></p><p>H&atilde;y thực hiện những cuộc chạy đường m&ograve;n kh&oacute; khăn v&agrave; khắc nghiệt đ&oacute; với kết cấu chắc chắn của Nike Wildhorse 7. Phần tr&ecirc;n mang lại khả năng th&ocirc;ng gi&oacute; bền bỉ với sự hỗ trợ khi bạn cần.&nbsp;Đệm midsole bọt cung cấp khả năng đ&aacute;p ứng tr&ecirc;n mỗi dặm.</p><p><strong>Đệm đ&aacute;p ứng</strong></p><p>Bọt Nike React mang lại cảm gi&aacute;c &ecirc;m &aacute;i, mềm mại, tiếp th&ecirc;m một ch&uacute;t m&ugrave;a xu&acirc;n cho bước đi của bạn.&nbsp;Đệm th&ecirc;m xung quanh g&oacute;t ch&acirc;n gi&uacute;p giữ cố định b&agrave;n ch&acirc;n của bạn.</p><p><strong>Độ bền tho&aacute;ng kh&iacute;</strong></p><p>Lưới trong suốt ph&iacute;a tr&ecirc;n gi&uacute;p b&agrave;n ch&acirc;n của bạn lu&ocirc;n th&ocirc;ng tho&aacute;ng v&agrave; m&aacute;t mẻ.&nbsp;Lớp da ở mũi gi&agrave;y mang lại độ bền cho những địa h&igrave;nh khắc nghiệt.</p><p><strong>Lực k&eacute;o đa bề mặt</strong></p><p>C&aacute;c vấu k&eacute;o đa hướng tr&ecirc;n đế ngo&agrave;i được l&agrave;m từ cao su c&oacute; độ m&agrave;i m&ograve;n cao.&nbsp;Ch&uacute;ng gi&uacute;p tăng cường độ b&aacute;m tr&ecirc;n c&aacute;c vết l&otilde;m v&agrave; vết l&otilde;m.</p><p><strong>Tr&aacute;nh xa bụi bẩn</strong></p><p>Cổ &aacute;o &ocirc;m quanh mắt c&aacute; ch&acirc;n &ocirc;m s&aacute;t b&agrave;n ch&acirc;n của bạn v&agrave; gi&uacute;p giữ bụi bẩn v&agrave; cặn b&atilde; ra ngo&agrave;i.</p><p><strong>Nhiều lợi &iacute;ch hơn</strong></p><ul><li>Hệ thống Dynamic Fit th&ocirc;ng qua giữa b&agrave;n ch&acirc;n gi&uacute;p &ocirc;m v&agrave; hỗ trợ b&agrave;n ch&acirc;n của bạn khi bạn chạy qua những con đường m&ograve;n đầy đ&aacute;.</li><li>Tấm đ&aacute; ph&acirc;n mảng gi&uacute;p che chắn cho đ&ocirc;i ch&acirc;n của bạn tr&ecirc;n những địa h&igrave;nh gồ ghề.</li></ul>', 1, CAST(N'2021-06-10T00:24:05.117' AS DateTime), CAST(N'2021-06-15T19:09:08.513' AS DateTime), NULL, 3, 3520000, 2, N'92b9996a-4d20-4852-9283-7463558c93d2wildhorse-7-trail-running-shoe-JNNtbP.jpg')
INSERT [dbo].[Product] ([Id], [BrandId], [Name], [Describe], [Status], [CreateDate], [UpdateDate], [IsDelete], [Discount], [Price], [Type], [AvatarUrl]) VALUES (9, 2, N'Nike ZoomX Invincible Run Flyknit', N'<p><strong>Nike ZoomX Invincible Run Flyknit</strong></p><p>Sau những lần chạy d&agrave;i với Nike ZoomX Invincible Run Flyknit.&nbsp;Bọt nhẹ v&agrave; nhạy mang lại cảm gi&aacute;c si&ecirc;u mềm mại v&agrave; gi&uacute;p cung cấp năng lượng cho mỗi bước đi.&nbsp;Tho&aacute;ng kh&iacute; v&agrave; an to&agrave;n, đ&acirc;y l&agrave; một trong những đ&ocirc;i gi&agrave;y được thử nghiệm nhiều nhất của ch&uacute;ng t&ocirc;i.&nbsp;Ren l&ecirc;n v&agrave; cảm nhận tiềm năng khi ch&acirc;n của bạn chạm v&agrave;o mặt đường.</p><p><strong>Cao hơn, mềm hơn, rộng hơn</strong></p><p>Chiều cao bọt cao hơn mang lại cảm gi&aacute;c mềm mại hơn.&nbsp;Một h&igrave;nh dạng rộng, ph&oacute;ng đại ở b&agrave;n ch&acirc;n trước mang lại một chuyến đi ổn định hơn.</p><p><strong>Trả lại nhiều hơn</strong></p><p>Bọt Nike ZoomX phản hồi nhanh v&agrave; nhẹ, mang đến cho bạn cảm gi&aacute;c thoải m&aacute;i với mỗi bước đi.&nbsp;C&oacute; h&igrave;nh dạng giống như một rocker, bọt hỗ trợ cho 3 giai đoạn sải ch&acirc;n của người chạy.&nbsp;N&oacute; mang lại sự linh hoạt khi ch&acirc;n bạn n&acirc;ng l&ecirc;n khỏi mặt đất, một chuyến đi &ecirc;m &aacute;i khi ch&acirc;n bạn di chuyển về ph&iacute;a trước v&agrave; đệm khi tiếp x&uacute;c với mặt đất.</p><p><strong>Đ&atilde; ph&aacute;t triển ổn định</strong></p><p>Flyknit đ&atilde; được cải tiến ở tr&ecirc;n đặt c&aacute;c khu vực dễ thở, nơi ch&acirc;n của bạn n&oacute;ng l&ecirc;n nhiều nhất.&nbsp;N&oacute; chắc chắn v&agrave; bền, giữ cho b&agrave;n ch&acirc;n của bạn an to&agrave;n với mọi dặm đường.</p><p><strong>Lực k&eacute;o, được tạo bằng dữ liệu</strong></p><p>Đế ngo&agrave;i Waffle được tạo bằng c&aacute;ch sử dụng dữ liệu do người chạy bộ th&ocirc;ng b&aacute;o để biết lực k&eacute;o ở những nơi bạn cần.&nbsp;Th&ocirc;ng tin n&agrave;y cũng gi&uacute;p định hướng thiết kế v&agrave; giao diện của c&aacute;c b&ecirc;n gi&agrave;y.</p><p><strong>Những lợi &iacute;ch</strong></p><ul><li>Một bảng điều khiển ở g&oacute;t được nh&uacute;ng v&agrave;o Flyknit, cung cấp sự hỗ trợ v&agrave; ổn định.</li><li>Cổ &aacute;o được l&oacute;t đệm cho cảm gi&aacute;c mềm mại, thoải m&aacute;i.</li></ul><p><strong>Th&ocirc;ng tin chi tiết sản phẩm</strong></p><ul><li>Trọng lượng (cỡ 8 của phụ nữ): 253g (ước chừng)</li><li>Ch&ecirc;nh lệch: 8,4mm (B&agrave;n ch&acirc;n trước: 25,8mm, G&oacute;t ch&acirc;n: 34,2mm)</li><li>Kh&ocirc;ng nhằm mục đ&iacute;ch sử dụng l&agrave;m Thiết bị Bảo vệ C&aacute; nh&acirc;n (PPE)</li></ul>', 1, CAST(N'2021-06-10T00:27:24.710' AS DateTime), CAST(N'2021-06-15T19:09:08.513' AS DateTime), NULL, 3, 5280000, 2, N'0c3ed1ec-ba14-47c4-b5e8-130fe8a7a473zoomx-invincible-run-flyknit-running-shoe-Xw4M7j.png')
INSERT [dbo].[Product] ([Id], [BrandId], [Name], [Describe], [Status], [CreateDate], [UpdateDate], [IsDelete], [Discount], [Price], [Type], [AvatarUrl]) VALUES (10, 5, N'RS-X Arcade', N'<p><strong>M&ocirc; tả</strong></p><p>RS-X t&aacute;i hiện h&igrave;nh b&oacute;ng chạy cổ điển của PUMA từ những năm 80 với sự kết hợp m&agrave;u sắc tươi mới, c&aacute;c chi tiết được khuếch đại v&agrave; thiết kế t&aacute;o bạo v&agrave; đơn giản. Lấy cảm hứng từ c&aacute;c tr&ograve; chơi điện tử cũ của trường học v&agrave; thẩm mỹ arcade, phi&ecirc;n bản RS-X n&agrave;y đ&atilde; sẵn s&agrave;ng cho một số tr&ograve; chơi cổ điển.</p><h3><span style="font-size: 14px;"><strong>C&aacute;c t&iacute;nh năng v&agrave; lợi &iacute;ch</strong></span></h3><ul><li>Hệ thống chạy (RS): C&ocirc;ng nghệ chạy cổ điển của PUMA cung cấp đệm từ b&agrave;n ch&acirc;n trước đến g&oacute;t ch&acirc;n</li></ul><h3><span style="font-size: 14px;"><strong>Chi tiết</strong></span></h3><ul><li>Lưới tr&ecirc;n với lớp phủ da</li><li>Đ&oacute;ng ren ho&agrave;n to&agrave;n</li><li>Đế giữa bằng PU nhẹ với đệm RS</li><li>Đế ngo&agrave;i cao su cung cấp lực k&eacute;o v&agrave; độ b&aacute;m</li><li>C&aacute;c miếng TPU đậm, nhiều m&agrave;u sắc ở midsole</li><li>Graphic PUMA Formstrip ở c&aacute;c cạnh b&ecirc;n</li><li>K&eacute;o v&ograve;ng ở g&oacute;t ch&acirc;n</li><li>V&ograve;ng lặp vải c&oacute; thương hiệu RS-X ở lưỡi</li></ul>', 1, CAST(N'2021-06-11T09:21:09.520' AS DateTime), CAST(N'2021-06-15T19:09:08.513' AS DateTime), NULL, 3, 2500000, 1, N'bdf20b99-f492-4e49-bbe3-f7ac98ce3c81RS-X-Arcade-Mens-Sneakersavatar.jpg')
INSERT [dbo].[Product] ([Id], [BrandId], [Name], [Describe], [Status], [CreateDate], [UpdateDate], [IsDelete], [Discount], [Price], [Type], [AvatarUrl]) VALUES (11, 2, N'Nike Free Metcon 4', N'<p><strong>Nike Free Metcon 4</strong></p><p>Nike Free Metcon 4 kết hợp t&iacute;nh linh hoạt với sự ổn định để gi&uacute;p bạn đạt được hiệu quả cao nhất trong chương tr&igrave;nh tập luyện của m&igrave;nh.&nbsp;Lưới &quot;li&ecirc;n kết chuỗi&quot; được cập nhật sẽ nguội đi v&agrave; uốn dẻo khi bạn tăng tốc trong c&aacute;c b&agrave;i tập nhanh nhẹn, đồng thời hỗ trợ ở b&agrave;n ch&acirc;n giữa v&agrave; g&oacute;t ch&acirc;n gi&uacute;p bạn c&oacute; được những set nặng nhất trong ph&ograve;ng tập.&nbsp;Lấy cảm hứng từ những ngọn đồi tr&ecirc;n sa mạc được sơn m&agrave;u, bản in thanh b&igrave;nh t&ocirc;n vinh tốc độ kh&ocirc;ng cần cắm điện của khung cảnh tự nhi&ecirc;n.</p><p><strong>Vụ nổ từ qu&aacute; khứ</strong></p><p>Chiếc 4 mang lại lưới si&ecirc;u dai nhưng tho&aacute;ng kh&iacute; từ phi&ecirc;n bản gốc.&nbsp;Phần tr&ecirc;n được trang tr&iacute; bằng d&acirc;y đeo lấy cảm hứng từ Huarache v&agrave; phần h&ocirc;ng c&oacute; sọc cao su bao quanh g&oacute;t ch&acirc;n của bạn để gi&uacute;p bạn di chuyển theo bất kỳ hướng n&agrave;o.</p><p><strong>T&iacute;nh linh hoạt cho tốc độ</strong></p><p>C&ocirc;ng nghệ Nike Free ở b&agrave;n ch&acirc;n trước tạo ra sự linh hoạt cho những bước di chuyển nhanh nhẹn v&agrave; chạy nước r&uacute;t.&nbsp;Duỗi quanh mắt c&aacute; ch&acirc;n để b&agrave;n ch&acirc;n của bạn di chuyển tự nhi&ecirc;n khi bạn bật, cắt v&agrave; phanh.</p><p><strong>Ổn định cho sức mạnh</strong></p><p>Phần g&oacute;t phẳng, rộng tạo bệ đỡ vững chắc khi n&acirc;ng. Lớp l&otilde;i xốp mềm hơn gi&uacute;p n&acirc;ng niu b&agrave;n ch&acirc;n của bạn, trong khi lớp b&ecirc;n ngo&agrave;i cứng hơn c&oacute; độ bền v&agrave; ổn định. Lớp vải b&ecirc;n trong rộng ph&acirc;n phối &aacute;p lực xung quanh b&agrave;n ch&acirc;n của bạn để tạo cảm gi&aacute;c thoải m&aacute;i nhưng vẫn bị kh&oacute;a trong khi dừng đột ngột v&agrave; cắt nhanh.</p>', 1, CAST(N'2021-06-13T18:29:09.750' AS DateTime), CAST(N'2021-06-15T19:09:08.513' AS DateTime), NULL, 3, 3520000, 2, N'2561b725-9f5e-4d83-ba85-228cc4100ff8free-metcon-4-training-shoe-Xj1GPK.jpg')
INSERT [dbo].[Product] ([Id], [BrandId], [Name], [Describe], [Status], [CreateDate], [UpdateDate], [IsDelete], [Discount], [Price], [Type], [AvatarUrl]) VALUES (12, 1, N'DURAMO SL', NULL, 1, CAST(N'2021-07-01T17:37:36.143' AS DateTime), NULL, NULL, 0, 1700000, 1, N'93873362-de7b-48c6-b635-a54b28bb72beDURAMO_SL_DJen_H04628_01_standard (1).jpg')
INSERT [dbo].[Product] ([Id], [BrandId], [Name], [Describe], [Status], [CreateDate], [UpdateDate], [IsDelete], [Discount], [Price], [Type], [AvatarUrl]) VALUES (13, 3, N'Chuck 70 Archive Paint Splatter High Top', N'<p><span style="font-family: Verdana, Geneva, sans-serif;">Chuck 70 Archive Paint Splatter High Top</span></p><p><span style="font-family: Verdana, Geneva, sans-serif;">SKU: <mark style="box-sizing: border-box; text-decoration: none; margin: 0px; padding: 0px; border: 0px; vertical-align: baseline; font-weight: 400; background-color: transparent;">170802C</mark></span></p><p><mark style="box-sizing: border-box; text-decoration: none; margin: 0px; padding: 0px; border: 0px; vertical-align: baseline; font-weight: 400; background-color: transparent;"><span style="color: rgb(0, 0, 0); font-family: Verdana, Geneva, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: right; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; float: none; display: inline !important;">Chất liệu: Canvas</span><span style="font-family: Verdana, Geneva, sans-serif;">&nbsp;</span></mark></p>', 1, CAST(N'2021-07-01T17:51:03.727' AS DateTime), NULL, NULL, 0, 2000000, 1, N'65471e49-deec-4184-b33c-688976d73dda170802Cshot2.jpg')
INSERT [dbo].[Product] ([Id], [BrandId], [Name], [Describe], [Status], [CreateDate], [UpdateDate], [IsDelete], [Discount], [Price], [Type], [AvatarUrl]) VALUES (14, 5, N'Suede Iri Wild Women''s Sneakers', N'<p><span style="font-family: Verdana,Geneva,sans-serif;">Suede Iri Wild Women&#39;s Sneakers<br></span></p><p><span style="font-family: Verdana,Geneva,sans-serif;">C&aacute;c xu hướng đến v&agrave; đi, nhưng một số c&oacute; vẻ sẽ đứng vững trước thử th&aacute;ch của thời gian - v&agrave; Da lộn l&agrave; một biểu tượng được chứng nhận. Phi&ecirc;n bản n&agrave;y c&oacute; h&igrave;nh b&oacute;ng dễ nhận biết ngay lập tức của Suede, phần tr&ecirc;n bằng da lộn sang trọng v&agrave; đặc điểm nổi bật: PUMA Formstrip với họa tiết da b&aacute;o &oacute;ng &aacute;nh, lấp l&aacute;nh để tăng vẻ quyến rũ ngay lập tức. &nbsp;</span></p>', 1, CAST(N'2021-07-01T18:08:59.803' AS DateTime), CAST(N'2021-07-01T18:09:33.433' AS DateTime), NULL, 0, 1610000, 2, N'f763e3ec-e526-4bfa-b0db-65ffb3d244fcSuede-Iri-Wild-Women-Sneakers1.jpg')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductImg] ON 

INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (1, N'cf9f051b-c6e2-4166-a111-d32527ca53bbair-force-1-07-lv8-shoe-ldZ4Ml-black.jpg', 1, N'Đen', NULL, 1, CAST(N'2021-06-09T23:10:37.900' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (2, N'1def695a-3fdc-4220-b3b4-de2177949b97air-force-1-07-lv8-shoe-ldZ4Ml-white.jpg', 1, N'Trắng', NULL, 1, CAST(N'2021-06-09T23:10:48.850' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (3, N'25958831-23f8-41c7-b51e-c60d5e3a9aedair-max-97-se-shoe-5C94fs116.jpg', 2, N'Đen', NULL, 1, CAST(N'2021-06-09T23:33:28.083' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (4, N'ef0c2cf0-8334-412d-95d4-a93e3ac8f3eaair-force-1-crater-flyknit-shoe-T5VQb0redwhite.jpg', 3, N'Đỏ Đen', NULL, 1, CAST(N'2021-06-09T23:51:47.520' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (5, N'7605e8ed-c9ea-408f-9e5c-c6d87ab378f5air-force-1-crater-flyknit-shoe-T5VQb0black.jpg', 3, N'Đen', NULL, 1, CAST(N'2021-06-09T23:52:12.077' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (6, N'cc979f79-81f6-405f-bb4b-dc6e45cd2286air-force-1-crater-flyknit-shoe-T5VQb0white.jpg', 3, N'Trắng', NULL, 1, CAST(N'2021-06-09T23:52:33.527' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (7, N'7eb70a2e-0a2e-4194-98ed-9494445dfddcwaffle-one-shoe-1SFQwJ.jpg', 4, N'Trắng', NULL, 1, CAST(N'2021-06-09T23:58:30.043' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (8, N'0cead4d5-a596-4e37-a37c-aec463ea2c2fwaffle-one-shoe-1SFQwJblack.jpg', 4, N'Đen', NULL, 1, CAST(N'2021-06-10T00:02:10.503' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (9, N'f106e50b-c9a4-4740-be30-d7f92ee4672bwaffle-one-shoe-1SFQwJgreen.jpg', 4, N'Xanh lá', NULL, 1, CAST(N'2021-06-10T00:02:24.100' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (10, N'7d3c54b7-7787-471a-94c0-3edbd6e80470waffle-one-shoe-1SFQwJpink.jpg', 4, N'Hồng Cam Đen', NULL, 1, CAST(N'2021-06-10T00:02:59.793' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (11, N'dceb3c89-f5be-4451-b023-c5d8bba990a2air-zoom-terra-kiger-7-trail-running-shoe-nm2pqhvangcam.jpg', 5, N'Xanh Vàng Cam', NULL, 1, CAST(N'2021-06-10T00:09:09.417' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (12, N'34cee9e4-a987-462b-a000-001a4ce3fe96air-zoom-terra-kiger-7-trail-running-shoe-nm2pqhxanhtim.jpg', 5, N'Xanh Tím Cam', NULL, 1, CAST(N'2021-06-10T00:10:36.827' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (13, N'1dbbb855-7a55-4fc0-83a0-76a3da7dd013air-zoom-pegasus-38-running-shoe-D1tCt1pink.jpg', 6, N'Hồng', NULL, 1, CAST(N'2021-06-10T00:15:48.800' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (14, N'44b39046-6f85-4053-991d-b3fac8cb7808air-zoom-pegasus-38-running-shoe-D1tCt1red.jpg', 6, N'Đỏ đen', NULL, 1, CAST(N'2021-06-10T00:16:05.493' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (15, N'23ba46b0-a307-4b48-b3d0-7b0274b82ecfair-zoom-pegasus-38-running-shoe-D1tCt1.jpg', 6, N'Trắng Xanh Lá', NULL, 1, CAST(N'2021-06-10T00:16:40.657' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (16, N'8d255f84-628a-469d-9168-eef3d47fd575air-zoom-pegasus-38-running-shoe-D1tCt111.jpg', 6, N'Đen', NULL, 1, CAST(N'2021-06-10T00:17:05.693' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (17, N'38a839b4-d3ba-4493-9d54-5aa6a7bcfce7air-zoom-pegasus-38-running-shoe-D1tCt112.jpg', 6, N'Trắng Đen Tím', NULL, 1, CAST(N'2021-06-10T00:17:44.677' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (18, N'b611c6b1-afec-4ccf-8d2c-c69448963e05air-force-1-crater-flyknit-shoe-XghH2l.jpg', 7, N'Trắng Xanh', NULL, 1, CAST(N'2021-06-10T00:21:29.820' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (19, N'fbc8b628-a21d-4d02-9dcd-8be06bfb754fair-force-1-crater-flyknit-shoe-XghH2l11.jpg', 7, N'Tím Trắng', NULL, 1, CAST(N'2021-06-10T00:21:56.077' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (20, N'f74750ee-d1fc-4dcf-b8b0-acf4c1542d73wildhorse-7-trail-running-shoe-JNNtbP.jpg', 8, N'Hồng', NULL, 1, CAST(N'2021-06-10T00:25:22.117' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (21, N'f9971e8e-72d5-4aa6-9ea0-ab004a23ec68zoomx-invincible-run-flyknit-running-shoe-Xw4M7j.jpg', 9, N'Tím Xanh lá Trắng', NULL, 1, CAST(N'2021-06-10T00:27:57.020' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (22, N'410da213-d601-411a-8744-8e5eca607ed6zoomx-invincible-run-flyknit-running-shoe-Xw4M7j11.jpg', 9, N'Trắng Cam', NULL, 1, CAST(N'2021-06-10T00:28:17.220' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (23, N'8d9a9e78-6709-4339-b198-c9073aab1847zoomx-invincible-run-flyknit-running-shoe-Xw4M7j12.jpg', 9, N'Đen Trắng', NULL, 1, CAST(N'2021-06-10T00:28:34.953' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (24, N'e59d70a8-af01-46f5-abb7-5d23114e74c0RS-X-Arcade-Mens-Sneakers.jpg', 10, N'Xanh lam Vàng Đen Hồng', NULL, 1, CAST(N'2021-06-11T09:22:01.780' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (25, N'32860a9c-9934-41cd-ba55-02d19e377f15free-metcon-4-training-shoe-Xj1GPK1.jpg', 11, N'Hồng Xám Trắng', NULL, 1, CAST(N'2021-06-13T18:30:08.027' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (26, N'c6edeeb6-6d90-4903-abf8-6bc05d2b75e7DURAMO_SL_DJen_H04628_04_standard.jpg', 12, N'Đen trắng', NULL, 1, CAST(N'2021-07-01T17:38:00.513' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (27, N'46118deb-d14a-4c7c-8500-09076a160792170802Cstandard.jpg', 13, N'Trắng', NULL, 1, CAST(N'2021-07-01T17:51:14.790' AS DateTime), NULL)
INSERT [dbo].[ProductImg] ([Id], [Url], [ProductId], [Color], [IsDelete], [Status], [CreateDate], [UpdateDate]) VALUES (28, N'9382d570-2863-4daa-ab99-dc9e00ced000Suede-Iri-Wild-Women-Sneakers.jpg', 14, N'Hồng', NULL, 1, CAST(N'2021-07-01T18:09:15.927' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[ProductImg] OFF
GO
SET IDENTITY_INSERT [dbo].[Promotion] ON 

INSERT [dbo].[Promotion] ([Id], [KeyCode], [ExpiredDate], [Amount], [StartDate], [Discount], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, N'DISCOUNT', NULL, 96, NULL, 10, NULL, NULL, NULL)
INSERT [dbo].[Promotion] ([Id], [KeyCode], [ExpiredDate], [Amount], [StartDate], [Discount], [IsDelete], [CreateDate], [UpdateDate]) VALUES (2, N'SAYHELLO', NULL, NULL, NULL, 13, NULL, NULL, NULL)
INSERT [dbo].[Promotion] ([Id], [KeyCode], [ExpiredDate], [Amount], [StartDate], [Discount], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, N'CHAOHE2021', CAST(N'2021-07-28T00:00:00.000' AS DateTime), NULL, CAST(N'2021-06-07T00:00:00.000' AS DateTime), 15, NULL, NULL, NULL)
INSERT [dbo].[Promotion] ([Id], [KeyCode], [ExpiredDate], [Amount], [StartDate], [Discount], [IsDelete], [CreateDate], [UpdateDate]) VALUES (4, N'JAMJA', NULL, 4, NULL, 3, NULL, CAST(N'2021-06-13T23:16:15.393' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Promotion] OFF
GO
SET IDENTITY_INSERT [dbo].[Province] ON 

INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (1, N'Hà Nội', N'Thành phố Trung ương')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (2, N'Hà Giang', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (4, N'Cao Bằng', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (6, N'Bắc Kạn', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (8, N'Tuyên Quang', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (10, N'Lào Cai', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (11, N'Điện Biên', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (12, N'Lai Châu', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (14, N'Sơn La', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (15, N'Yên Bái', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (17, N'Hoà Bình', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (19, N'Thái Nguyên', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (20, N'Lạng Sơn', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (22, N'Quảng Ninh', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (24, N'Bắc Giang', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (25, N'Phú Thọ', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (26, N'Vĩnh Phúc', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (27, N'Bắc Ninh', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (30, N'Hải Dương', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (31, N'Hải Phòng', N'Thành phố Trung ương')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (33, N'Hưng Yên', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (34, N'Thái Bình', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (35, N'Hà Nam', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (36, N'Nam Định', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (37, N'Ninh Bình', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (38, N'Thanh Hóa', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (40, N'Nghệ An', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (42, N'Hà Tĩnh', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (44, N'Quảng Bình', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (45, N'Quảng Trị', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (46, N'Thừa Thiên Huế', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (48, N'Đà Nẵng', N'Thành phố Trung ương')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (49, N'Quảng Nam', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (51, N'Quảng Ngãi', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (52, N'Bình Định', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (54, N'Phú Yên', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (56, N'Khánh Hòa', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (58, N'Ninh Thuận', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (60, N'Bình Thuận', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (62, N'Kon Tum', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (64, N'Gia Lai', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (66, N'Đắk Lắk', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (67, N'Đắk Nông', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (68, N'Lâm Đồng', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (70, N'Bình Phước', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (72, N'Tây Ninh', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (74, N'Bình Dương', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (75, N'Đồng Nai', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (77, N'Bà Rịa - Vũng Tàu', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (79, N'Hồ Chí Minh', N'Thành phố Trung ương')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (80, N'Long An', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (82, N'Tiền Giang', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (83, N'Bến Tre', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (84, N'Trà Vinh', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (86, N'Vĩnh Long', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (87, N'Đồng Tháp', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (89, N'An Giang', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (91, N'Kiên Giang', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (92, N'Cần Thơ', N'Thành phố Trung ương')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (93, N'Hậu Giang', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (94, N'Sóc Trăng', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (95, N'Bạc Liêu', N'Tỉnh')
INSERT [dbo].[Province] ([Id], [Name], [Type]) VALUES (96, N'Cà Mau', N'Tỉnh')
SET IDENTITY_INSERT [dbo].[Province] OFF
GO
SET IDENTITY_INSERT [dbo].[Size] ON 

INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (1, 6, 39, 5.5, 1)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (2, 6.5, 39.5, 6, 1)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (3, 7, 40, 6.5, 1)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (4, 7.5, 40.5, 7, 1)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (5, 8, 41, 7.5, 1)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (6, 8.5, 41.5, 8, 1)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (7, 9, 42, 8.5, 1)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (8, 9.5, 42.5, 9, 1)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (9, 10, 43, 9.5, 1)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (10, 10.5, 43.5, 10, 1)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (11, 11, 44, 10.5, 1)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (12, 11.5, 44.5, 11, 1)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (13, 12, 45, 11.5, 1)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (15, 13, 46, 12.5, 1)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (17, 14, 47, 13.5, 1)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (19, 15, 48, 14.5, 1)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (21, 16, 49, 15.5, 1)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (22, 4, 34.5, 2, 2)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (23, 4.5, 35, 2.5, 2)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (24, 5, 35.5, 3, 2)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (25, 5.5, 36, 3.5, 2)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (26, 6, 36.5, 4, 2)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (27, 6.5, 37, 4.5, 2)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (28, 7, 37.5, 5, 2)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (29, 7.5, 38, 5.5, 2)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (30, 8, 38.5, 6, 2)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (31, 8.5, 39, 6.5, 2)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (32, 9, 39.5, 7, 2)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (33, 9.5, 40, 7.5, 2)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (34, 10, 40.5, 8, 2)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (35, 10.5, 41, 8.5, 2)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (36, 11, 41.5, 9, 2)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (37, 11.5, 42, 9.5, 2)
INSERT [dbo].[Size] ([Id], [US], [VN], [UK], [Type]) VALUES (38, 12, 42.5, 10, 2)
SET IDENTITY_INSERT [dbo].[Size] OFF
GO
SET IDENTITY_INSERT [dbo].[Slide] ON 

INSERT [dbo].[Slide] ([Id], [UrlFile], [Name], [CreateDate], [IsDelete], [Status], [OrderNumber], [UpdateDate]) VALUES (1, N'86572b1d-315f-4464-a8b0-8b7fd266dbad7cc602e74eb25a9301005d4cd83a166b.png', N'SLIDE20210604135826', CAST(N'2021-06-04T13:58:27.327' AS DateTime), NULL, 1, 1, CAST(N'2021-06-04T15:41:47.773' AS DateTime))
INSERT [dbo].[Slide] ([Id], [UrlFile], [Name], [CreateDate], [IsDelete], [Status], [OrderNumber], [UpdateDate]) VALUES (2, N'd6bb80b2-5937-43bd-bfe5-1817b1397233lightweight-shoes-1400x500.jpg', N'SLIDE20210604142511', CAST(N'2021-06-04T14:25:11.163' AS DateTime), NULL, 1, 2, CAST(N'2021-06-04T15:41:55.913' AS DateTime))
INSERT [dbo].[Slide] ([Id], [UrlFile], [Name], [CreateDate], [IsDelete], [Status], [OrderNumber], [UpdateDate]) VALUES (3, N'858717e7-e1e9-41b7-824b-e718f101f1c3Tropic-black-cardon-high-1400x500.jpg', N'SLIDE20210604142529', CAST(N'2021-06-04T14:25:29.643' AS DateTime), NULL, 1, 5, CAST(N'2021-06-04T15:42:30.910' AS DateTime))
INSERT [dbo].[Slide] ([Id], [UrlFile], [Name], [CreateDate], [IsDelete], [Status], [OrderNumber], [UpdateDate]) VALUES (4, N'77e1d148-13b0-4c86-82f6-95a925eec09dknit-shoes-hero-1400x500.jpg', N'SLIDE20210604142538', CAST(N'2021-06-04T14:25:38.547' AS DateTime), NULL, 1, 3, CAST(N'2021-06-04T15:42:06.240' AS DateTime))
INSERT [dbo].[Slide] ([Id], [UrlFile], [Name], [CreateDate], [IsDelete], [Status], [OrderNumber], [UpdateDate]) VALUES (5, N'2de95d71-14af-47ab-9d2f-743a86385b80shose.jpg', N'SLIDE20210604142554', CAST(N'2021-06-04T14:25:54.227' AS DateTime), NULL, 0, 4, CAST(N'2021-06-04T15:42:19.580' AS DateTime))
SET IDENTITY_INSERT [dbo].[Slide] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [UserName], [Password], [Phone], [Role], [Status], [IsDelete], [CreateDate], [UpdateDate], [FullName], [Address], [ProviceId]) VALUES (3, N'admin', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'0965713472', 1, 1, NULL, CAST(N'2021-05-16T20:54:59.063' AS DateTime), NULL, N'admin', NULL, NULL)
INSERT [dbo].[User] ([Id], [UserName], [Password], [Phone], [Role], [Status], [IsDelete], [CreateDate], [UpdateDate], [FullName], [Address], [ProviceId]) VALUES (4, N'manager', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'0984653211', 2, 1, NULL, CAST(N'2021-05-19T00:06:23.783' AS DateTime), CAST(N'2021-06-14T18:18:06.467' AS DateTime), N'Manager', N'Hà Nội', 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [Phone], [Role], [Status], [IsDelete], [CreateDate], [UpdateDate], [FullName], [Address], [ProviceId]) VALUES (5, N'manager2', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'0442452352', 2, 1, NULL, CAST(N'2021-05-19T00:11:49.957' AS DateTime), CAST(N'2021-06-18T00:11:05.777' AS DateTime), N'Quản lý cửa hàng 3', N'Hà Nội', 1)
INSERT [dbo].[User] ([Id], [UserName], [Password], [Phone], [Role], [Status], [IsDelete], [CreateDate], [UpdateDate], [FullName], [Address], [ProviceId]) VALUES (6, N'aaa', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'1', 2, 1, 1, CAST(N'2021-05-21T15:40:08.780' AS DateTime), CAST(N'2021-06-15T16:43:04.110' AS DateTime), N'1', N'1', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Warehouse] ON 

INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (1, 5, 3, CAST(N'2021-06-10T10:33:12.557' AS DateTime), CAST(N'2021-07-03T12:40:42.337' AS DateTime), 1, NULL, 4, 0, N'343', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (2, 2, 6, CAST(N'2021-06-10T10:35:06.177' AS DateTime), CAST(N'2021-06-10T10:40:17.390' AS DateTime), 1, NULL, 5, 0, N'356', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (3, 1, 7, CAST(N'2021-06-10T10:36:08.667' AS DateTime), CAST(N'2021-06-14T01:37:28.690' AS DateTime), 1, NULL, 6, 0, N'367', 2)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (4, 3, 5, CAST(N'2021-06-10T10:36:56.797' AS DateTime), CAST(N'2021-07-03T12:40:42.337' AS DateTime), 1, NULL, 4, 0, N'345', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (5, 4, 6, CAST(N'2021-06-10T10:37:35.350' AS DateTime), CAST(N'2021-06-10T10:40:17.357' AS DateTime), 1, NULL, 4, 0, N'346', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (6, 12, 6, CAST(N'2021-06-10T10:38:04.293' AS DateTime), CAST(N'2021-07-03T12:45:39.837' AS DateTime), 1, NULL, 2, 0, N'126', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (7, 3, 5, CAST(N'2021-06-10T10:39:09.387' AS DateTime), CAST(N'2021-07-03T12:40:42.337' AS DateTime), 1, NULL, 1, 0, N'115', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (8, 6, 4, CAST(N'2021-06-10T10:39:28.847' AS DateTime), CAST(N'2021-07-03T12:40:42.337' AS DateTime), 1, NULL, 1, 0, N'114', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (9, 2, 4, CAST(N'2021-06-10T10:52:56.563' AS DateTime), CAST(N'2021-07-03T12:40:42.337' AS DateTime), 1, NULL, 3, 0, N'234', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (10, 7, 5, CAST(N'2021-06-10T10:53:20.997' AS DateTime), CAST(N'2021-07-03T12:40:42.337' AS DateTime), 1, NULL, 3, 0, N'235', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (11, 3, 7, CAST(N'2021-06-10T10:53:47.683' AS DateTime), CAST(N'2021-07-03T12:40:42.337' AS DateTime), 1, NULL, 3, 0, N'237', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (12, 1, 9, CAST(N'2021-06-10T10:54:01.403' AS DateTime), CAST(N'2021-07-03T12:40:42.337' AS DateTime), 1, NULL, 3, 0, N'239', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (13, 2, 1, CAST(N'2021-06-10T10:54:25.000' AS DateTime), CAST(N'2021-06-10T10:56:22.160' AS DateTime), 1, NULL, 11, 0, N'5111', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (14, 3, 6, CAST(N'2021-06-10T10:54:46.877' AS DateTime), CAST(N'2021-06-10T10:56:22.140' AS DateTime), 1, NULL, 12, 0, N'5126', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (15, 4, 5, CAST(N'2021-06-10T10:55:10.137' AS DateTime), CAST(N'2021-06-10T10:56:22.133' AS DateTime), 1, NULL, 11, 0, N'5115', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (16, 3, 6, CAST(N'2021-06-10T10:55:29.457' AS DateTime), CAST(N'2021-06-10T10:56:22.120' AS DateTime), 1, NULL, 11, 0, N'5116', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (17, 5, 5, CAST(N'2021-06-10T10:55:52.780' AS DateTime), CAST(N'2021-06-10T10:56:22.113' AS DateTime), 1, NULL, 12, 0, N'5125', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (18, 1, 17, CAST(N'2021-06-10T10:56:13.550' AS DateTime), CAST(N'2021-07-01T09:17:56.770' AS DateTime), 1, NULL, 12, 0, N'51217', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (19, 3, 1, CAST(N'2021-06-10T11:16:40.120' AS DateTime), CAST(N'2021-07-03T12:40:42.337' AS DateTime), 1, NULL, 1, 0, N'111', 1)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (20, 2, 6, CAST(N'2021-06-10T11:20:24.887' AS DateTime), CAST(N'2021-06-10T11:20:45.140' AS DateTime), 1, NULL, 3, 0, N'236', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (21, 2, 8, CAST(N'2021-06-10T11:20:40.213' AS DateTime), CAST(N'2021-07-01T09:17:56.770' AS DateTime), 1, NULL, 3, 0, N'238', 1)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (22, 2, 22, CAST(N'2021-06-16T11:22:05.403' AS DateTime), CAST(N'2021-06-16T11:22:09.497' AS DateTime), 1, NULL, 19, 0, N'71922', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (25, 8, 1, CAST(N'2021-07-01T20:07:16.767' AS DateTime), CAST(N'2021-07-01T22:23:05.220' AS DateTime), 1, NULL, 7, 0, N'471', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (26, 2, 2, CAST(N'2021-07-01T20:07:55.190' AS DateTime), CAST(N'2021-07-03T12:40:42.337' AS DateTime), 1, NULL, 1, 0, N'112', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (27, 3, 5, CAST(N'2021-07-01T20:08:51.227' AS DateTime), CAST(N'2021-07-01T20:08:55.737' AS DateTime), 1, NULL, 7, 0, N'475', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (30, 5, 24, CAST(N'2021-07-01T22:22:20.523' AS DateTime), CAST(N'2021-07-01T22:23:05.213' AS DateTime), 1, NULL, 20, 0, N'82024', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (31, 5, 24, CAST(N'2021-07-01T22:22:43.337' AS DateTime), CAST(N'2021-07-02T22:48:46.157' AS DateTime), 1, NULL, 16, 0, N'61624', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (32, 2, 3, CAST(N'2021-07-01T22:23:02.067' AS DateTime), CAST(N'2021-07-02T22:54:14.517' AS DateTime), 1, NULL, 7, 0, N'473', 2)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (33, 2, 26, CAST(N'2021-07-02T22:50:20.440' AS DateTime), CAST(N'2021-07-02T22:51:16.037' AS DateTime), 1, NULL, 25, 0, N'112526', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (34, 4, 6, CAST(N'2021-07-02T22:50:39.317' AS DateTime), CAST(N'2021-07-02T22:51:16.023' AS DateTime), 1, NULL, 26, 0, N'12266', 0)
INSERT [dbo].[Warehouse] ([Id], [Amount], [SizeId], [CreateDate], [UpdateDate], [Status], [IsDelete], [ProductImgId], [Discount], [Code], [Sold]) VALUES (35, 2, 24, CAST(N'2021-07-02T22:51:00.367' AS DateTime), CAST(N'2021-07-02T22:51:16.010' AS DateTime), 1, NULL, 13, 0, N'61324', 0)
SET IDENTITY_INSERT [dbo].[Warehouse] OFF
GO
ALTER TABLE [dbo].[Warehouse] ADD  CONSTRAINT [DF_Warehouse_Amount]  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Cookie] FOREIGN KEY([CookieId])
REFERENCES [dbo].[Cookie] ([Id])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Cookie]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Warehouse] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([Id])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Warehouse]
GO
ALTER TABLE [dbo].[Import]  WITH CHECK ADD  CONSTRAINT [FK_Import_ImportUnit] FOREIGN KEY([ImportUnitId])
REFERENCES [dbo].[ImportUnit] ([Id])
GO
ALTER TABLE [dbo].[Import] CHECK CONSTRAINT [FK_Import_ImportUnit]
GO
ALTER TABLE [dbo].[ImportDetail]  WITH CHECK ADD  CONSTRAINT [FK_ImportDetail_Import] FOREIGN KEY([ImportId])
REFERENCES [dbo].[Import] ([Id])
GO
ALTER TABLE [dbo].[ImportDetail] CHECK CONSTRAINT [FK_ImportDetail_Import]
GO
ALTER TABLE [dbo].[ImportDetail]  WITH CHECK ADD  CONSTRAINT [FK_ImportDetail_Warehouse] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([Id])
GO
ALTER TABLE [dbo].[ImportDetail] CHECK CONSTRAINT [FK_ImportDetail_Warehouse]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Province] FOREIGN KEY([ProvinceId])
REFERENCES [dbo].[Province] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Province]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Warehouse] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Warehouse]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Brand]
GO
ALTER TABLE [dbo].[ProductImg]  WITH CHECK ADD  CONSTRAINT [FK_ProductImg_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductImg] CHECK CONSTRAINT [FK_ProductImg_Product]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Province] FOREIGN KEY([ProviceId])
REFERENCES [dbo].[Province] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Province]
GO
ALTER TABLE [dbo].[Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_Warehouse_ProductImg] FOREIGN KEY([ProductImgId])
REFERENCES [dbo].[ProductImg] ([Id])
GO
ALTER TABLE [dbo].[Warehouse] CHECK CONSTRAINT [FK_Warehouse_ProductImg]
GO
ALTER TABLE [dbo].[Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_Warehouse_Size] FOREIGN KEY([SizeId])
REFERENCES [dbo].[Size] ([Id])
GO
ALTER TABLE [dbo].[Warehouse] CHECK CONSTRAINT [FK_Warehouse_Size]
GO
USE [master]
GO
ALTER DATABASE [SHOESSHOP] SET  READ_WRITE 
GO
