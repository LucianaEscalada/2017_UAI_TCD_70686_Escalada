USE [sosbelleza]
GO
/****** Object:  Table [dbo].[Antecedentes_medicos]    Script Date: 04/06/2017 03:05:08 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Antecedentes_medicos](
	[Id_cliente] [int] NOT NULL,
	[Enfermedades_o_dolenciascronicas] [varchar](50) NULL,
	[medicamentos_que_toma] [varchar](50) NULL,
	[Alergias_a_productoscosmeticos] [varchar](50) NULL,
	[Antecedentes_cosmeticos] [varchar](50) NULL,
	[Antecedentes_dermatologicos] [varchar](50) NULL,
	[Antecedentes_hormonales] [varchar](50) NULL,
	[Antecedentes_cardiacos] [varchar](50) NULL,
	[Antecedentes_asmaticos] [varchar](50) NULL,
	[Ciclo_menstrual] [varchar](50) NULL,
	[Presion_arterial] [varchar](50) NULL,
	[protesis_dental] [varchar](50) NULL,
	[posibilidades_embarazo] [varchar](50) NULL,
	[constipacion] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[datoscliente]    Script Date: 04/06/2017 03:05:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[datoscliente](
	[Nombreyapellido] [varchar](50) NOT NULL,
	[edad] [int] NOT NULL,
	[Dni] [int] NOT NULL,
	[Mail] [varchar](50) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Localidad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_datoscliente] PRIMARY KEY CLUSTERED 
(
	[Dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Esteticista]    Script Date: 04/06/2017 03:05:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Esteticista](
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Celular] [int] NOT NULL,
	[Id_esteticista] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Esteticista] PRIMARY KEY CLUSTERED 
(
	[Id_esteticista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Familia]    Script Date: 04/06/2017 03:05:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Familia](
	[Familia_id] [int] NOT NULL,
	[Nombrefamilia] [varchar](50) NULL,
 CONSTRAINT [PK_Familia] PRIMARY KEY CLUSTERED 
(
	[Familia_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FamiliaGrupoPatente]    Script Date: 04/06/2017 03:05:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamiliaGrupoPatente](
	[Familia_id] [int] NOT NULL,
	[Grupopatente_id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FamiliaPatente]    Script Date: 04/06/2017 03:05:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamiliaPatente](
	[Familia_id] [int] NOT NULL,
	[Patente_id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GrupoPatente]    Script Date: 04/06/2017 03:05:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GrupoPatente](
	[Grupopatente_id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Formulario] [varchar](50) NOT NULL,
	[Padre] [int] NULL,
 CONSTRAINT [PK_GrupoPatente] PRIMARY KEY CLUSTERED 
(
	[Grupopatente_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Habitosdevida]    Script Date: 04/06/2017 03:05:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Habitosdevida](
	[id_cliente] [int] NOT NULL,
	[deportes] [varchar](50) NULL,
	[Horas_sueño] [int] NULL,
	[tomaAgua] [varchar](50) NULL,
	[fuma] [varchar](50) NULL,
	[dieta] [varchar](50) NULL,
	[tomasol_camasolar] [varchar](50) NULL,
	[lentes_contacto] [varchar](50) NULL,
	[ultima_depilacion] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Patente]    Script Date: 04/06/2017 03:05:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patente](
	[Patente_id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Formulario] [varchar](50) NOT NULL,
	[Padre] [int] NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[Patente_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[producto]    Script Date: 04/06/2017 03:05:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[producto](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[nombre_producto] [varchar](50) NULL,
	[precio_compra] [money] NULL,
	[precio_venta] [money] NULL,
	[cantidad] [int] NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 04/06/2017 03:05:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[proveedor](
	[id_proveedor] [int] NOT NULL,
	[Nombre_proveedor] [varchar](50) NOT NULL,
	[Nombre_compañia] [varchar](50) NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Ciudad] [varchar](50) NOT NULL,
	[cod_postal] [int] NOT NULL,
	[provincia] [varchar](50) NOT NULL,
	[pais] [varchar](50) NOT NULL,
	[telefono] [int] NOT NULL,
	[celular] [int] NOT NULL,
	[mail] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[proveedor_producto]    Script Date: 04/06/2017 03:05:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor_producto](
	[id_proveedor] [int] NOT NULL,
	[id_producto] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tratamientos]    Script Date: 04/06/2017 03:05:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tratamientos](
	[id_tratamiento] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_tratamiento] [varchar](50) NOT NULL,
	[Precio] [money] NOT NULL,
 CONSTRAINT [PK_Tratamientos] PRIMARY KEY CLUSTERED 
(
	[id_tratamiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 04/06/2017 03:05:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Usuario_id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
	[Familia] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[datoscliente] ([Nombreyapellido], [edad], [Dni], [Mail], [Telefono], [Direccion], [Localidad]) VALUES (N'', 0, 0, N' ', 0, N' ', N' ')
INSERT [dbo].[datoscliente] ([Nombreyapellido], [edad], [Dni], [Mail], [Telefono], [Direccion], [Localidad]) VALUES (N'Luciana Escalada', 22, 38290856, N' luciana.escalada94@gmail.com', 1132931491, N' avellaneda 83', N' CABA')
SET IDENTITY_INSERT [dbo].[Esteticista] ON 

INSERT [dbo].[Esteticista] ([Nombre], [Apellido], [Celular], [Id_esteticista]) VALUES (N'asda', N'asdasd', 34234, 1)
INSERT [dbo].[Esteticista] ([Nombre], [Apellido], [Celular], [Id_esteticista]) VALUES (N'pablo', N'aaaaaa', 2121215, 2)
INSERT [dbo].[Esteticista] ([Nombre], [Apellido], [Celular], [Id_esteticista]) VALUES (N'luciana', N'escalada', 1212121, 4)
SET IDENTITY_INSERT [dbo].[Esteticista] OFF
INSERT [dbo].[Familia] ([Familia_id], [Nombrefamilia]) VALUES (8, N'Administrador')
INSERT [dbo].[Familia] ([Familia_id], [Nombrefamilia]) VALUES (19, N'aaaaaa')
INSERT [dbo].[Familia] ([Familia_id], [Nombrefamilia]) VALUES (20, N'Probandofamilia')
INSERT [dbo].[FamiliaGrupoPatente] ([Familia_id], [Grupopatente_id]) VALUES (8, 0)
INSERT [dbo].[FamiliaGrupoPatente] ([Familia_id], [Grupopatente_id]) VALUES (20, 17)
INSERT [dbo].[FamiliaGrupoPatente] ([Familia_id], [Grupopatente_id]) VALUES (20, 17)
INSERT [dbo].[FamiliaPatente] ([Familia_id], [Patente_id]) VALUES (19, 11)
INSERT [dbo].[FamiliaPatente] ([Familia_id], [Patente_id]) VALUES (19, 11)
SET IDENTITY_INSERT [dbo].[GrupoPatente] ON 

INSERT [dbo].[GrupoPatente] ([Grupopatente_id], [Nombre], [Formulario], [Padre]) VALUES (0, N'Patentes del sistema', N'FG', NULL)
INSERT [dbo].[GrupoPatente] ([Grupopatente_id], [Nombre], [Formulario], [Padre]) VALUES (14, N'Grupopatente1', N'', 0)
INSERT [dbo].[GrupoPatente] ([Grupopatente_id], [Nombre], [Formulario], [Padre]) VALUES (15, N'grupopatenteprueba', N'', 0)
INSERT [dbo].[GrupoPatente] ([Grupopatente_id], [Nombre], [Formulario], [Padre]) VALUES (16, N'Probandogrupo', N'', 0)
INSERT [dbo].[GrupoPatente] ([Grupopatente_id], [Nombre], [Formulario], [Padre]) VALUES (17, N'grupopatenteprobando', N'', 0)
SET IDENTITY_INSERT [dbo].[GrupoPatente] OFF
SET IDENTITY_INSERT [dbo].[Patente] ON 

INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Padre]) VALUES (11, N'CrearUsuario', N'WindowsApplication1.Registrarse', 0)
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Padre]) VALUES (12, N'ABMpatentes', N'WindowsApplication1.Patentes', 0)
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Padre]) VALUES (13, N'Asignarpatentes', N'WindowsApplication1.Familia', 0)
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Padre]) VALUES (14, N'Cargarproveedores', N'WindowsApplication1.Formproveedor', 0)
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Padre]) VALUES (15, N'Cargarproducto', N'WindowsApplication1.producto', 0)
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Padre]) VALUES (16, N'Cargartratamiento', N'WindowsApplication1.Tratamientos', 0)
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Padre]) VALUES (17, N'CargarEsteticista', N'WindowsApplication1.Esteticista', 0)
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Padre]) VALUES (19, N'patente', N'WindowsApplication1.producto', 14)
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Padre]) VALUES (20, N'prueba1', N'WindowsApplication1.HistoriaClinica', 15)
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Padre]) VALUES (21, N'prueba', N'WindowsApplication1.HistoriaClinica', 16)
INSERT [dbo].[Patente] ([Patente_id], [Nombre], [Formulario], [Padre]) VALUES (22, N'pruebapatente', N'WindowsApplication1.HistoriaClinica', 17)
SET IDENTITY_INSERT [dbo].[Patente] OFF
SET IDENTITY_INSERT [dbo].[producto] ON 

INSERT [dbo].[producto] ([id_producto], [nombre_producto], [precio_compra], [precio_venta], [cantidad]) VALUES (2, N'Crema hidratante', 30.0000, 50.0000, 20)
SET IDENTITY_INSERT [dbo].[producto] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Usuario_id], [Nombre], [Apellido], [email], [Contraseña], [Familia]) VALUES (2, N'Luciana', N'Escalada', N'luciana.escalada94@gmail.com', N'1234', 8)
INSERT [dbo].[Usuario] ([Usuario_id], [Nombre], [Apellido], [email], [Contraseña], [Familia]) VALUES (6, N'juan', N'perez', N'juanperez@gmail.com', N'1234', 20)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_Familia]  DEFAULT ((0)) FOR [Familia]
GO
ALTER TABLE [dbo].[FamiliaGrupoPatente]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaGrupoPatente_Familia] FOREIGN KEY([Familia_id])
REFERENCES [dbo].[Familia] ([Familia_id])
GO
ALTER TABLE [dbo].[FamiliaGrupoPatente] CHECK CONSTRAINT [FK_FamiliaGrupoPatente_Familia]
GO
ALTER TABLE [dbo].[FamiliaGrupoPatente]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaGrupoPatente_GrupoPatente] FOREIGN KEY([Grupopatente_id])
REFERENCES [dbo].[GrupoPatente] ([Grupopatente_id])
GO
ALTER TABLE [dbo].[FamiliaGrupoPatente] CHECK CONSTRAINT [FK_FamiliaGrupoPatente_GrupoPatente]
GO
ALTER TABLE [dbo].[FamiliaPatente]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaPatente_Familia] FOREIGN KEY([Familia_id])
REFERENCES [dbo].[Familia] ([Familia_id])
GO
ALTER TABLE [dbo].[FamiliaPatente] CHECK CONSTRAINT [FK_FamiliaPatente_Familia]
GO
ALTER TABLE [dbo].[FamiliaPatente]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaPatente_Patente] FOREIGN KEY([Patente_id])
REFERENCES [dbo].[Patente] ([Patente_id])
GO
ALTER TABLE [dbo].[FamiliaPatente] CHECK CONSTRAINT [FK_FamiliaPatente_Patente]
GO
ALTER TABLE [dbo].[GrupoPatente]  WITH CHECK ADD  CONSTRAINT [FK_GrupoPatente_GrupoPatente] FOREIGN KEY([Padre])
REFERENCES [dbo].[GrupoPatente] ([Grupopatente_id])
GO
ALTER TABLE [dbo].[GrupoPatente] CHECK CONSTRAINT [FK_GrupoPatente_GrupoPatente]
GO
ALTER TABLE [dbo].[Patente]  WITH CHECK ADD  CONSTRAINT [FK_Patente_GrupoPatente] FOREIGN KEY([Padre])
REFERENCES [dbo].[GrupoPatente] ([Grupopatente_id])
GO
ALTER TABLE [dbo].[Patente] CHECK CONSTRAINT [FK_Patente_GrupoPatente]
GO
