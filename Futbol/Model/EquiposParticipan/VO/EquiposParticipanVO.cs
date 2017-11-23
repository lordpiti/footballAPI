using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.EquiposParticipan.VO
{
    public class EquiposParticipanVO
    {
        private int cod_Competicion;
        private int cod_Equipo;



        public EquiposParticipanVO(int cod_Competicion, int cod_Equipo)
        {
            this.cod_Competicion=cod_Competicion;
            this.cod_Equipo=cod_Equipo;

        }



        public int Cod_Competicion
        {
            get { return cod_Competicion; }
            set { cod_Competicion = value; }
        }

        public int Cod_Equipo
        {
            get { return cod_Equipo; }
            set { cod_Equipo = value; }
        }

        

        public String toString()
        {
            return ("Competicion: "+cod_Competicion.ToString()+" | Cod equipo: "+cod_Equipo.ToString());
        }
    }
}
