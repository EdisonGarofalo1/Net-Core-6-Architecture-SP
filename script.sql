USE [dbCarrito2024]
GO
/****** Object:  Table [dbo].[CATEGORIA]    Script Date: 29/03/2024 11:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIA](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Activo] [int] NULL,
 CONSTRAINT [PK__CATEGORI__A3C02A101F3964DB] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CATEGORIA] ADD  CONSTRAINT [DF__CATEGORIA__Activ__440B1D61]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategoriaByID]    Script Date: 29/03/2024 11:17:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROCEDURE [dbo].[DeleteCategoriaByID]
@IdCategoria int
AS
BEGIN
	DELETE FROM CATEGORIA where IdCategoria = @IdCategoria
END
GO
/****** Object:  StoredProcedure [dbo].[insertarModificarCategoria]    Script Date: 29/03/2024 11:17:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertarModificarCategoria]
(
    @IdCategoria  INT=NULL,
    @Nombre varchar(50),
	@Activo int

	
  
)
AS
BEGIN

if not exists (Select IdCategoria from CATEGORIA where  IdCategoria=@IdCategoria)
 begin
  insert  CATEGORIA (Nombre,Activo)values( @Nombre,@Activo)
 end
 else
 begin

    UPDATE CATEGORIA
    SET Nombre = @Nombre,

	  Activo=@Activo

     WHERE IdCategoria = @IdCategoria

end
END
GO
/****** Object:  StoredProcedure [dbo].[insertarModificarCliente]    Script Date: 29/03/2024 11:17:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[insertarModificarCliente]
(
	  @IdCliente int,
      @Nom_persona  varchar(150),
      @direccion varchar(150),
      @telefono varchar(50),
      @cod_sector int,
      @cod_zona int,
      @Activo int
  
)
AS
BEGIN

if not exists (Select   IdCliente  from CLIENTE where    IdCliente =   @IdCliente   )
 begin


  insert  CLIENTE (
       Nom_persona
      ,direccion
      ,telefono
      ,cod_sector
      ,cod_zona
      ,Activo
      )
	  
	  values(   
         @Nom_persona ,
      @direccion ,
      @telefono ,
      @cod_sector ,
      @cod_zona ,
      @Activo 
   );

 end
 else
 begin

    UPDATE CLIENTE
    SET 
	 Nom_persona=@Nom_persona
      ,direccion=@direccion
      ,telefono=@telefono
      ,cod_sector=@cod_sector
      ,cod_zona=@cod_zona
      ,Activo=@Activo
   

     WHERE   IdCliente =    @IdCliente

end
END
GO
/****** Object:  StoredProcedure [dbo].[insertarModificarDetVenta]    Script Date: 29/03/2024 11:17:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[insertarModificarDetVenta]
(
	    @IdDetalleVenta int,
        @IdVenta int,
        @IdProducto int,
        @Cantidad int,
        @PrecioUnidad decimal(10,2),
        @ImporteTotal  decimal(10,2),
        @Activo int,
        @FechaRegistro datetime
  
)
AS
BEGIN

if not exists (Select  IdDetalleVenta from DET_VENTA where   IdDetalleVenta=  @IdDetalleVenta )
 begin


  insert  DET_VENTA (
       IdVenta
      ,IdProducto
      ,Cantidad
      ,PrecioUnidad
      ,ImporteTotal
      ,Activo
      ,FechaRegistro
      )
	  
	  values(   
        @IdVenta ,
        @IdProducto ,
        @Cantidad ,
        @PrecioUnidad ,
        @ImporteTotal  ,
        @Activo ,
        @FechaRegistro
   );

 end
 else
 begin

    UPDATE DET_VENTA
    SET 
	  IdVenta=@IdVenta,
       IdProducto=@IdProducto
      ,Cantidad=@Cantidad
      ,PrecioUnidad=@PrecioUnidad
      ,ImporteTotal=@ImporteTotal
      ,Activo=@Activo
      ,FechaRegistro=@FechaRegistro
   

     WHERE  IdDetalleVenta =   @IdDetalleVenta

end
END
GO
/****** Object:  StoredProcedure [dbo].[insertarModificarProducto]    Script Date: 29/03/2024 11:17:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[insertarModificarProducto](


 @IdProducto int,
 @IdCategoria int,
 @Codigo varchar(13),
 @Nombre varchar(150),
 @Descripcion varchar(150),
 @PrecioVentas float,
 @Stock int,
 @Activo char(1)
)


as
begin

 if not exists( select IdProducto from PRODUCTO where IdProducto= @IdProducto)
 begin

 insert PRODUCTO (IdCategoria,Codigo,Nombre ,Descripcion,PrecioVentas ,Stock ,Activo) 
 
 values( 
 @IdCategoria ,
 @Codigo ,
 @Nombre ,
 @Descripcion,
 @PrecioVentas ,
 @Stock ,
 @Activo)
 end
 else 
 begin
 update PRODUCTO set IdCategoria=@IdCategoria,
                      Codigo= @Codigo,
					   Nombre= @Nombre,
					   Descripcion=@Descripcion,
					   PrecioVentas= @PrecioVentas,
					   Stock = @Stock ,
					   Activo=@Activo

 where  IdProducto= @IdProducto
 end 

end 
GO
/****** Object:  StoredProcedure [dbo].[insertarModificarUsuario]    Script Date: 29/03/2024 11:17:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[insertarModificarUsuario](


@IdUsuario int
      ,@Nombres varchar(150)
      ,@Telefono varchar(10)
      ,@Direccion varchar(150)
      ,@Rol int
      ,@Correo varchar(150)
      ,@Clave varchar(150)
      ,@Activo char(1)

)


as
begin

 if not exists( select IdUsuario from USUARIO where IdUsuario= @IdUsuario)
 begin

 insert USUARIO (Nombres
      ,Telefono
      ,Direccion
      ,Rol
      ,Correo
      ,Clave
      ,Activo) 
 
 values( 
 
      @Nombres 
      ,@Telefono 
      ,@Direccion
	  ,@Rol 
      ,@Correo 
      ,@Clave
      ,@Activo)
 end
 else 
 begin
 update USUARIO set 

 Nombres = @Nombres
      ,Telefono=@Telefono
      ,Direccion=@Direccion
      ,Rol=@Rol
      ,Correo=@Correo
      ,Clave=@Clave
      ,Activo=@Activo
 where  IdUsuario= @IdUsuario
 end 

end 
GO
/****** Object:  StoredProcedure [dbo].[insertarModificarVenta]    Script Date: 29/03/2024 11:17:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[insertarModificarVenta]
(
 
	    @IdVenta int,
        @IdUsuario int,
        @IdCliente int,
        @CantidadProducto int,
        @CantidadTotal int,
        @TotalCosto decimal(10,2),
        @Activo  int,
        @FechaRegistro datetime	
  
)
AS
BEGIN

if not exists (Select IdVenta from VENTA where  IdVenta= @IdVenta )
 begin


  insert  VENTA (
      IdUsuario
      ,IdCliente
      ,CantidadProducto
      ,CantidadTotal
      ,TotalCosto
      ,Activo
      ,FechaRegistro)values(   
        @IdUsuario ,
        @IdCliente ,
        @CantidadProducto ,
        @CantidadTotal ,
        @TotalCosto ,
        @Activo ,
        @FechaRegistro );

 end
 else
 begin

    UPDATE VENTA
    SET IdUsuario=@IdUsuario,
         IdCliente=@IdCliente,
      CantidadProducto=@CantidadProducto,
      CantidadTotal=@CantidadTotal,
      TotalCosto=@TotalCosto,
      Activo=@Activo,
      FechaRegistro=@FechaRegistro

     WHERE IdVenta =  @IdVenta

end
END
GO
/****** Object:  StoredProcedure [dbo].[listaBuscarCategoria]    Script Date: 29/03/2024 11:17:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[listaBuscarCategoria] (
@IdCategoria int=null
)

as
begin

if (@IdCategoria>0)
begin
SELECT  IdCategoria
      ,Nombre
      ,Activo
  FROM CATEGORIA where  IdCategoria =@IdCategoria ;
end
else
begin
SELECT  IdCategoria
      ,Nombre
      ,Activo
  FROM CATEGORIA ;
  end 
end
GO
/****** Object:  StoredProcedure [dbo].[listaBuscarProducto]    Script Date: 29/03/2024 11:17:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[listaBuscarProducto] (
@IdProducto int
)

as
begin

if (@IdProducto>0)
begin
SELECT  IdProducto
      ,IdCategoria
      ,Codigo
      ,Nombre
      ,Descripcion
      ,PrecioVentas
      ,Stock
      ,Activo
  FROM PRODUCTO where  IdProducto =@IdProducto ;
end
else
begin
SELECT  IdProducto
      ,IdCategoria
      ,Codigo
      ,Nombre
      ,Descripcion
      ,PrecioVentas
      ,Stock
      ,Activo
  FROM PRODUCTO;
  end 
end
GO
/****** Object:  StoredProcedure [dbo].[listaBuscarUsuario]    Script Date: 29/03/2024 11:17:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[listaBuscarUsuario] (
@IdUsuario int
)

as
begin 

if (@IdUsuario>0)
begin
SELECT  

       IdUsuario
      ,Nombres
      ,Telefono
      ,Direccion
      ,Rol
      ,Correo
      ,Clave
      ,Activo
  FROM USUARIO where  IdUsuario =@IdUsuario ;
end
else
begin
SELECT IdUsuario
      ,Nombres
      ,Telefono
      ,Direccion
      ,Rol
      ,Correo
      ,Clave
      ,Activo
  FROM USUARIO;
  end 
end
GO
/****** Object:  StoredProcedure [dbo].[listaCategoria]    Script Date: 29/03/2024 11:17:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[listaCategoria] 

as
begin

SELECT  IdCategoria
      ,Nombre
      ,Activo
  FROM CATEGORIA  ;
end
GO
