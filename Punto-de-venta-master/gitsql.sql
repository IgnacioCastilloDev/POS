USE [negocio]
GO
/****** Object:  Table [dbo].[APERTURA]    Script Date: 28/07/2020 23:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[APERTURA](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hora_apertura] [datetime] NULL,
	[monto] [bigint] NULL,
	[estado] [char](1) NULL,
	[fk_id_usuario] [int] NULL,
	[fk_id_caja] [int] NULL,
 CONSTRAINT [pkAPERTURA] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CAJA]    Script Date: 28/07/2020 23:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CAJA](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[estado] [char](1) NULL,
 CONSTRAINT [pkCAJA] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CATEGORIA]    Script Date: 28/07/2020 23:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIA](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
 CONSTRAINT [pkCATEGORIA] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CIERRE]    Script Date: 28/07/2020 23:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CIERRE](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fk_apertura] [int] NULL,
	[monto_recaudado] [bigint] NULL,
	[diferencia] [int] NULL,
	[estado] [char](1) NULL,
	[fecha] [date] NULL,
 CONSTRAINT [pkCIERRE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DETALLE_VENTA]    Script Date: 28/07/2020 23:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_VENTA](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fk_producto] [bigint] NULL,
	[cantidad] [int] NULL,
	[subtotal] [int] NULL,
	[fk_venta] [bigint] NULL,
 CONSTRAINT [pkDETALLE_VENTA] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 28/07/2020 23:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PRODUCTO](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[codigobarra] [nvarchar](50) NOT NULL,
	[stock] [int] NULL,
	[descripcion] [nvarchar](50) NULL,
	[precio] [int] NULL,
	[fk_id_categoria] [int] NULL,
	[estado] [char](1) NULL,
	[fk_id_promocion] [int] NULL,
 CONSTRAINT [pkPRODUCTO] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PROMOCION]    Script Date: 28/07/2020 23:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PROMOCION](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[condicion] [int] NULL,
	[descuento] [int] NULL,
	[estado] [char](1) NULL,
	[descripcion] [nvarchar](50) NULL,
 CONSTRAINT [pkPROMOCION] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ROL]    Script Date: 28/07/2020 23:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROL](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
 CONSTRAINT [pkROL] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SESION]    Script Date: 28/07/2020 23:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SESION](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NULL,
	[fk_usuario] [int] NULL,
 CONSTRAINT [pkSESION] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 28/07/2020 23:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [nvarchar](50) NULL,
	[password] [nvarchar](20) NULL,
	[nombre] [nvarchar](50) NULL,
	[fk_rol] [int] NULL,
 CONSTRAINT [pkUSUARIO] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VENTA]    Script Date: 28/07/2020 23:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VENTA](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NULL,
	[fk_id_apertura] [int] NULL,
	[total_venta] [int] NULL,
	[subtotal_debito] [int] NULL,
	[subtotal_credito] [int] NULL,
 CONSTRAINT [pkVENTA] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[APERTURA]  WITH CHECK ADD  CONSTRAINT [fk_APERTURA_CAJA] FOREIGN KEY([fk_id_caja])
REFERENCES [dbo].[CAJA] ([id])
GO
ALTER TABLE [dbo].[APERTURA] CHECK CONSTRAINT [fk_APERTURA_CAJA]
GO
ALTER TABLE [dbo].[APERTURA]  WITH CHECK ADD  CONSTRAINT [fk_APERTURA_USUARIO] FOREIGN KEY([fk_id_usuario])
REFERENCES [dbo].[USUARIO] ([id])
GO
ALTER TABLE [dbo].[APERTURA] CHECK CONSTRAINT [fk_APERTURA_USUARIO]
GO
ALTER TABLE [dbo].[CIERRE]  WITH CHECK ADD  CONSTRAINT [fk_CIERRE_APERTURA] FOREIGN KEY([fk_apertura])
REFERENCES [dbo].[APERTURA] ([id])
GO
ALTER TABLE [dbo].[CIERRE] CHECK CONSTRAINT [fk_CIERRE_APERTURA]
GO
ALTER TABLE [dbo].[DETALLE_VENTA]  WITH CHECK ADD  CONSTRAINT [fk_DETALLE_VENTA_PRODUCTO] FOREIGN KEY([fk_producto])
REFERENCES [dbo].[PRODUCTO] ([id])
GO
ALTER TABLE [dbo].[DETALLE_VENTA] CHECK CONSTRAINT [fk_DETALLE_VENTA_PRODUCTO]
GO
ALTER TABLE [dbo].[DETALLE_VENTA]  WITH CHECK ADD  CONSTRAINT [fk_DETALLE_VENTA_VENTA] FOREIGN KEY([fk_venta])
REFERENCES [dbo].[VENTA] ([id])
GO
ALTER TABLE [dbo].[DETALLE_VENTA] CHECK CONSTRAINT [fk_DETALLE_VENTA_VENTA]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [fk_PRODUCTO_CATEGORIA] FOREIGN KEY([fk_id_categoria])
REFERENCES [dbo].[CATEGORIA] ([id])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [fk_PRODUCTO_CATEGORIA]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [fk_PRODUCTO_PROMOCION] FOREIGN KEY([fk_id_promocion])
REFERENCES [dbo].[PROMOCION] ([id])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [fk_PRODUCTO_PROMOCION]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [fk_USUARIO_ROL] FOREIGN KEY([fk_rol])
REFERENCES [dbo].[ROL] ([id])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [fk_USUARIO_ROL]
GO
ALTER TABLE [dbo].[VENTA]  WITH CHECK ADD  CONSTRAINT [fk_VENTA_APERTURA] FOREIGN KEY([fk_id_apertura])
REFERENCES [dbo].[APERTURA] ([id])
GO
ALTER TABLE [dbo].[VENTA] CHECK CONSTRAINT [fk_VENTA_APERTURA]
GO
