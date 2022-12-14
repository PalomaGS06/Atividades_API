USE [MaisEventos]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 08/08/2022 23:10:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eventos]    Script Date: 08/08/2022 23:10:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eventos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataHora] [datetime] NULL,
	[Ativo] [bit] NULL,
	[Preco] [decimal](6, 2) NULL,
	[CategoriaId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioEvento]    Script Date: 08/08/2022 23:10:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioEvento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NULL,
	[EventoId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 08/08/2022 23:10:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Senha] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([Id], [Categoria]) VALUES (15, N'Show')
INSERT [dbo].[Categorias] ([Id], [Categoria]) VALUES (16, N'Teatro')
INSERT [dbo].[Categorias] ([Id], [Categoria]) VALUES (17, N'Musical')
INSERT [dbo].[Categorias] ([Id], [Categoria]) VALUES (19, N'Palestra')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
SET IDENTITY_INSERT [dbo].[Eventos] ON 

INSERT [dbo].[Eventos] ([Id], [DataHora], [Ativo], [Preco], [CategoriaId]) VALUES (3, CAST(N'2022-09-07T22:20:00.000' AS DateTime), 1, CAST(650.00 AS Decimal(6, 2)), 15)
SET IDENTITY_INSERT [dbo].[Eventos] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuarioEvento] ON 

INSERT [dbo].[UsuarioEvento] ([Id], [UsuarioId], [EventoId]) VALUES (16, 1, 3)
INSERT [dbo].[UsuarioEvento] ([Id], [UsuarioId], [EventoId]) VALUES (17, 2, 3)
INSERT [dbo].[UsuarioEvento] ([Id], [UsuarioId], [EventoId]) VALUES (18, NULL, 3)
INSERT [dbo].[UsuarioEvento] ([Id], [UsuarioId], [EventoId]) VALUES (19, 1, NULL)
SET IDENTITY_INSERT [dbo].[UsuarioEvento] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Nome], [Email], [Senha]) VALUES (1, N'Paloma', N'paloma.souza112@gmail.com', N'123456')
INSERT [dbo].[Usuarios] ([Id], [Nome], [Email], [Senha]) VALUES (2, N'Fernando', N'mnakauti@gmail.com', N'654321')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Eventos]  WITH CHECK ADD FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categorias] ([Id])
GO
ALTER TABLE [dbo].[UsuarioEvento]  WITH CHECK ADD FOREIGN KEY([EventoId])
REFERENCES [dbo].[Eventos] ([Id])
GO
ALTER TABLE [dbo].[UsuarioEvento]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
GO
