use FuerzaR
insert into Estado values(1, 'CDMX')
insert into Ciudad values(1, 'CDMX',1)
insert into Tipo values (1,'Terremoto')
insert into Sexo values(1,'Hombre')
insert into Sexo values(2,'Mujer')
insert into Sexo values(3,'Otro')
insert into Evento values (1,'Terremoto', CURRENT_TIMESTAMP,null,1,1,1);
insert into Voluntario values(1,'juan@gmail.com','juanito','Juan Gonzalez',22,1,512345678,1)
insert into Organizacion values(1,'ayudamx@gmail.com','ayuditamx','Ayuda Mexico', 513325235, 'Rio Hondo 12',1)
insert into Tarea values (1,'Rescate de gente atrapada en los escombros','Rio Hondo 1',1)
insert into Tarea values (2,'Entrega de comida','Chapultepec 1',1)
insert into TareaVoluntario values (1,1,CURRENT_TIMESTAMP,null)
insert into Administrador values(1,'Jorge Perez','jorge@gmail.com','jorgito')
