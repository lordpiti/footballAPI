--Consulta para obtener las estadisticas de un jugador en todos los partidos de una competicion



SELECT        co.nombre, co.temporada, pa.Jornada, eq1.Nombre AS eq_local, eq2.Nombre AS eq_visitante, pj.Titular, pj.Minutos, pj.Faltas_Cometidas, 
                         COUNT(gol.Cod_Gol) AS Goles, COUNT(tar.Cod_Tarjeta) AS Tarjetas
FROM            Partido_Jugado AS pj INNER JOIN
                         Partido AS pa ON pj.Cod_Partido = pa.Cod_Partido AND pj.Cod_Jugador = 12 INNER JOIN
                         Competicion AS co ON pa.Cod_Competicion = 4 AND co.Cod_Competicion = pa.Cod_Competicion LEFT OUTER JOIN
                         Gol AS gol ON gol.Cod_Jugador = pj.Cod_Jugador AND gol.Cod_Partido = pj.Cod_Partido INNER JOIN
                         Equipo AS eq1 ON pa.Cod_Local = eq1.Cod_Equipo INNER JOIN
                         Equipo AS eq2 ON pa.Cod_Visitante = eq2.Cod_Equipo LEFT OUTER JOIN
                         Tarjeta AS tar ON tar.Cod_Jugador = pj.Cod_Jugador AND tar.Cod_Partido = pj.Cod_Partido
GROUP BY pj.Cod_Partido, pj.Cod_Jugador, co.nombre, co.temporada, pa.Jornada, eq1.Nombre, eq2.Nombre, pj.Titular, pj.Minutos, pj.Faltas_Cometidas

  
  
  
  
--Obtiene todos los partidos jugados por un jugador en todas las competiciones de una temporada

SELECT        co.nombre, co.temporada, pa.Jornada, eq1.Nombre AS eq_local, eq2.Nombre AS eq_visitante, pj.Titular, pj.Minutos, pj.Faltas_Cometidas, 
                         COUNT(gol.Cod_Gol) AS Goles, COUNT(tar.Cod_Tarjeta) AS Tarjetas
FROM            Partido_Jugado AS pj INNER JOIN
                         Partido AS pa ON pj.Cod_Partido = pa.Cod_Partido AND pj.Cod_Jugador = 23 INNER JOIN
                         Competicion AS co ON co.Temporada='99-00' AND co.Cod_Competicion = pa.Cod_Competicion LEFT OUTER JOIN
                         Gol AS gol ON gol.Cod_Jugador = pj.Cod_Jugador AND gol.Cod_Partido = pj.Cod_Partido INNER JOIN
                         Equipo AS eq1 ON pa.Cod_Local = eq1.Cod_Equipo INNER JOIN
                         Equipo AS eq2 ON pa.Cod_Visitante = eq2.Cod_Equipo LEFT OUTER JOIN
                         Tarjeta AS tar ON tar.Cod_Jugador = pj.Cod_Jugador AND tar.Cod_Partido = pj.Cod_Partido
GROUP BY pj.Cod_Partido, pj.Cod_Jugador, co.nombre, co.temporada, pa.Jornada, eq1.Nombre, eq2.Nombre, pj.Titular, pj.Minutos, pj.Faltas_Cometidas
  
  
                            
--Obtiene los nombres y apellidos de los jugadores titulares (o suplentes)
--de un equipo en un partido                            
                            
                            
SELECT     ju.Cod_Jugador, pj.Cod_Partido, int.Nombre, int.Apellidos, pj.Minutos, pj.Faltas_Cometidas
FROM         Integrante AS int INNER JOIN
                      Hco_Integrante AS hi ON int.Cod_Int = hi.Cod_Integrante INNER JOIN
                      Jugador AS ju ON hi.Cod_Integrante = ju.Cod_Integrante AND hi.Cod_Equipo = ju.Cod_Equipo AND 
                      hi.Version_Integrante = ju.Version_Integrante INNER JOIN
                      Partido_Jugado AS pj ON pj.Cod_Jugador = ju.Cod_Jugador
WHERE     (ju.Cod_Equipo = 1) AND (pj.Cod_Partido = 32) AND (pj.Titular = 'suplente')         


--Mejora anterior y correccion provisional

SELECT        ju.Cod_Jugador, int.Nombre, int.Apellidos, pj.Cod_Partido, pj.Minutos, pj.Faltas_Cometidas
FROM            Partido_Jugado AS pj INNER JOIN
                         Jugador AS ju ON pj.Cod_Jugador = ju.Cod_Jugador AND pj.Cod_Partido = 1 INNER JOIN
                         Hco_Integrante AS hi ON hi.Cod_Integrante = ju.Cod_Integrante AND hi.Cod_Equipo = ju.Cod_Equipo AND ju.Cod_Equipo = 1 INNER JOIN
                         Integrante AS int ON hi.Cod_Integrante = int.Cod_Int
                 
                            
                        
                        
       --clasificaicon de una jornada                 
                        
SELECT        c.Cod_Competicion, c.jornada, c.posicion, e.Nombre, c.goles_favor, c.goles_contra, c.puntos
FROM            Clasificacion AS c INNER JOIN
                         Equipo AS e ON (c.cod_competicion=4 and c.jornada=2 and e.Cod_Equipo = c.Cod_Equipo)
ORDER BY c.posicion    


--Obtiene todas las temporadas en las que un jugador ha jugado partidos

SELECT distinct comp.temporada from Partido_Jugado paju INNER JOIN 
partido pa on paju.cod_jugador=1 and paju.cod_partido=pa.cod_partido INNER JOIN
competicion comp on pa.cod_competicion=comp.cod_competicion



--Obtiene el calendario de una competicion completa
SELECT cal.jornada,cal.fecha,e1.nombre, e2.nombre,co.nombre FROM
calendario cal INNER JOIN equipo e1 on (cal.cod_Local=e1.cod_equipo and
cal.cod_competicion=1) INNER JOIN equipo e2 on (cal.cod_Visitante=e2.cod_equipo)
INNER JOIN competicion co on cal.cod_competicion=co.cod_competicion


--Obtiene el calendario de una jornada de una competicion
SELECT cal.jornada,cal.fecha,e1.nombre, e2.nombre,co.nombre FROM
calendario cal INNER JOIN equipo e1 on (cal.cod_Local=e1.cod_equipo and
cal.cod_competicion=1 and cal.jornada='1') INNER JOIN equipo e2 on 
(cal.cod_Visitante=e2.cod_equipo)INNER JOIN competicion co on 
cal.cod_competicion=co.cod_competicion



--Obtiene los goles de un equipo en un partido
SELECT     gol.cod_gol,ju.Cod_Jugador, gol.Cod_Partido, int.Nombre, int.Apellidos,gol.minuto,
gol.tipo
FROM         Integrante AS int INNER JOIN
                      Hco_Integrante AS hi ON int.Cod_Int = hi.Cod_Integrante INNER JOIN
                      Jugador AS ju ON hi.Cod_Integrante = ju.Cod_Integrante AND hi.Cod_Equipo = ju.Cod_Equipo AND 
                      ju.cod_equipo=8 and hi.Version_Integrante = ju.Version_Integrante INNER JOIN
                      gol ON gol.Cod_Jugador = ju.Cod_Jugador and gol.cod_partido=1
                      
                      
                      
                      
--Obtiene los cambios de un equipo en un partido
select ca.minuto,h.dorsal,ju.cod_equipo,i.nombre,i.apellidos,h2.dorsal,
ju2.cod_equipo,i2.nombre,i2.apellidos from cambio ca INNER JOIN 
jugador ju on ca.cod_jugador_entra=ju.cod_jugador and ca.cod_partido=3 and 
ju.cod_equipo=3 INNER JOIN
hco_integrante h on ju.cod_integrante=h.cod_integrante and ju.cod_equipo=h.cod_equipo
and ju.version_integrante=h.version_integrante INNER JOIN 
integrante i on h.cod_integrante=i.cod_int INNER JOIN
jugador ju2 on ca.cod_jugador_sale=ju2.cod_jugador INNER JOIN
hco_integrante h2 on ju2.cod_integrante=h2.cod_integrante and ju2.cod_equipo=h2.cod_equipo
and ju2.version_integrante=h2.version_integrante INNER JOIN 
integrante i2 on h2.cod_integrante=i2.cod_int order by ca.minuto




--Obtiene las tarjetas de un equipo en un partido
SELECT j.cod_jugador,h.dorsal,i.nombre,i.apellidos,t.minuto,
t.tipo,t.motivo FROM tarjeta t JOIN
jugador j on t.cod_partido=1 and j.cod_jugador=t.cod_jugador and j.cod_equipo=1 JOIN
hco_integrante h on j.cod_integrante=h.cod_integrante and 
j.cod_equipo=h.cod_equipo and j.version_integrante=h.version_integrante JOIN
integrante i on i.cod_int=h.cod_integrante order by t.minuto



--obtiene estadisticas de un jugador en una competicion concreta
select ju.cod_jugador,sum(minutos),
sum(asistencias),sum(asistencias_gol),sum(remates),sum(remates_porteria),
sum(remates_poste),sum(fueras_juego),sum(tarjetas_amarillas_provocadas),
sum(tarjetas_rojas_provocadas),sum(faltas_recibidas),sum(faltas_cometidas),
sum(corners),sum(balones_recuperados),sum(balones_perdidos),
sum(penaltis_recibidos),sum(penaltis_cometidos)
from partido_jugado pj JOIN
jugador ju on ju.cod_jugador=1 and pj.cod_jugador=ju.cod_jugador JOIN
partido p on pj.cod_partido=p.cod_partido and p.cod_competicion=1 
group by ju.cod_jugador




--estadisticas de un jugador en una temporada concreta
select ju.cod_jugador,sum(minutos),
sum(asistencias),sum(asistencias_gol),sum(remates),sum(remates_porteria),
sum(remates_poste),sum(fueras_juego),sum(tarjetas_amarillas_provocadas),
sum(tarjetas_rojas_provocadas),sum(faltas_recibidas),sum(faltas_cometidas),
sum(corners),sum(balones_recuperados),sum(balones_perdidos),
sum(penaltis_recibidos),sum(penaltis_cometidos)
from partido_jugado pj JOIN
jugador ju on ju.cod_jugador=1 and pj.cod_jugador=ju.cod_jugador JOIN
partido p on pj.cod_partido=p.cod_partido JOIN
competicion c on c.temporada='00-01' and c.cod_competicion=p.cod_competicion
group by ju.cod_jugador



--PLANTILLA ACTUAL de un equipo dado
SELECT ju.cod_jugador,i.nombre,i.apellidos,i.fecha_nac,ju.posicion,i.foto  
from jugador ju JOIN (SELECT cod_integrante,max(version_integrante)as maximo 
from hco_integrante group by cod_integrante) h  on (ju.cod_integrante=h.cod_integrante
and ju.version_integrante=h.maximo and ju.cod_equipo=1) JOIN integrante i
on h.cod_integrante=i.cod_int