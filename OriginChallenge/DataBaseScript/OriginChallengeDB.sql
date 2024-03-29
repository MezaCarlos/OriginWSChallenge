USE [OriginChallenge]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 08/15/2020 11:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persona](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Documento] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Email], [Documento]) VALUES (1, N'Carlos', N'Meza', N'cmeza@gmail.com', N'36495410')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Email], [Documento]) VALUES (2, N'Eric', N'Viera', N'eviera@gmail.com', N'32451987')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Email], [Documento]) VALUES (3, N'Leonel', N'Marello', N'emarello@gmail.com', N'20365987')
SET IDENTITY_INSERT [dbo].[Persona] OFF
/****** Object:  Table [dbo].[EstadoTarjeta]    Script Date: 08/15/2020 11:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EstadoTarjeta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoTarjeta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[EstadoTarjeta] ON
INSERT [dbo].[EstadoTarjeta] ([Id], [Descripcion]) VALUES (1, N'Habilitada')
INSERT [dbo].[EstadoTarjeta] ([Id], [Descripcion]) VALUES (2, N'Bloqueada')
SET IDENTITY_INSERT [dbo].[EstadoTarjeta] OFF
/****** Object:  Table [dbo].[EstadoOperacion]    Script Date: 08/15/2020 11:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EstadoOperacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoOperacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[EstadoOperacion] ON
INSERT [dbo].[EstadoOperacion] ([Id], [Descripcion]) VALUES (1, N'Ok')
INSERT [dbo].[EstadoOperacion] ([Id], [Descripcion]) VALUES (2, N'Error')
SET IDENTITY_INSERT [dbo].[EstadoOperacion] OFF
/****** Object:  Table [dbo].[TipoOperacion]    Script Date: 08/15/2020 11:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoOperacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoOperacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TipoOperacion] ON
INSERT [dbo].[TipoOperacion] ([Id], [Descripcion]) VALUES (1, N'Balance')
INSERT [dbo].[TipoOperacion] ([Id], [Descripcion]) VALUES (2, N'Retiro')
SET IDENTITY_INSERT [dbo].[TipoOperacion] OFF
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 08/15/2020 11:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tarjeta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[NumeroCifrado] [varchar](200) NOT NULL,
	[Numero] [varchar](19) NOT NULL,
	[PinCifrado] [varchar](200) NOT NULL,
	[Pin] [int] NOT NULL,
	[FechaVencimiento] [datetime] NOT NULL,
	[Saldo] [decimal](7, 2) NOT NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Tarjeta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Tarjeta] ON
INSERT [dbo].[Tarjeta] ([Id], [IdPersona], [NumeroCifrado], [Numero], [PinCifrado], [Pin], [FechaVencimiento], [Saldo], [Estado]) VALUES (1, 1, N'f9c3452901f46e7536077bfd45d9d1f0d8e79b5e9415854be1a68f425ae52542', N'4540-7856-9852-1456', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 123456, CAST(0x0000BA5800000000 AS DateTime), CAST(50000.00 AS Decimal(7, 2)), 1)
INSERT [dbo].[Tarjeta] ([Id], [IdPersona], [NumeroCifrado], [Numero], [PinCifrado], [Pin], [FechaVencimiento], [Saldo], [Estado]) VALUES (2, 1, N'37584743bf8ed6fbb501e2088146f3d6e6f5ee5df0f80b0edb66cc3ed2e73300', N'4540-2365-8965-2355', N'5214de409e4f511b6eed7b48ec427969e1bb57f6a766c19972b43236929c56b6', 5569, CAST(0x0000B78200000000 AS DateTime), CAST(2000.00 AS Decimal(7, 2)), 2)
SET IDENTITY_INSERT [dbo].[Tarjeta] OFF
/****** Object:  Table [dbo].[Operacion]    Script Date: 08/15/2020 11:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Operacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTarjeta] [int] NOT NULL,
	[IdTipoOperacion] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Codigo] [varchar](20) NOT NULL,
	[Monto] [decimal](7, 2) NOT NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Operacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Operacion_EstadoOperacion]    Script Date: 08/15/2020 11:21:26 ******/
ALTER TABLE [dbo].[Operacion]  WITH CHECK ADD  CONSTRAINT [FK_Operacion_EstadoOperacion] FOREIGN KEY([Estado])
REFERENCES [dbo].[EstadoOperacion] ([Id])
GO
ALTER TABLE [dbo].[Operacion] CHECK CONSTRAINT [FK_Operacion_EstadoOperacion]
GO
/****** Object:  ForeignKey [FK_Operacion_Tarjeta]    Script Date: 08/15/2020 11:21:26 ******/
ALTER TABLE [dbo].[Operacion]  WITH CHECK ADD  CONSTRAINT [FK_Operacion_Tarjeta] FOREIGN KEY([IdTarjeta])
REFERENCES [dbo].[Tarjeta] ([Id])
GO
ALTER TABLE [dbo].[Operacion] CHECK CONSTRAINT [FK_Operacion_Tarjeta]
GO
/****** Object:  ForeignKey [FK_Operacion_TipoOperacion]    Script Date: 08/15/2020 11:21:26 ******/
ALTER TABLE [dbo].[Operacion]  WITH CHECK ADD  CONSTRAINT [FK_Operacion_TipoOperacion] FOREIGN KEY([IdTipoOperacion])
REFERENCES [dbo].[TipoOperacion] ([Id])
GO
ALTER TABLE [dbo].[Operacion] CHECK CONSTRAINT [FK_Operacion_TipoOperacion]
GO
/****** Object:  ForeignKey [FK_Tarjeta_EstadoTarjeta]    Script Date: 08/15/2020 11:21:26 ******/
ALTER TABLE [dbo].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_EstadoTarjeta] FOREIGN KEY([Estado])
REFERENCES [dbo].[EstadoTarjeta] ([Id])
GO
ALTER TABLE [dbo].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_EstadoTarjeta]
GO
/****** Object:  ForeignKey [FK_Tarjeta_Persona]    Script Date: 08/15/2020 11:21:26 ******/
ALTER TABLE [dbo].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_Persona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([Id])
GO
ALTER TABLE [dbo].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_Persona]
GO
