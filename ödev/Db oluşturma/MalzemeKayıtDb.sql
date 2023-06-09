USE [Stok3]
GO
/****** Object:  Table [dbo].[Malzemeler]    Script Date: 12.05.2023 01:29:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Malzemeler](
	[MalzemeKodu] [nchar](10) NOT NULL,
	[MalzemeAdi] [nchar](20) NOT NULL,
	[YillikSatis] [nchar](10) NOT NULL,
	[BirimFiyat] [nchar](10) NOT NULL,
	[MinStok] [nchar](10) NOT NULL,
	[TSuresi] [nchar](10) NOT NULL,
	[Client] [int] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Malzemeler] ([MalzemeKodu], [MalzemeAdi], [YillikSatis], [BirimFiyat], [MinStok], [TSuresi], [Client]) VALUES (N'HM001     ', N'Hammadde 1          ', N'10000     ', N'10        ', N'300       ', N'2         ', 1)
INSERT [dbo].[Malzemeler] ([MalzemeKodu], [MalzemeAdi], [YillikSatis], [BirimFiyat], [MinStok], [TSuresi], [Client]) VALUES (N'HM002     ', N'Hammadde 2          ', N'20500     ', N'5         ', N'600       ', N'3         ', 1)
INSERT [dbo].[Malzemeler] ([MalzemeKodu], [MalzemeAdi], [YillikSatis], [BirimFiyat], [MinStok], [TSuresi], [Client]) VALUES (N'HM003     ', N'Hammadde 3          ', N'359680    ', N'1         ', N'6000      ', N'1         ', 1)
INSERT [dbo].[Malzemeler] ([MalzemeKodu], [MalzemeAdi], [YillikSatis], [BirimFiyat], [MinStok], [TSuresi], [Client]) VALUES (N'HM004     ', N'Hammadde 4          ', N'1000      ', N'25        ', N'10        ', N'8         ', 1)
INSERT [dbo].[Malzemeler] ([MalzemeKodu], [MalzemeAdi], [YillikSatis], [BirimFiyat], [MinStok], [TSuresi], [Client]) VALUES (N'HM005     ', N'Hammadde 5          ', N'1         ', N'1         ', N'1         ', N'1         ', 0)
GO
