using System;
using System.Collections.Generic;
using System.Text;
using Futbol.Model.Arbitro.VO;
using System.Collections;


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
        private ArrayList listaPartidos;

        public ArrayList ListaPartidos
        {
            get { return listaPartidos; }
            set { listaPartidos = value; }
        }

        public ArbitroCO(ArbitroVO arbitroVO, ArrayList listaPartidos)
        {
            this.arbitroVO = arbitroVO;
            this.listaPartidos = listaPartidos;
        }

    }
}
