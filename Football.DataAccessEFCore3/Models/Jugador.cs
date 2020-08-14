using Football.Crosscutting.Enums;
using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class Jugador
    {
        public Jugador()
        {
            CambioCodJugadorEntraNavigation = new HashSet<Cambio>();
            CambioCodJugadorSaleNavigation = new HashSet<Cambio>();
            Gol = new HashSet<Gol>();
            PartidoJugado = new HashSet<PartidoJugado>();
            Tarjeta = new HashSet<Tarjeta>();
            Trata = new HashSet<Trata>();
        }

        public int CodJugador { get; set; }
        public int? CodIntegrante { get; set; }
        public int? CodEquipo { get; set; }
        public int? VersionIntegrante { get; set; }
        public float? Altura { get; set; }
        public string Posicion { get; set; }
        public string Pierna { get; set; }
        public bool Married { get; set; }

        public PositionEnum? Position { get; set; }

        public virtual Equipo CodEquipoNavigation { get; set; }
        public virtual Integrante CodIntegranteNavigation { get; set; }
        public virtual ICollection<Cambio> CambioCodJugadorEntraNavigation { get; set; }
        public virtual ICollection<Cambio> CambioCodJugadorSaleNavigation { get; set; }
        public virtual ICollection<Gol> Gol { get; set; }
        public virtual ICollection<PartidoJugado> PartidoJugado { get; set; }
        public virtual ICollection<Tarjeta> Tarjeta { get; set; }
        public virtual ICollection<Trata> Trata { get; set; }
    }
}
