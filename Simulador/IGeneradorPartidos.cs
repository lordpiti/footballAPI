using System.Collections;
using System.Collections.Generic;
using Futbol.Model.Calendario.VO;
using Futbol.Model.FachadaPartidos;
using Futbol.Model.Jugador.VO;
using Futbol.Model.Partido.VO;
using Futbol.Model.PartidoJugado.VO;

namespace Simulador
{
    public interface IGeneradorPartidos
    {
        List<CalendarioVO> generaListaCalendarioVOsLiga(List<List<Jornada>> calendario);
        List<JugadorVO> generar11Titular(int codEquipo);
        void generarCopaCompleta(int numeroEquipos);
        void generarLigaCompleta(int numeroEquipos);
        PartidoTotalCO generarPartidoCompleto(int codCompeticion, string jornada, int codLocal, int codVisitante, bool saveChangesInBD = true);
        PartidoJugadoVO generarPartidoJugadoSimple(int codJugador, string titular);
        PartidoVO generarPartidoSimple(int codCompeticion, string jornada, int codLocal, int codVisitante, int codEstadio);
    }
}