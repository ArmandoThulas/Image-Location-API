USE [master]
GO
/****** Object:  Database [ImageLocation]    Script Date: 13/10/2021 09:45:36 ******/
CREATE DATABASE [ImageLocation]

USE [ImageLocation]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 13/10/2021 09:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [varchar](50) NOT NULL,
	[name] [varchar](550) NOT NULL,
	[pluralName] [varchar](255) NULL,
	[shortName] [varchar](50) NULL,
	[primary] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 13/10/2021 09:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[id] [varchar](50) NOT NULL,
	[createdAt] [int] NULL,
	[name] [varchar](550) NULL,
	[url] [varchar](550) NULL,
	[prefix] [varchar](550) NULL,
	[suffix] [varchar](550) NULL,
	[width] [int] NULL,
	[height] [int] NULL,
	[visibility] [varchar](50) NULL,
	[type] [varchar](50) NULL,
	[timeZoneOffset] [int] NULL,
	[venueId] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venue]    Script Date: 13/10/2021 09:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venue](
	[id] [varchar](50) NOT NULL,
	[name] [varchar](500) NOT NULL,
	[verified] [bit] NOT NULL,
	[referralId] [varchar](255) NULL,
	[address] [varchar](255) NULL,
	[lat] [decimal](18, 0) NULL,
	[lng] [decimal](18, 0) NULL,
	[postalCode] [varchar](255) NULL,
	[cc] [varchar](255) NULL,
	[city] [varchar](255) NULL,
	[state] [varchar](255) NULL,
	[country] [varchar](255) NULL,
 CONSTRAINT [PK_Venue] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VenueCategory]    Script Date: 13/10/2021 09:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VenueCategory](
	[id] [uniqueidentifier] NOT NULL,
	[venueId] [varchar](50) NOT NULL,
	[categoryId] [varchar](50) NOT NULL,
 CONSTRAINT [PK_VenueCategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[VenueCategory] ADD  CONSTRAINT [DF_VenueCategory_id]  DEFAULT (newid()) FOR [id]
GO
USE [master]
GO
ALTER DATABASE [ImageLocation] SET  READ_WRITE 
GO
