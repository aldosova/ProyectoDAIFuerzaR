use FuerzaR

create table Tipo
(ClaveTipo int primary key,
Nombre varchar(30))

create table Habilidad
(ClaveHabilidad int primary key,
Nombre varchar(30))

create table Estado
(ClaveEstado int primary key,
Nombre varchar(30))

create table Ciudad
(ClaveCiudad int primary key,
Nombre varchar(30),
ClaveEstado int references Estado)

create table Administrador
(ClaveAdministrador int primary key,
Nombre varchar(30),
Correo varchar(30),
Contrasena varchar(30))

create table Sexo
(ClaveSexo int primary key,
Nombre varchar(15))

create table Tarea
(ClaveTarea int primary key,
Descripcion varchar(100),
Domicilio varchar(50),
ClaveEvento int references Evento)

create table Voluntario
(ClaveVoluntario int primary key,
Correo varchar(30),
Contrasena varchar(30),
Nombre varchar(30),
Edad int,
ClaveSexo int references Sexo,
Telefono int,
ClaveCiudad int references Ciudad)

create table Organizacion
(ClaveOrganizacion int primary key,
Correo varchar(30),
Contrasena varchar(30),
Nombre varchar(30),
Telefono int,
Domicilio varchar(30),
ClaveCiudad int references Ciudad)

create table Evento
(ClaveEvento int primary key,
Nombre varchar(30),
FechaInicio datetime not null,
FechaFin datetime,
ClaveCiudad int references Ciudad,
ClaveTipo int references Tipo,
ClaveOrganizacion int references Organizacion)

create table TareaVoluntario
(ClaveTarea int references Tarea,
ClaveVoluntario int references Voluntario,
FechaInicio datetime,
FechaFin datetime,
primary key  (ClaveTarea,ClaveVoluntario))
