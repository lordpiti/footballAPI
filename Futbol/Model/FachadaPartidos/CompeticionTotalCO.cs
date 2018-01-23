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
        private List<CalendarioVO> calendario;
        private List<int> listaEquipos;

        public CompeticionTotalCO(CompeticionVO competicionVO, List<CalendarioVO> calendario,
            List<int> listaEquipos)
        {
            this.competicion = competicionVO;
            this.calendario = calendario;
            this.listaEquipos = listaEquipos;
        }


        public List<CalendarioVO> Calendario
        {
            get { return calendario; }
            set { calendario = value; }
        }

        public List<int> ListaEquipos
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
