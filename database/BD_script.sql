USE [master]

CREATE DATABASE [TPI_G4_Modulo_4]
GO

USE [TPI_G4_Modulo_4]
GO

CREATE TABLE [Barrios](
		[id_barrio] [int] IDENTITY(1,1) NOT NULL,
		[nombre] [varchar] (50) NOT NULL,
		[borrado] [bit],

	CONSTRAINT [PK_Barrios] PRIMARY KEY (id_barrio))

GO

CREATE TABLE [Contactos](
		[id_contacto] [int] IDENTITY(1,1) NOT NULL,
		[nombre] [varchar] (50),
		[apellido] [varchar] (50),
		[email] [varchar] (100),
		[telefono] [int],
		[borrado] [bit],

	CONSTRAINT [PK_Contactos] PRIMARY KEY (id_contacto))

GO

CREATE TABLE [Usuarios](
		[id_usuario] [int] IDENTITY(1,1) NOT NULL,
		[id_perfil] [int],
		[usuario] [varchar] (50),
		[password] [varchar] (50),
		[email] [varchar] (100),
		[estado] [varchar] (100),
		[borrado] [bit],

	CONSTRAINT [PK_Usuarios] PRIMARY KEY (id_usuario))

GO

CREATE TABLE [Clientes](
		[id_cliente] [int] IDENTITY(1,1) NOT NULL,
		[cuit] [int],
		[razon_social] [varchar] (100),
		[calle] [varchar] (100),
		[numero] [int],
		[fecha_alta] [date],
		[id_barrio] [int],
		[id_contacto] [int],
		[borrado] [bit],

	CONSTRAINT [PK_Clientes] PRIMARY KEY (id_cliente),
	CONSTRAINT [FK_Clientes_Barrio] FOREIGN KEY (id_barrio) REFERENCES Barrios (id_barrio),
	CONSTRAINT [FK_Clientes_Contacto] FOREIGN KEY (id_contacto) REFERENCES Contactos (id_contacto))

GO

CREATE TABLE [Productos](
		[id_producto] [int] IDENTITY(1,1) NOT NULL,
		[nombre] [varchar] (50) NOT NULL,
		[borrado] [bit]
		
	CONSTRAINT [PK_Productos] PRIMARY KEY (id_producto))

GO

CREATE TABLE [Proyectos](
		[id_proyecto] [int] IDENTITY(1,1) NOT NULL,
		[id_producto] [int],
		[descripcion] [varchar] (100),
		[version] [varchar] (100),
		[alcance] [varchar] (100),
		[id_responsable] [int] NOT NULL,
		[borrado] [bit],

	CONSTRAINT [PK_Proyectos] PRIMARY KEY (id_proyecto),
	CONSTRAINT [FK_Proyectos_Producto] FOREIGN KEY (id_producto) REFERENCES Productos (id_producto),
	CONSTRAINT [FK_Proyectos_Usuario] FOREIGN KEY (id_responsable) REFERENCES Usuarios (id_usuario))

GO

CREATE TABLE [Facturas](
		[id_factura] [int] IDENTITY(1,1) NOT NULL,
		[nro_factura] [int] NOT NULL,
		[id_cliente] [int] NOT NULL,
		[fecha] [date] NOT NULL,
		[id_usuario_creador] [int] NOT NULL,
		[borrado] [bit],

	CONSTRAINT [PK_Facturas] PRIMARY KEY (id_factura),
	CONSTRAINT [FK_Facturas_Cliente] FOREIGN KEY (id_cliente) REFERENCES Clientes (id_cliente),
	CONSTRAINT [FK_Facturas_Usuario] FOREIGN KEY (id_usuario_creador) REFERENCES Usuarios (id_usuario))

GO


CREATE TABLE [FacturasDetalle](
		[id_detalle_factura] [int] IDENTITY(1,1) NOT NULL,
		[id_factura] [int] NOT NULL,
		[nro_orden] [int] NOT NULL,
		[id_producto] [int],
		[id_proyecto] [int],
		[precio] [DECIMAL] (11,2),
		[borrado] [bit],

	CONSTRAINT [PK_FacturasDetalle] PRIMARY KEY (id_detalle_factura),
	CONSTRAINT [FK_FacturaDetalle_Factura] FOREIGN KEY (id_factura) REFERENCES Facturas (id_factura),
	CONSTRAINT [FK_FacturaDetalle_Producto] FOREIGN KEY (id_producto) REFERENCES Productos (id_producto),
	CONSTRAINT [FK_FacturaDetalle_Proyecto] FOREIGN KEY (id_proyecto) REFERENCES Proyectos (id_proyecto))

GO
