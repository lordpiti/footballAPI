USE [futbol]
GO

CREATE TABLE Integrante(Cod_Int int NOT NULL,
Nombre varchar(20) NOT NULL,
Apellidos varchar(30) NOT NULL,
Fecha_Nac datetime, 
Foto varchar(50),
PRIMARY KEY (Cod_Int));;




CREATE TABLE Equipo(Cod_Equipo int IDENTITY(1,1) NOT NULL, 
Nombre varchar(20) NOT NULL,
Localidad varchar(20),
Cod_Estadio int,
PRIMARY KEY (Cod_Equipo));;




CREATE TABLE Hco_Integrante(Cod_Integrante int NOT NULL REFERENCES Integrante(Cod_Int),
Cod_Equipo int NOT NULL REFERENCES Equipo(Cod_Equipo),
Version_Integrante int NOT NULL,
Fecha_Inicio datetime NOT NULL,
Fecha_Fin datetime,
Fecha_Fin_Contrato datetime,
Sueldo real,
Dorsal int,
PRIMARY KEY(Cod_Integrante,Cod_Equipo,Version_Integrante))




CREATE TABLE Transpaso(Cod_Transpaso int IDENTITY(1,1) NOT NULL,
Cod_Integrante int NOT NULL,
Cod_Equipo_Origen int NOT NULL REFERENCES Equipo(Cod_Equipo),
Cod_Equipo_Destino int NOT NULL REFERENCES Equipo(Cod_Equipo),
Coste real NOT NULL,
Fecha datetime NOT NULL,
PRIMARY KEY (Cod_Transpaso) )


CREATE TABLE Entrenador(Cod_Entrenador int IDENTITY(1,1) NOT NULL,
Cod_Integrante int NOT NULL,
Cod_Equipo int NOT NULL REFERENCES Equipo(Cod_Equipo),
Version_Integrante int NOT NULL,
Cargo varchar(100) NOT NULL,
Fecha_Profesional datetime,
PRIMARY KEY(Cod_Integrante,Cod_Equipo,Version_Integrante) )




CREATE TABLE Directivo(Cod_Directivo int IDENTITY(1,1) NOT NULL,
Cod_Integrante int NOT NULL,
Cod_Equipo int NOT NULL REFERENCES Equipo(Cod_Equipo),
Version_Integrante int NOT NULL,
Cargo varchar(20) NOT NULL,
Profesion varchar(20),
PRIMARY KEY(Cod_Integrante,Cod_Equipo,Version_Integrante) )




CREATE TABLE Medico(Cod_Medico int IDENTITY(1,1) NOT NULL,
Cod_Integrante int NOT NULL,
Cod_Equipo int NOT NULL REFERENCES Equipo(Cod_Equipo),
Version_Integrante int NOT NULL,
Especialidad varchar(20) NOT NULL,
Fecha_Profesional datetime,
PRIMARY KEY(Cod_Medico) )




CREATE TABLE Jugador(Cod_Jugador int IDENTITY(1,1) NOT NULL,
Cod_Integrante int ,
Cod_Equipo int REFERENCES Equipo(Cod_Equipo),
Version_Integrante int ,
Altura real,
Posicion varchar(30) NOT NULL,
Pierna varchar(10),
PRIMARY KEY(Cod_Jugador) )


CREATE TABLE Trata(Cod_Tratamiento int IDENTITY(1,1) NOT NULL,
Cod_Medico int NOT NULL REFERENCES Medico(Cod_Medico),
Cod_Jugador int NOT NULL REFERENCES Jugador(Cod_Jugador),
Fecha_Inicio datetime NOT NULL,
Fecha_Fin datetime,
Lesion varchar(20),
PRIMARY KEY (Cod_Tratamiento) )




CREATE TABLE Estadio(Cod_Estadio int IDENTITY(1,1) NOT NULL,
Nombre varchar(30),
Capacidad int NOT NULL,
Direccion varchar(30),
Tipo varchar(20),
Foto varchar(50),
PRIMARY KEY(Cod_Estadio) )



CREATE TABLE Competicion(Cod_Competicion int IDENTITY(1,1) NOT NULL,
nombre varchar(20) NOT NULL,
temporada varchar(10) NOT NULL,
Fecha_Inicio datetime,
Fecha_Fin datetime,
Campeon varchar(20),
foto varchar(100),
tipo varchar(20),
PRIMARY KEY (Cod_Competicion) )


CREATE TABLE Arbitro(Cod_Arbitro int IDENTITY(1,1) NOT NULL,
Nombre varchar(20) NOT NULL,
Apellidos varchar(30) NOT NULL,
Colegio varchar(20),
Anos_Activo int,
Foto varchar(50),
PRIMARY KEY(Cod_Arbitro)  )


CREATE TABLE Partido(Cod_Partido int IDENTITY(1,1) NOT NULL,
Cod_Competicion int NOT NULL REFERENCES Competicion(Cod_Competicion),
Jornada varchar(10),
Cod_Local int NOT NULL REFERENCES Equipo(Cod_Equipo),
Cod_Visitante int NOT NULL REFERENCES Equipo(Cod_Equipo),
Fecha datetime,
Clima varchar(10),
Goles_Local int NOT NULL,
Goles_Visitante int NOT NULL,
Posesion_Local real NOT NULL,
Posesion_Visitante real NOT NULL,
Corners_Local int NOT NULL,
Corners_Visitante int NOT NULL,
Fueras_Juego_Local int NOT NULL,
Fueras_Juego_Visitante int NOT NULL,
Asistencia int,
Cod_Arbitro int NOT NULL REFERENCES Arbitro(Cod_Arbitro),
Cod_Estadio int NOT NULL REFERENCES Estadio(Cod_Estadio),
PRIMARY KEY(Cod_Partido)  ) 


CREATE TABLE Partido_Jugado(Cod_Jugador int NOT NULL REFERENCES Jugador(Cod_Jugador),
Cod_Partido int NOT NULL REFERENCES Partido(Cod_Partido),
Titular varchar(20) NOT NULL,
Minutos int NOT NULL,
Asistencias int NOT NULL,
Asistencias_Gol int NOT NULL,
remates int NOT NULL,
remates_Porteria int NOT NULL,
remates_Poste int NOT NULL,
fueras_Juego int NOT NULL,
tarjetas_Amarillas_Provocadas int NOT NULL,
tarjetas_Rojas_Provocadas int NOT NULL,
Faltas_Recibidas int NOT NULL,
Faltas_Cometidas int NOT NULL,
corners int NOT NULL,
balones_recuperados int NOT NULL,
balones_perdidos int not null,
penaltis_recibidos int not null,
penaltis_cometidos int not null,
PRIMARY KEY (Cod_Jugador, Cod_Partido)   )



CREATE TABLE Gol(Cod_Gol int IDENTITY(1,1) NOT NULL, 
Cod_Partido int NOT NULL REFERENCES Partido(Cod_Partido),
Cod_Jugador int NOT NULL REFERENCES Jugador(Cod_Jugador),
Minuto int NOT NULL,
Tipo varchar(20) NOT NULL,
PRIMARY KEY (Cod_Gol)  )



CREATE TABLE Tarjeta(Cod_Tarjeta int IDENTITY(1,1) NOT NULL, 
Cod_Partido int NOT NULL REFERENCES Partido(Cod_Partido),
Cod_Jugador int NOT NULL REFERENCES Jugador(Cod_Jugador),
Minuto int NOT NULL,
Tipo varchar(20) NOT NULL,
Motivo varchar(50) NOT NULL,
PRIMARY KEY (Cod_Tarjeta)  )



CREATE TABLE Cambio(Cod_Cambio int IDENTITY(1,1) NOT NULL,
Cod_Partido int NOT NULL REFERENCES Partido(Cod_Partido),
Cod_Jugador_Entra int NOT NULL REFERENCES Jugador(Cod_Jugador),
Cod_Jugador_Sale int NOT NULL REFERENCES Jugador(Cod_Jugador),
Minuto int NOT NULL,
PRIMARY KEY (Cod_Cambio)   )



CREATE TABLE Clasificacion(Cod_Competicion int NOT NULL REFERENCES Competicion(Cod_Competicion),
jornada int NOT NULL, Cod_Equipo int NOT NULL REFERENCES Equipo(Cod_Equipo), 
posicion int NOT NULL,ganados int,perdidos int,empatados int,goles_favor int ,goles_contra int, puntos int,
PRIMARY KEY(Cod_Competicion,jornada,Cod_Equipo,posicion))


CREATE TABLE EquiposParticipan(Cod_Competicion int NOT NULL,
Cod_Equipo int NOT NULL REFERENCES Equipo(cod_equipo),
PRIMARY KEY(Cod_Competicion,Cod_Equipo))


CREATE TABLE Noticia(Cod_Noticia int NOT NULL, Tipo varchar(10) NOT NULL, 
Cod_Competicion int REFERENCES Competicion(Cod_Competicion),Titulo text, Resumen text, Cuerpo text,
cod_Partido int REFERENCES Partido(Cod_Partido),foto varchar(30),fecha datetime not null, autor varchar(20),
PRIMARY KEY(cod_noticia))


CREATE TABLE Calendario(cod_calendario int IDENTITY(1,1) NOT NULL,
cod_Competicion int NOT NULL,jornada varchar(20) NOT NULL,
cod_Local int NOT NULL,cod_Visitante int NOT NULL, fecha datetime ,
 PRIMARY KEY(cod_calendario))
 
GO