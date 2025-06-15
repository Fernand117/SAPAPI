-- Sucursales
CREATE TABLE Sucursales (
    SucursalId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Direccion VARCHAR(200),
    Ciudad VARCHAR(100),
    Estado VARCHAR(100),
    Telefono VARCHAR(50)
);

-- Empleados
CREATE TABLE Empleados (
    EmpleadoId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    ApellidoPaterno VARCHAR(100) NOT NULL,
    ApellidoMaterno VARCHAR(100),
    FechaNacimiento DATE,
    Genero VARCHAR(20),
    CURP VARCHAR(20),
    RFC VARCHAR(20),
    NSS VARCHAR(20),
    Direccion VARCHAR(200),
    Telefono VARCHAR(50),
    Email VARCHAR(100) UNIQUE,
    FechaIngreso DATE,
    Activo BIT NOT NULL DEFAULT 1,
    SucursalId INT NOT NULL,
    FotoUrl VARCHAR(200),
    CONSTRAINT FK_Empleados_Sucursal FOREIGN KEY (SucursalId) REFERENCES Sucursales(SucursalId)
);

-- Usuarios
CREATE TABLE Usuarios (
    UsuarioId INT IDENTITY(1,1) PRIMARY KEY,
    EmpleadoId INT NOT NULL,
    Username VARCHAR(50) UNIQUE NOT NULL,
    PasswordHash VARCHAR(200) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Usuarios_Empleado FOREIGN KEY (EmpleadoId) REFERENCES Empleados(EmpleadoId)
);

-- Roles
CREATE TABLE Roles (
    RolId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(200)
);

-- Permisos
CREATE TABLE Permisos (
    PermisoId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Modulo VARCHAR(100),
    Descripcion VARCHAR(200)
);

-- UsuarioRol
CREATE TABLE UsuarioRol (
    UsuarioId INT NOT NULL,
    RolId INT NOT NULL,
    PRIMARY KEY (UsuarioId, RolId),
    CONSTRAINT FK_UsuarioRol_Usuario FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId),
    CONSTRAINT FK_UsuarioRol_Rol FOREIGN KEY (RolId) REFERENCES Roles(RolId)
);

-- RolPermiso
CREATE TABLE RolPermiso (
    RolId INT NOT NULL,
    PermisoId INT NOT NULL,
    PRIMARY KEY (RolId, PermisoId),
    CONSTRAINT FK_RolPermiso_Rol FOREIGN KEY (RolId) REFERENCES Roles(RolId),
    CONSTRAINT FK_RolPermiso_Permiso FOREIGN KEY (PermisoId) REFERENCES Permisos(PermisoId)
);

-- CategoriasProducto
CREATE TABLE CategoriasProducto (
    CategoriaId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(200),
    CategoriaPadreId INT NULL,
    CONSTRAINT FK_CategoriasProducto_Padre FOREIGN KEY (CategoriaPadreId) REFERENCES CategoriasProducto(CategoriaId)
);

-- Productos
CREATE TABLE Productos (
    ProductoId INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(50) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(200),
    Marca VARCHAR(100),
    CategoriaId INT NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    ImagenUrl VARCHAR(200),
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Productos_Categoria FOREIGN KEY (CategoriaId) REFERENCES CategoriasProducto(CategoriaId)
);

-- AtributosProducto
CREATE TABLE AtributosProducto (
    AtributoId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    TipoDato VARCHAR(50) NOT NULL, -- texto, número, booleano, fecha, etc.
    CategoriaId INT NOT NULL,
    CONSTRAINT FK_AtributosProducto_Categoria FOREIGN KEY (CategoriaId) REFERENCES CategoriasProducto(CategoriaId)
);

-- ProductoAtributoValor
CREATE TABLE ProductoAtributoValor (
    ProductoId INT NOT NULL,
    AtributoId INT NOT NULL,
    Valor VARCHAR(200),
    PRIMARY KEY (ProductoId, AtributoId),
    CONSTRAINT FK_ProductoAtributoValor_Producto FOREIGN KEY (ProductoId) REFERENCES Productos(ProductoId),
    CONSTRAINT FK_ProductoAtributoValor_Atributo FOREIGN KEY (AtributoId) REFERENCES AtributosProducto(AtributoId)
);

-- Inventario
CREATE TABLE Inventario (
    InventarioId INT IDENTITY(1,1) PRIMARY KEY,
    ProductoId INT NOT NULL,
    SucursalId INT NOT NULL,
    Cantidad INT NOT NULL,
    CONSTRAINT FK_Inventario_Producto FOREIGN KEY (ProductoId) REFERENCES Productos(ProductoId),
    CONSTRAINT FK_Inventario_Sucursal FOREIGN KEY (SucursalId) REFERENCES Sucursales(SucursalId)
);

-- InventarioVendedor
CREATE TABLE InventarioVendedor (
    UsuarioId INT NOT NULL,
    ProductoId INT NOT NULL,
    SucursalId INT NOT NULL,
    Cantidad INT NOT NULL,
    PRIMARY KEY (UsuarioId, ProductoId, SucursalId),
    CONSTRAINT FK_InventarioVendedor_Usuario FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId),
    CONSTRAINT FK_InventarioVendedor_Producto FOREIGN KEY (ProductoId) REFERENCES Productos(ProductoId),
    CONSTRAINT FK_InventarioVendedor_Sucursal FOREIGN KEY (SucursalId) REFERENCES Sucursales(SucursalId)
);

-- UnidadesMoviles
CREATE TABLE UnidadesMoviles (
    UnidadId INT IDENTITY(1,1) PRIMARY KEY,
    SucursalId INT NOT NULL,
    Tipo VARCHAR(50),
    Marca VARCHAR(50),
    Modelo VARCHAR(50),
    Placa VARCHAR(50),
    Activa BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_UnidadesMoviles_Sucursal FOREIGN KEY (SucursalId) REFERENCES Sucursales(SucursalId)
);

-- UsuarioUnidad
CREATE TABLE UsuarioUnidad (
    UsuarioId INT NOT NULL,
    UnidadId INT NOT NULL,
    SucursalId INT NOT NULL,
    FechaAsignacion DATE NOT NULL,
    PRIMARY KEY (UsuarioId, UnidadId, SucursalId),
    CONSTRAINT FK_UsuarioUnidad_Usuario FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId),
    CONSTRAINT FK_UsuarioUnidad_Unidad FOREIGN KEY (UnidadId) REFERENCES UnidadesMoviles(UnidadId),
    CONSTRAINT FK_UsuarioUnidad_Sucursal FOREIGN KEY (SucursalId) REFERENCES Sucursales(SucursalId)
);

-- Clientes
CREATE TABLE Clientes (
    ClienteId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    RFC VARCHAR(20),
    Direccion VARCHAR(200),
    Telefono VARCHAR(50),
    Email VARCHAR(100),
    SucursalId INT NOT NULL,
    CONSTRAINT FK_Clientes_Sucursal FOREIGN KEY (SucursalId) REFERENCES Sucursales(SucursalId)
);

-- Ventas
CREATE TABLE Ventas (
    VentaId INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT NOT NULL,
    ClienteId INT NOT NULL,
    SucursalId INT NOT NULL,
    Fecha DATETIME NOT NULL DEFAULT(GETDATE()),
    Total DECIMAL(18,2) NOT NULL,
    FormaPago VARCHAR(50),
    Notas TEXT,
    FirmaUrl VARCHAR(200),
    UbicacionGeo VARCHAR(100),
    CONSTRAINT FK_Ventas_Usuario FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId),
    CONSTRAINT FK_Ventas_Cliente FOREIGN KEY (ClienteId) REFERENCES Clientes(ClienteId),
    CONSTRAINT FK_Ventas_Sucursal FOREIGN KEY (SucursalId) REFERENCES Sucursales(SucursalId)
);

-- DetalleVenta
CREATE TABLE DetalleVenta (
    DetalleId INT IDENTITY(1,1) PRIMARY KEY,
    VentaId INT NOT NULL,
    ProductoId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_DetalleVenta_Venta FOREIGN KEY (VentaId) REFERENCES Ventas(VentaId),
    CONSTRAINT FK_DetalleVenta_Producto FOREIGN KEY (ProductoId) REFERENCES Productos(ProductoId)
);

-- Asistencias
CREATE TABLE Asistencias (
    AsistenciaId INT IDENTITY(1,1) PRIMARY KEY,
    EmpleadoId INT NOT NULL,
    Fecha DATE NOT NULL,
    HoraEntrada TIME,
    HoraSalida TIME,
    Observaciones VARCHAR(200),
    CONSTRAINT FK_Asistencias_Empleado FOREIGN KEY (EmpleadoId) REFERENCES Empleados(EmpleadoId)
);

-- PermisosSalida
CREATE TABLE PermisosSalida (
    PermisoId INT IDENTITY(1,1) PRIMARY KEY,
    EmpleadoId INT NOT NULL,
    Fecha DATE NOT NULL,
    HoraSalida TIME,
    HoraRegreso TIME,
    Motivo VARCHAR(200),
    Autorizado BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_PermisosSalida_Empleado FOREIGN KEY (EmpleadoId) REFERENCES Empleados(EmpleadoId)
);

-- Incidencias
CREATE TABLE Incidencias (
    IncidenciaId INT IDENTITY(1,1) PRIMARY KEY,
    EmpleadoId INT NOT NULL,
    Fecha DATE NOT NULL,
    Tipo VARCHAR(50), -- Falta, Retardo, SalidaTemprano, etc.
    Descripcion VARCHAR(200),
    Justificada BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Incidencias_Empleado FOREIGN KEY (EmpleadoId) REFERENCES Empleados(EmpleadoId)
);

-- Nominas
CREATE TABLE Nominas (
    NominaId INT IDENTITY(1,1) PRIMARY KEY,
    EmpleadoId INT NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE NOT NULL,
    SueldoBase DECIMAL(18,2) NOT NULL,
    Bonos DECIMAL(18,2) NOT NULL DEFAULT 0,
    Deducciones DECIMAL(18,2) NOT NULL DEFAULT 0,
    TotalPagar DECIMAL(18,2) NOT NULL,
    FechaPago DATE,
    Estado VARCHAR(50), -- Pagada, Pendiente, etc.
    CONSTRAINT FK_Nominas_Empleado FOREIGN KEY (EmpleadoId) REFERENCES Empleados(EmpleadoId)
);

-- Bitacora (Auditoría)
CREATE TABLE Bitacora (
    BitacoraId INT IDENTITY(1,1) PRIMARY KEY,
    FechaHora DATETIME NOT NULL DEFAULT(GETDATE()),
    UsuarioId INT NOT NULL,
    SucursalId INT NOT NULL,
    Accion VARCHAR(50) NOT NULL,         -- Insert, Update, Delete, Login, etc.
    Tabla VARCHAR(100) NOT NULL,         -- Nombre de la tabla afectada
    RegistroId INT NULL,                 -- Id del registro afectado
    Detalles NVARCHAR(MAX) NULL,         -- JSON o texto con los cambios realizados
    IP VARCHAR(50) NULL,                 -- IP del usuario (opcional)
    CONSTRAINT FK_Bitacora_Usuario FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId),
    CONSTRAINT FK_Bitacora_Sucursal FOREIGN KEY (SucursalId) REFERENCES Sucursales(SucursalId)
);