USE [MusiSoftBD]
GO
/****** Object:  Table [dbo].[Campaigns]    Script Date: 19/05/2020 9:13:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Campaigns]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Campaigns](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Objective] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[MusicalGenreId] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_Campaigns] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[CampaignsCustomers]    Script Date: 19/05/2020 9:13:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CampaignsCustomers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CampaignsCustomers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CampaignId] [int] NOT NULL,
	[CreationDate] [date] NOT NULL,
 CONSTRAINT [PK_CampaignsCustomers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 19/05/2020 9:13:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Companies]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nit] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 19/05/2020 9:13:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[MusicalGenreId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Identification] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](100) NOT NULL,
	[ResidenceCity] [nvarchar](100) NOT NULL,
	[Gender] [nvarchar](20) NOT NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[MusicGenres]    Script Date: 19/05/2020 9:13:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MusicGenres]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MusicGenres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CampaignId] [int] NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_MusicGenres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Supports]    Script Date: 19/05/2020 9:13:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Supports]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Supports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SupportTypeId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[AplicantName] [nvarchar](100) NOT NULL,
	[AplicantIdentification] [nvarchar](100) NOT NULL,
	[AplicantEmail] [nvarchar](100) NOT NULL,
	[AplicantPhone] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Support] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[SupportTypes]    Script Date: 19/05/2020 9:13:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SupportTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SupportTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_SupportType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Users]    Script Date: 19/05/2020 9:13:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Identification] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Nickname] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 

INSERT [dbo].[Companies] ([Id], [Nit], [Name], [Address], [Phone], [Email]) VALUES (1, N'6582536123-1', N'ARES S.A', N'Manizales, Crr 24 n-65A', N'8704078', N'ares@ares.com')
SET IDENTITY_INSERT [dbo].[Companies] OFF
SET IDENTITY_INSERT [dbo].[MusicGenres] ON 

INSERT [dbo].[MusicGenres] ([Id], [CampaignId], [Name]) VALUES (1, NULL, N'Salsa')
INSERT [dbo].[MusicGenres] ([Id], [CampaignId], [Name]) VALUES (2, NULL, N'Vallenato')
INSERT [dbo].[MusicGenres] ([Id], [CampaignId], [Name]) VALUES (3, NULL, N'Reggueton')
INSERT [dbo].[MusicGenres] ([Id], [CampaignId], [Name]) VALUES (4, NULL, N'Balada')
INSERT [dbo].[MusicGenres] ([Id], [CampaignId], [Name]) VALUES (5, NULL, N'Electronica')
INSERT [dbo].[MusicGenres] ([Id], [CampaignId], [Name]) VALUES (6, NULL, N'Cumbia')
SET IDENTITY_INSERT [dbo].[MusicGenres] OFF
SET IDENTITY_INSERT [dbo].[SupportTypes] ON 

INSERT [dbo].[SupportTypes] ([Id], [Name]) VALUES (1, N'Peticion')
INSERT [dbo].[SupportTypes] ([Id], [Name]) VALUES (2, N'Queja')
INSERT [dbo].[SupportTypes] ([Id], [Name]) VALUES (3, N'Reclamo')
SET IDENTITY_INSERT [dbo].[SupportTypes] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [CompanyId], [Name], [LastName], [Identification], [Phone], [Email], [Nickname], [Password]) VALUES (1, 1, N'Ricardo', N'Urrego', N'1053879654', N'3113228976', N'ricardo@ares.com', N'ricardo', N'123456')
SET IDENTITY_INSERT [dbo].[Users] OFF
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Campaigns_Companies]') AND parent_object_id = OBJECT_ID(N'[dbo].[Campaigns]'))
ALTER TABLE [dbo].[Campaigns]  WITH CHECK ADD  CONSTRAINT [FK_Campaigns_Companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Campaigns_Companies]') AND parent_object_id = OBJECT_ID(N'[dbo].[Campaigns]'))
ALTER TABLE [dbo].[Campaigns] CHECK CONSTRAINT [FK_Campaigns_Companies]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CampaignsCustomers_Companies]') AND parent_object_id = OBJECT_ID(N'[dbo].[CampaignsCustomers]'))
ALTER TABLE [dbo].[CampaignsCustomers]  WITH CHECK ADD  CONSTRAINT [FK_CampaignsCustomers_Companies] FOREIGN KEY([CampaignId])
REFERENCES [dbo].[Campaigns] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CampaignsCustomers_Companies]') AND parent_object_id = OBJECT_ID(N'[dbo].[CampaignsCustomers]'))
ALTER TABLE [dbo].[CampaignsCustomers] CHECK CONSTRAINT [FK_CampaignsCustomers_Companies]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CampaignsCustomers_Customers]') AND parent_object_id = OBJECT_ID(N'[dbo].[CampaignsCustomers]'))
ALTER TABLE [dbo].[CampaignsCustomers]  WITH CHECK ADD  CONSTRAINT [FK_CampaignsCustomers_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CampaignsCustomers_Customers]') AND parent_object_id = OBJECT_ID(N'[dbo].[CampaignsCustomers]'))
ALTER TABLE [dbo].[CampaignsCustomers] CHECK CONSTRAINT [FK_CampaignsCustomers_Customers]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Customers_Companies]') AND parent_object_id = OBJECT_ID(N'[dbo].[Customers]'))
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Customers_Companies]') AND parent_object_id = OBJECT_ID(N'[dbo].[Customers]'))
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Companies]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Customers_MusicGenres]') AND parent_object_id = OBJECT_ID(N'[dbo].[Customers]'))
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_MusicGenres] FOREIGN KEY([MusicalGenreId])
REFERENCES [dbo].[MusicGenres] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Customers_MusicGenres]') AND parent_object_id = OBJECT_ID(N'[dbo].[Customers]'))
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_MusicGenres]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MusicGenres_Campaigns]') AND parent_object_id = OBJECT_ID(N'[dbo].[MusicGenres]'))
ALTER TABLE [dbo].[MusicGenres]  WITH CHECK ADD  CONSTRAINT [FK_MusicGenres_Campaigns] FOREIGN KEY([CampaignId])
REFERENCES [dbo].[Campaigns] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MusicGenres_Campaigns]') AND parent_object_id = OBJECT_ID(N'[dbo].[MusicGenres]'))
ALTER TABLE [dbo].[MusicGenres] CHECK CONSTRAINT [FK_MusicGenres_Campaigns]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Supports_Companies]') AND parent_object_id = OBJECT_ID(N'[dbo].[Supports]'))
ALTER TABLE [dbo].[Supports]  WITH CHECK ADD  CONSTRAINT [FK_Supports_Companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Supports_Companies]') AND parent_object_id = OBJECT_ID(N'[dbo].[Supports]'))
ALTER TABLE [dbo].[Supports] CHECK CONSTRAINT [FK_Supports_Companies]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Supports_SupportTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Supports]'))
ALTER TABLE [dbo].[Supports]  WITH CHECK ADD  CONSTRAINT [FK_Supports_SupportTypes] FOREIGN KEY([SupportTypeId])
REFERENCES [dbo].[SupportTypes] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Supports_SupportTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Supports]'))
ALTER TABLE [dbo].[Supports] CHECK CONSTRAINT [FK_Supports_SupportTypes]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_Companies]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_Companies]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Companies]
GO
