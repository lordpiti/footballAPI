using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Util
{
    public class CompeticionJornadaCO
    {
        private String jornada;
        private int cod_Competicion;

        public CompeticionJornadaCO(int cod_Competicion,String jornada)
        {
            this.cod_Competicion = cod_Competicion;
            this.jornada = jornada;
        }

        public Int32 Cod_Competicion
        {
            get { return cod_Competicion; }
            set { cod_Competicion = value; }
        }

        public String Jornada
        {
            get { return jornada; }
            set { jornada = value; }
        }

    }
}
