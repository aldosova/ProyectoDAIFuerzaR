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

create table Tarea
(ClaveTarea int primary key,
Descripcion varchar(100),
FechaInicio datetime not null,
FechaFin datetime)

create table Voluntario
(ClaveVoluntario int primary key,
Correo varchar(30),
Contrasena varchar(30),
Nombre varchar(30),
Edad int,
Sexo varchar(1),
Telefono int,
CURP varchar(18),
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


create table HabilidadVoluntario
(ClaveHabilidad int references Habilidad,
ClaveVoluntario int references Voluntario,
primary key (ClaveHabilidad,ClaveVoluntario))

create table HabilidadTarea
(ClaveHabilidad int references Habilidad,
ClaveTarea int references Tarea,
primary key (ClaveHabilidad,ClaveTarea))

create table EventoTareaVoluntario
(ClaveEvento int references Evento,
ClaveTarea int references Tarea,
ClaveVoluntario int references Voluntario,
primary key (ClaveTarea,ClaveVoluntario))