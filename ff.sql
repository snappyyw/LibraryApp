USE [master]
GO
/****** Object:  Database [LibraryDB]    Script Date: 03.11.2020 3:12:23 ******/
CREATE DATABASE [LibraryDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\LibraryDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LibraryDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\LibraryDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LibraryDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibraryDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibraryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryDB] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [LibraryDB]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 03.11.2020 3:12:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Author] [nvarchar](50) NOT NULL,
	[PublicationDate] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CoverImage] [varbinary](max) NULL,
	[Genre] [nvarchar](max) NOT NULL,
	[NumberOfCopies] [int] NOT NULL,
	[PublishedBooks] [bit] NOT NULL,
	[PenaltyPoint] [int] NOT NULL,
	[Tags] [nvarchar](max) NULL,
	[IsBlocked] [bit] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Journal]    Script Date: 03.11.2020 3:12:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookingStartDate] [datetime] NOT NULL,
	[BookingEndDate] [datetime] NULL,
	[ReservationCode] [int] NOT NULL,
	[BookingStatus] [nvarchar](50) NOT NULL,
	[IdReader] [int] NOT NULL,
	[IdBook] [int] NOT NULL,
 CONSTRAINT [PK_Journal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Readers]    Script Date: 03.11.2020 3:12:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Readers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[Telephone] [nvarchar](50) NULL,
	[IsEmployee] [bit] NOT NULL,
	[ReaderRating] [int] NOT NULL,
	[IdUser] [int] NOT NULL,
 CONSTRAINT [PK_Readers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Status]    Script Date: 03.11.2020 3:12:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 03.11.2020 3:12:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IsBlocked] [bit] NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Name], [Author], [PublicationDate], [Description], [CoverImage], [Genre], [NumberOfCopies], [PublishedBooks], [PenaltyPoint], [Tags], [IsBlocked]) VALUES (12, N'По ту сторону добра и зла', N'Ницше', 1890, N'Одна из книг которая способна поменять мир', NULL, N'Фил', 1250, 1, 2, N'Философия', 0)
INSERT [dbo].[Books] ([Id], [Name], [Author], [PublicationDate], [Description], [CoverImage], [Genre], [NumberOfCopies], [PublishedBooks], [PenaltyPoint], [Tags], [IsBlocked]) VALUES (13, N'Snaff', N'Пелевин', 2005, N'Одна из работ великого русского автора.', NULL, N'Алтернатива', 150, 0, 10, N'', 1)
INSERT [dbo].[Books] ([Id], [Name], [Author], [PublicationDate], [Description], [CoverImage], [Genre], [NumberOfCopies], [PublishedBooks], [PenaltyPoint], [Tags], [IsBlocked]) VALUES (17, N'Gener P', N'Пелевин', 2001, N'Альтернатива', NULL, N'Альтернатива', 50, 0, 2, N'Альтернатива', 1)
SET IDENTITY_INSERT [dbo].[Books] OFF
SET IDENTITY_INSERT [dbo].[Journal] ON 

INSERT [dbo].[Journal] ([Id], [BookingStartDate], [BookingEndDate], [ReservationCode], [BookingStatus], [IdReader], [IdBook]) VALUES (3, CAST(0x0000AC6800000000 AS DateTime), CAST(0x0000AC6900000000 AS DateTime), 676, N'Отказано', 11, 12)
INSERT [dbo].[Journal] ([Id], [BookingStartDate], [BookingEndDate], [ReservationCode], [BookingStatus], [IdReader], [IdBook]) VALUES (4, CAST(0x0000AC68000FAE9A AS DateTime), NULL, 473, N'Ожидает подтверждения', 12, 12)
SET IDENTITY_INSERT [dbo].[Journal] OFF
SET IDENTITY_INSERT [dbo].[Readers] ON 

INSERT [dbo].[Readers] ([Id], [FIO], [DateOfBirth], [Telephone], [IsEmployee], [ReaderRating], [IdUser]) VALUES (11, N'g', NULL, N'', 0, 5, 20)
INSERT [dbo].[Readers] ([Id], [FIO], [DateOfBirth], [Telephone], [IsEmployee], [ReaderRating], [IdUser]) VALUES (12, N'Net', NULL, N'', 0, 10, 22)
INSERT [dbo].[Readers] ([Id], [FIO], [DateOfBirth], [Telephone], [IsEmployee], [ReaderRating], [IdUser]) VALUES (14, N'ffff', NULL, N'', 0, 5, 24)
SET IDENTITY_INSERT [dbo].[Readers] OFF
INSERT [dbo].[Status] ([Status]) VALUES (N'Возвращено')
INSERT [dbo].[Status] ([Status]) VALUES (N'Кинга передана читателю')
INSERT [dbo].[Status] ([Status]) VALUES (N'Ожидает подтверждения')
INSERT [dbo].[Status] ([Status]) VALUES (N'Отказано')
INSERT [dbo].[Status] ([Status]) VALUES (N'Принято')
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Login], [Password], [IsBlocked], [Role]) VALUES (1, N'Snippy', N'62306230', 0, N'Администратор')
INSERT [dbo].[Users] ([Id], [Login], [Password], [IsBlocked], [Role]) VALUES (20, N'Jon', N'1', 0, N'Ч')
INSERT [dbo].[Users] ([Id], [Login], [Password], [IsBlocked], [Role]) VALUES (22, N'Jopa', N'1', 0, N'Библиотекарь')
INSERT [dbo].[Users] ([Id], [Login], [Password], [IsBlocked], [Role]) VALUES (24, N'123', N'q', 0, N'Читатель')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Journal]  WITH CHECK ADD  CONSTRAINT [FK_Journal_Books] FOREIGN KEY([IdBook])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[Journal] CHECK CONSTRAINT [FK_Journal_Books]
GO
ALTER TABLE [dbo].[Journal]  WITH CHECK ADD  CONSTRAINT [FK_Journal_Readers] FOREIGN KEY([IdReader])
REFERENCES [dbo].[Readers] ([Id])
GO
ALTER TABLE [dbo].[Journal] CHECK CONSTRAINT [FK_Journal_Readers]
GO
ALTER TABLE [dbo].[Journal]  WITH CHECK ADD  CONSTRAINT [FK_Journal_Status] FOREIGN KEY([BookingStatus])
REFERENCES [dbo].[Status] ([Status])
GO
ALTER TABLE [dbo].[Journal] CHECK CONSTRAINT [FK_Journal_Status]
GO
ALTER TABLE [dbo].[Readers]  WITH CHECK ADD  CONSTRAINT [FK_Readers_Users] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Readers] CHECK CONSTRAINT [FK_Readers_Users]
GO
USE [master]
GO
ALTER DATABASE [LibraryDB] SET  READ_WRITE 
GO
