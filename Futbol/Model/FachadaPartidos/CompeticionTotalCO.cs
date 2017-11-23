using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Futbol.Model.Competicion.VO;
using Futbol.Model.Calendario.VO;

namespace Futbol.Model.FachadaPartidos
{
    public class CompeticionTotalCO
    {
        private CompeticionVO competicion;
        private ArrayList calendario;
        private ArrayList listaEquipos;

        public CompeticionTotalCO(CompeticionVO competicionVO, ArrayList calendario,
            ArrayList listaEquipos)
        {
            this.competicion = competicionVO;
            this.calendario = calendario;
            this.listaEquipos = listaEquipos;
        }


        public ArrayList Calendario
        {
            get { return calendario; }
            set { calendario = value; }
        }

        public ArrayList ListaEquipos
        {
            get { return listaEquipos; }
            set { listaEquipos = value; }
        }


        public CompeticionVO Competicion
        {
            get { return competicion; }
            set { competicion = value; }
        }

    }
}
