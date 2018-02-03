using System;
using System.Collections.Generic;
using System.Text;
using Futbol.Model.Arbitro.VO;
using System.Collections;
using Futbol.Model.Partido;

namespace Futbol.Model.FachadaDatos
{
    public class ArbitroCO
    {
        private ArbitroVO arbitroVO;

        public ArbitroVO ArbitroVO
        {
            get { return arbitroVO; }
            set { arbitroVO = value; }
        }
        private List<PartidoCompeticionJornadaCO> listaPartidos;

        public List<PartidoCompeticionJornadaCO> ListaPartidos
        {
            get { return listaPartidos; }
            set { listaPartidos = value; }
        }

        public ArbitroCO(ArbitroVO arbitroVO, List<PartidoCompeticionJornadaCO> listaPartidos)
        {
            this.arbitroVO = arbitroVO;
            this.listaPartidos = listaPartidos;
        }

    }
}
