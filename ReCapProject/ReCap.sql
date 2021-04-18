USE [master]
GO
/****** Object:  Database [ReCap]    Script Date: 18.04.2021 23:38:10 ******/
CREATE DATABASE [ReCap]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ReCap', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ReCap.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ReCap_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ReCap_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ReCap] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ReCap].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ReCap] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ReCap] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ReCap] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ReCap] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ReCap] SET ARITHABORT OFF 
GO
ALTER DATABASE [ReCap] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ReCap] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ReCap] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ReCap] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ReCap] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ReCap] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ReCap] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ReCap] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ReCap] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ReCap] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ReCap] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ReCap] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ReCap] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ReCap] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ReCap] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ReCap] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ReCap] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ReCap] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ReCap] SET  MULTI_USER 
GO
ALTER DATABASE [ReCap] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ReCap] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ReCap] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ReCap] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ReCap] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ReCap] SET QUERY_STORE = OFF
GO
USE [ReCap]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 18.04.2021 23:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cards]    Script Date: 18.04.2021 23:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[CardOwnerName] [nvarchar](50) NULL,
	[CardNumber] [nvarchar](50) NULL,
	[CardExpirationDate] [nvarchar](10) NULL,
	[CardCvv] [int] NULL,
 CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarImages]    Script Date: 18.04.2021 23:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NULL,
	[ImagePath] [nvarchar](50) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_CarImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 18.04.2021 23:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[BrandId] [int] NULL,
	[ColorId] [int] NULL,
	[ModelYear] [int] NULL,
	[DailyPrice] [decimal](8, 2) NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 18.04.2021 23:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 18.04.2021 23:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CompanyName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 18.04.2021 23:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Claims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 18.04.2021 23:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentDate] [datetime] NULL,
	[CustomerId] [int] NULL,
	[CardId] [int] NULL,
	[Total] [decimal](8, 2) NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 18.04.2021 23:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NULL,
	[CustomerId] [int] NULL,
	[RentDate] [datetime] NULL,
	[ReturnDate] [datetime] NULL,
 CONSTRAINT [PK_Rental] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 18.04.2021 23:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
 CONSTRAINT [PK_UserOperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 18.04.2021 23:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[PasswordHash] [varbinary](500) NULL,
	[PasswordSalt] [varbinary](500) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 
GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (1, N'Opel')
GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (4, N'Ford')
GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (5, N'BMW')
GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (6, N'Audi')
GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (12, N'Mercedes')
GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (13, N'12222')
GO
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Cards] ON 
GO
INSERT [dbo].[Cards] ([Id], [CustomerId], [CardOwnerName], [CardNumber], [CardExpirationDate], [CardCvv]) VALUES (1, 1, N'ahmet', N'1', N'2', 3)
GO
INSERT [dbo].[Cards] ([Id], [CustomerId], [CardOwnerName], [CardNumber], [CardExpirationDate], [CardCvv]) VALUES (2, 1, N'werwerwre', N'12345678', N'12/25', 666)
GO
SET IDENTITY_INSERT [dbo].[Cards] OFF
GO
SET IDENTITY_INSERT [dbo].[CarImages] ON 
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1, 6, N'8dffc603-3ac0-47b0-b194-a63edec64c0f.png', CAST(N'2021-03-17T14:22:15.807' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2, 6, N'0867d119-8a35-4e57-a352-a17be1ff2ac2.png', CAST(N'2021-03-17T14:22:25.593' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (3, 6, N'ccb15c94-8267-4f30-89cb-3e1671e51bb2.png', CAST(N'2021-03-17T14:22:30.280' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (4, 4, N'7d259b2c-0f23-4f9a-90ef-639c9869ace9.png', CAST(N'2021-03-17T14:29:14.050' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (5, 1, N'b1d52525-f189-464b-9a61-a5a6ce0e9b5b.png', CAST(N'2021-03-17T14:29:36.443' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (6, 8, N'767001e5-f16c-49c2-b4a3-18f5440b4434.jpg', CAST(N'2021-04-06T01:51:31.340' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (7, 9, N'067f2343-02f4-4660-a7c7-61d8f07a857c.jpg', CAST(N'2021-04-06T02:01:11.423' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (14, 7, N'89d5d700-44a8-415b-a4d9-121e4cb2fc00.jpg', CAST(N'2021-04-11T17:09:55.077' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (43, 11, N'a8883e2b-090b-4144-a473-60bb83a07e61.jpg', CAST(N'2021-04-14T12:58:23.803' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (44, 11, N'080efd1a-152f-4f74-88b4-6ce6f583985e.jpg', CAST(N'2021-04-14T13:19:46.070' AS DateTime))
GO
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (45, 11, N'e2db6485-36d7-4d01-b207-1efb1409218a.jpg', CAST(N'2021-04-14T13:40:48.860' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[CarImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 
GO
INSERT [dbo].[Cars] ([Id], [Name], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (1, N'Yeni Opel Corsa', 1, 3, 2021, CAST(770.00 AS Decimal(8, 2)), N'Öncü teknolojileri, keyifli sürüş ve performans sunuyor.')
GO
INSERT [dbo].[Cars] ([Id], [Name], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (4, N'Yeni Ford Focus', 4, 2, 2021, CAST(950.00 AS Decimal(8, 2)), N'Ergonomik tasarımı, şık ve geniş iç mekanı yüksek konfor sunuyor.')
GO
INSERT [dbo].[Cars] ([Id], [Name], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (6, N'Yeni BMW M5', 5, 5, 2021, CAST(1250.00 AS Decimal(8, 2)), N'5 Serisi Sedanlar konforu ve zarafetiyle olağanüstü bir deneyim yaşatıyor.')
GO
INSERT [dbo].[Cars] ([Id], [Name], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (7, N'Opel Astra Hatchback', 1, 6, 2021, CAST(950.00 AS Decimal(8, 2)), N'Çok güzel bir araba')
GO
INSERT [dbo].[Cars] ([Id], [Name], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (8, N'Ford Mustang', 4, 4, 2020, CAST(1600.00 AS Decimal(8, 2)), N'Harika bir yer uçağı')
GO
INSERT [dbo].[Cars] ([Id], [Name], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (9, N'BMW M4 Toronto', 5, 3, 2021, CAST(1550.00 AS Decimal(8, 2)), N'Harika bir araç')
GO
INSERT [dbo].[Cars] ([Id], [Name], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (10, N'Yeni Ford Focus', 4, 2, 2021, CAST(950.00 AS Decimal(8, 2)), N'Ergonomik tasarımı, şık ve geniş iç mekanı yüksek konfor sunuyor.')
GO
INSERT [dbo].[Cars] ([Id], [Name], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (11, N'Ford Fiesta', 4, 2, 2011, CAST(950.00 AS Decimal(8, 2)), N'Ergonomik tasarımı, şık ve geniş iç mekanı yüksek konfor sunuyor.')
GO
INSERT [dbo].[Cars] ([Id], [Name], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (12, N'Ford C-Max', 4, 2, 2020, CAST(550.00 AS Decimal(8, 2)), N'Geniş ve Uzun Araç')
GO
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 
GO
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (2, N'Beyaz')
GO
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (3, N'Kırmızı')
GO
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (4, N'Sarı')
GO
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (5, N'Gri')
GO
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (6, N'Mavi')
GO
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (1, 1, N'Firma Adı')
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (1, N'car.add')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (2, N'carimage.add')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (3, N'admin')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (4, N'carimage.delete')
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 
GO
INSERT [dbo].[Payments] ([Id], [PaymentDate], [CustomerId], [CardId], [Total]) VALUES (1, CAST(N'2021-04-10T16:34:06.457' AS DateTime), 1, 0, CAST(950.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[Payments] ([Id], [PaymentDate], [CustomerId], [CardId], [Total]) VALUES (2, CAST(N'2021-04-10T16:43:11.950' AS DateTime), 1, 1, CAST(3750.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[Payments] ([Id], [PaymentDate], [CustomerId], [CardId], [Total]) VALUES (3, CAST(N'2021-04-10T16:47:34.850' AS DateTime), 1, 1, CAST(3800.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[Payments] ([Id], [PaymentDate], [CustomerId], [CardId], [Total]) VALUES (4, CAST(N'2021-04-11T21:05:15.427' AS DateTime), 1, 1, CAST(3800.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[Payments] ([Id], [PaymentDate], [CustomerId], [CardId], [Total]) VALUES (5, CAST(N'2021-04-11T21:07:25.977' AS DateTime), 1, 1, CAST(1900.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[Payments] ([Id], [PaymentDate], [CustomerId], [CardId], [Total]) VALUES (6, CAST(N'2021-04-11T21:29:55.200' AS DateTime), 1, 1, CAST(1900.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[Payments] ([Id], [PaymentDate], [CustomerId], [CardId], [Total]) VALUES (7, CAST(N'2021-04-11T21:30:15.203' AS DateTime), 1, 1, CAST(2500.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[Payments] ([Id], [PaymentDate], [CustomerId], [CardId], [Total]) VALUES (8, CAST(N'2021-04-11T21:45:19.447' AS DateTime), 1, 1, CAST(1550.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[Payments] ([Id], [PaymentDate], [CustomerId], [CardId], [Total]) VALUES (9, CAST(N'2021-04-14T12:20:14.710' AS DateTime), 1, 0, CAST(6250.00 AS Decimal(8, 2)))
GO
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[Rentals] ON 
GO
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (5, 7, 1, CAST(N'2021-04-11T00:00:00.000' AS DateTime), CAST(N'2021-04-11T21:29:39.140' AS DateTime))
GO
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (6, 4, 1, CAST(N'2021-04-11T00:00:00.000' AS DateTime), CAST(N'2021-04-11T21:30:19.337' AS DateTime))
GO
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (7, 6, 1, CAST(N'2021-04-11T00:00:00.000' AS DateTime), CAST(N'2021-04-11T21:30:23.087' AS DateTime))
GO
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (8, 9, 1, CAST(N'2021-04-11T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (9, 6, 1, CAST(N'2021-04-16T00:00:00.000' AS DateTime), CAST(N'2021-04-14T12:21:48.240' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Rentals] OFF
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] ON 
GO
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (2, 1, 2)
GO
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (3, 1, 3)
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (1, N'ahmet', N'erdoğan', N'test@test.com', 0xBAB8895B428753B4D5CDB209E38DA8D953468F7C257E949B30B961CCD189141D6BCCE5858C741594C14FBA4CEED02EE02B0E03AE46DB9A1803D811124F96E2DF, 0x652EC3F2AA560A3C42DFEF9C16CC17651F70D16466AED802DF673B68AD70AF342B477D589CE9B2E99A586C00AB2E32EE755E42FC992A2B822F05AAD6522C699EA9C7492D024B1544AB7D21D37D3F35540DA35493D732272805F1F4697CAE5A3F417B761CC144C029F5113C64B3DB15EEEA7FC545D223FC097ECBD4459EC0C4A1, 1)
GO
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (3, N'Test', N'Kullanıcısı', N'd@d.com', 0x463D9331FAA8973450843D804AFE53F579F4E056D162A55ED93E4E65F200C023E2B9C3A8D6251A22589841ECB111B8FC1084EFDDA38EA6C71B1DAA7F48359D08, 0x748B064ACCB03A66ED8EF29170A5BCFFF1AB985C5E53C4EECF52630D321308A4BBD9EAF924DBE3F5E94B48DC69B5CB092D83F5A84EECDE60D924E6A17E3C65C56C8AEB209E2346B3ABF57AF7CD2C7C50E2E9E5A5E00CA2D640F2C4802B2ED8A26D9B5470736E6D8D4EF1C92FCB801C1028D5809DDEC13F198A2CBCF88BE1A2EC, 1)
GO
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (4, N'deneme', N'deneme', N'deneme1@deneme.com', 0x9D8FAD0D547964CAB5F4002F9A4644D7F62CB1F640CC5DB2394294FC6E9B0F5639835196AEEEE13BEBE3F3B964AF1A7FC6875DEDDDEC1C4F8A4B00D005B58683, 0x6E04452E94321A9535F9672F5A972602A26050113C8F063D83E6A8E3A90C40F747B5D36BAB0C7EC9342FF9CC05778D5AF2C6889DB131FC9B94619BDCAC379F1AC1372AC58FF14EE28A72DD0B2662C95F48F13C24B2A995A85CE63459B77FC3437904DB4F1311BAE0DC0606F1E6A7BF41F843F2FEE2759C95CB8FD9D1A6CBE8E9, 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
USE [master]
GO
ALTER DATABASE [ReCap] SET  READ_WRITE 
GO

