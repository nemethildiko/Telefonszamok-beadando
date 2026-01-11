USE master
GO

IF DB_ID('Telefonszamok') IS NULL
BEGIN
    CREATE DATABASE Telefonszamok
END
GO

USE Telefonszamok
GO


CREATE TABLE [dbo].[Helyseg](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[IRSZ] [nvarchar](128) NOT NULL,
	[Nev] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Helyseg] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Szemely]    Script Date: 2025. 03. 31. 8:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Szemely](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Vezeteknev] [nvarchar](4000) NULL,
	[Utonev] [nvarchar](4000) NULL,
	[Lakcim] [nvarchar](4000) NULL,
	[enHelysegid] [int] NULL,
 CONSTRAINT [PK_Szemely] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telefonszamok]    Script Date: 2025. 03. 31. 8:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telefonszamok](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Szam] [nvarchar](4000) NULL,
	[enSzemelyid] [int] NULL,
 CONSTRAINT [PK_Telefonszamok] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Helyseg] ON 
GO
INSERT [dbo].[Helyseg] ([id], [IRSZ], [Nev]) VALUES (1, N'3400', N'Mezőkövesd')
GO
INSERT [dbo].[Helyseg] ([id], [IRSZ], [Nev]) VALUES (2, N'6000', N'Kecskemét')
GO
INSERT [dbo].[Helyseg] ([id], [IRSZ], [Nev]) VALUES (3, N'1183', N'Budapest')
GO
INSERT [dbo].[Helyseg] ([id], [IRSZ], [Nev]) VALUES (4, N'3500', N'Miskolc')
GO
SET IDENTITY_INSERT [dbo].[Helyseg] OFF
GO
SET IDENTITY_INSERT [dbo].[Szemely] ON 
GO
INSERT [dbo].[Szemely] ([id], [Vezeteknev], [Utonev], [Lakcim], [enHelysegid]) VALUES (1, N'Teszt', N'Elek', N'Valahol', 2)
GO
INSERT [dbo].[Szemely] ([id], [Vezeteknev], [Utonev], [Lakcim], [enHelysegid]) VALUES (2, N'Mekk', N'Elek', N'Futrinka utca', 4)
GO
INSERT [dbo].[Szemely] ([id], [Vezeteknev], [Utonev], [Lakcim], [enHelysegid]) VALUES (3, N'Piszkos', N'Fred', N'Balmoral', 1)
GO
SET IDENTITY_INSERT [dbo].[Szemely] OFF
GO
SET IDENTITY_INSERT [dbo].[Telefonszamok] ON 
GO
INSERT [dbo].[Telefonszamok] ([id], [Szam], [enSzemelyid]) VALUES (1, N'0612223333', 1)
GO
INSERT [dbo].[Telefonszamok] ([id], [Szam], [enSzemelyid]) VALUES (2, N'06203334444', 2)
GO
INSERT [dbo].[Telefonszamok] ([id], [Szam], [enSzemelyid]) VALUES (3, N'06704445555', 2)
GO
INSERT [dbo].[Telefonszamok] ([id], [Szam], [enSzemelyid]) VALUES (4, N'06901111111', 3)
GO
SET IDENTITY_INSERT [dbo].[Telefonszamok] OFF
GO
ALTER TABLE [dbo].[Szemely]  WITH CHECK ADD  CONSTRAINT [FK_Szemely_Helyseg_0] FOREIGN KEY([enHelysegid])
REFERENCES [dbo].[Helyseg] ([id])
GO
ALTER TABLE [dbo].[Szemely] CHECK CONSTRAINT [FK_Szemely_Helyseg_0]
GO
ALTER TABLE [dbo].[Telefonszamok]  WITH CHECK ADD  CONSTRAINT [FK_Telefonszamok_Szemely_0] FOREIGN KEY([enSzemelyid])
REFERENCES [dbo].[Szemely] ([id])
GO
ALTER TABLE [dbo].[Telefonszamok] CHECK CONSTRAINT [FK_Telefonszamok_Szemely_0]
GO
USE [master]
GO
ALTER DATABASE [Telefonszamok] SET  READ_WRITE 
GO
