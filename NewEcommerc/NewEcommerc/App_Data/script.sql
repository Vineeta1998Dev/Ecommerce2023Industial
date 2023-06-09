USE [ECOMMERCE]
GO
/****** Object:  Table [dbo].[Mstr_categories]    Script Date: 11-05-2023 21:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mstr_categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pid] [int] NULL,
	[Name] [varchar](100) NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[Crd] [datetime] NULL,
	[Crdby] [int] NULL,
	[Lmd] [datetime] NULL,
	[LmdBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mstr_Login]    Script Date: 11-05-2023 21:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mstr_Login](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[Crd] [datetime] NULL,
	[CrdBy] [int] NULL,
	[Lmd] [datetime] NULL,
	[LmdBy] [int] NULL,
 CONSTRAINT [PK_Mstr_Login] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Mstr_categories] ON 

INSERT [dbo].[Mstr_categories] ([Id], [Pid], [Name], [IsActive], [IsDelete], [Crd], [Crdby], [Lmd], [LmdBy]) VALUES (1, 0, N'Foods', 1, 0, CAST(N'2023-05-07 17:01:29.447' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Mstr_categories] ([Id], [Pid], [Name], [IsActive], [IsDelete], [Crd], [Crdby], [Lmd], [LmdBy]) VALUES (2, 0, N'testy', 1, 0, CAST(N'2023-05-07 17:18:15.820' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Mstr_categories] ([Id], [Pid], [Name], [IsActive], [IsDelete], [Crd], [Crdby], [Lmd], [LmdBy]) VALUES (3, 0, N'cloths', 1, 0, CAST(N'2023-05-07 17:18:59.693' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Mstr_categories] ([Id], [Pid], [Name], [IsActive], [IsDelete], [Crd], [Crdby], [Lmd], [LmdBy]) VALUES (4, 0, N'Sweets', 1, 0, CAST(N'2023-05-07 17:20:05.257' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Mstr_categories] ([Id], [Pid], [Name], [IsActive], [IsDelete], [Crd], [Crdby], [Lmd], [LmdBy]) VALUES (5, 0, N'Abhishek', 1, 0, CAST(N'2023-05-08 15:21:41.273' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Mstr_categories] ([Id], [Pid], [Name], [IsActive], [IsDelete], [Crd], [Crdby], [Lmd], [LmdBy]) VALUES (6, 0, N'Tez', 1, 0, CAST(N'2023-05-08 18:03:06.157' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Mstr_categories] ([Id], [Pid], [Name], [IsActive], [IsDelete], [Crd], [Crdby], [Lmd], [LmdBy]) VALUES (7, 0, N'Pallavi', 1, 0, CAST(N'2023-05-08 18:03:56.897' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Mstr_categories] ([Id], [Pid], [Name], [IsActive], [IsDelete], [Crd], [Crdby], [Lmd], [LmdBy]) VALUES (8, 0, N'testing', 1, 0, CAST(N'2023-05-08 20:32:52.990' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Mstr_categories] ([Id], [Pid], [Name], [IsActive], [IsDelete], [Crd], [Crdby], [Lmd], [LmdBy]) VALUES (9, 4, N'Burfi', 1, 0, CAST(N'2023-05-08 20:44:34.390' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Mstr_categories] ([Id], [Pid], [Name], [IsActive], [IsDelete], [Crd], [Crdby], [Lmd], [LmdBy]) VALUES (10, 4, N'Laddu', 1, 0, CAST(N'2023-05-08 21:04:31.893' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Mstr_categories] ([Id], [Pid], [Name], [IsActive], [IsDelete], [Crd], [Crdby], [Lmd], [LmdBy]) VALUES (11, 1, N'Cake', 1, 0, CAST(N'2023-05-08 21:07:51.200' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Mstr_categories] ([Id], [Pid], [Name], [IsActive], [IsDelete], [Crd], [Crdby], [Lmd], [LmdBy]) VALUES (12, 1, N'Fast food', 1, 0, CAST(N'2023-05-11 20:51:22.210' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Mstr_categories] ([Id], [Pid], [Name], [IsActive], [IsDelete], [Crd], [Crdby], [Lmd], [LmdBy]) VALUES (13, 4, N'Agra sweet', 1, 0, CAST(N'2023-05-11 20:52:32.870' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Mstr_categories] ([Id], [Pid], [Name], [IsActive], [IsDelete], [Crd], [Crdby], [Lmd], [LmdBy]) VALUES (14, 4, N'Mathura sweet', 1, 0, CAST(N'2023-05-11 20:53:13.240' AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Mstr_categories] OFF
SET IDENTITY_INSERT [dbo].[Mstr_Login] ON 

INSERT [dbo].[Mstr_Login] ([Id], [UserName], [Password], [Email], [IsActive], [IsDeleted], [Crd], [CrdBy], [Lmd], [LmdBy]) VALUES (1, N'Don', N'12345', N'Don@gmail.com', 1, 0, CAST(N'2023-05-05 19:45:38.533' AS DateTime), 0, NULL, NULL)
INSERT [dbo].[Mstr_Login] ([Id], [UserName], [Password], [Email], [IsActive], [IsDeleted], [Crd], [CrdBy], [Lmd], [LmdBy]) VALUES (2, N'sonu', N'321', N'sonu@gmail.com', 1, 0, CAST(N'2023-05-05 19:45:38.533' AS DateTime), 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Mstr_Login] OFF
