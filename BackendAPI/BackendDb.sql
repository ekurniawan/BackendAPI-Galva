USE [master]
GO
/****** Object:  Database [BackendDb]    Script Date: 05/07/2017 09:53:28 ******/
CREATE DATABASE [BackendDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BackendDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BackendDb.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BackendDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BackendDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BackendDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BackendDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BackendDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BackendDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BackendDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BackendDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BackendDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [BackendDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BackendDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BackendDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BackendDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BackendDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BackendDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BackendDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BackendDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BackendDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BackendDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BackendDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BackendDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BackendDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BackendDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BackendDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BackendDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BackendDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BackendDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BackendDb] SET  MULTI_USER 
GO
ALTER DATABASE [BackendDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BackendDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BackendDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BackendDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BackendDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BackendDb]
GO
/****** Object:  User [IIS APPPOOL\MyServices]    Script Date: 05/07/2017 09:53:28 ******/
CREATE USER [IIS APPPOOL\MyServices] FOR LOGIN [IIS APPPOOL\MyServices] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\MyServices]
GO
/****** Object:  Table [dbo].[Barang]    Script Date: 05/07/2017 09:53:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Barang](
	[BarangID] [nvarchar](50) NOT NULL,
	[KategoriID] [int] NOT NULL,
	[NamaBarang] [nvarchar](50) NOT NULL,
	[Deskripsi] [nvarchar](250) NULL,
	[Stok] [int] NOT NULL CONSTRAINT [DF_Barang_Stok]  DEFAULT ((0)),
	[HargaBeli] [money] NOT NULL CONSTRAINT [DF_Barang_HargaBeli]  DEFAULT ((0)),
	[HargaJual] [money] NOT NULL CONSTRAINT [DF_Barang_HargaJual]  DEFAULT ((0)),
	[Gambar] [nvarchar](150) NULL,
 CONSTRAINT [PK_Barang] PRIMARY KEY CLUSTERED 
(
	[BarangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kategori]    Script Date: 05/07/2017 09:53:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategori](
	[KategoriID] [int] IDENTITY(1,1) NOT NULL,
	[NamaKategori] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Kategori] PRIMARY KEY CLUSTERED 
(
	[KategoriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[ViewBarangWithKategori]    Script Date: 05/07/2017 09:53:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewBarangWithKategori]
AS
SELECT        dbo.Barang.BarangID, dbo.Barang.KategoriID, dbo.Kategori.NamaKategori, dbo.Barang.NamaBarang, dbo.Barang.Deskripsi, dbo.Barang.Stok, dbo.Barang.HargaBeli, dbo.Barang.HargaJual, 
                         dbo.Barang.Gambar
FROM            dbo.Barang INNER JOIN
                         dbo.Kategori ON dbo.Barang.KategoriID = dbo.Kategori.KategoriID

GO
INSERT [dbo].[Barang] ([BarangID], [KategoriID], [NamaBarang], [Deskripsi], [Stok], [HargaBeli], [HargaJual], [Gambar]) VALUES (N'jacket101', 2, N'Bamboo thermal ski coat', N'You’ll be the most environmentally conscious skier on the slopes - and the most stylish - wearing our fitted bamboo thermal ski coat, made from organic bamboo with recycled plastic down filling.', 5, 400000.0000, 450000.0000, N'jacket101.png')
INSERT [dbo].[Barang] ([BarangID], [KategoriID], [NamaBarang], [Deskripsi], [Stok], [HargaBeli], [HargaJual], [Gambar]) VALUES (N'pants101', 3, N'Stretchy dance pants', N'Whether dancing the samba, mastering a yoga pose, or scaling the climbing wall, our stretchy dance pants, made from 80% organic cotton and 20% Lycra, are the most versatile and comfortable workout pants you’ll ever have the pleasure of wearing.', 10, 250000.0000, 280000.0000, N'pants101.png')
INSERT [dbo].[Barang] ([BarangID], [KategoriID], [NamaBarang], [Deskripsi], [Stok], [HargaBeli], [HargaJual], [Gambar]) VALUES (N'shirt101', 1, N'Cross-back training tank', N'Our cross-back training tank is made from organic cotton with 10% Lycra for form and support, and a flattering feminine cut.', 11, 350000.0000, 370000.0000, N'shirt101.png')
SET IDENTITY_INSERT [dbo].[Kategori] ON 

INSERT [dbo].[Kategori] ([KategoriID], [NamaKategori]) VALUES (1, N'Shirt')
INSERT [dbo].[Kategori] ([KategoriID], [NamaKategori]) VALUES (2, N'Jacket')
INSERT [dbo].[Kategori] ([KategoriID], [NamaKategori]) VALUES (3, N'Pants')
INSERT [dbo].[Kategori] ([KategoriID], [NamaKategori]) VALUES (4, N'Vest')
INSERT [dbo].[Kategori] ([KategoriID], [NamaKategori]) VALUES (5, N'Blouse')
SET IDENTITY_INSERT [dbo].[Kategori] OFF
ALTER TABLE [dbo].[Barang]  WITH CHECK ADD  CONSTRAINT [FK_Barang_Kategori] FOREIGN KEY([KategoriID])
REFERENCES [dbo].[Kategori] ([KategoriID])
GO
ALTER TABLE [dbo].[Barang] CHECK CONSTRAINT [FK_Barang_Kategori]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[21] 2[14] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Barang"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "Kategori"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 102
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewBarangWithKategori'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewBarangWithKategori'
GO
USE [master]
GO
ALTER DATABASE [BackendDb] SET  READ_WRITE 
GO
