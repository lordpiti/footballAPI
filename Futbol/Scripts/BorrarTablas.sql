IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[calendario]') AND type in ('U'))
drop table calendario
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[noticia]') AND type in ('U'))
drop table noticia
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[tarjeta]') AND type in ('U'))
drop table tarjeta
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[transpaso]') AND type in ('U'))
drop table transpaso
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[gol]') AND type in ('U'))
drop table gol
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[trata]') AND type in ('U'))
drop table trata
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[medico]') AND type in ('U'))
drop table medico
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[cambio]') AND type in ('U'))
drop table cambio
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[partido_jugado]') AND type in ('U'))
drop table partido_jugado
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[partido]') AND type in ('U'))
drop table partido
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[arbitro]') AND type in ('U'))
drop table arbitro
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[estadio]') AND type in ('U'))
drop table estadio
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[jugador]') AND type in ('U'))
drop table jugador
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[directivo]') AND type in ('U'))
drop table directivo 
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[entrenador]') AND type in ('U'))
drop table entrenador
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[hco_integrante]') AND type in ('U'))
drop table hco_integrante
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[integrante]') AND type in ('U'))
drop table integrante
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[clasificacion]') AND type in ('U'))
drop table clasificacion
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[equiposParticipan]') AND type in ('U'))
drop table equiposParticipan
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[competicion]') AND type in ('U'))
drop table competicion
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[equipo]') AND type in ('U'))
drop table equipo
GO