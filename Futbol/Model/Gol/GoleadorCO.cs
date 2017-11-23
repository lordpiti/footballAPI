using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Gol
{
    public class GoleadorCO
    {

        String equipo;
        int cod_Equipo;
        int numeroGoles;
        int cod_Integrante;
        String nombreApellidos;

        public GoleadorCO(String nombreApellidos, String equipo, int numeroGoles,
            int cod_Equipo,int cod_Integrante)
        {
            this.nombreApellidos = nombreApellidos;
            this.equipo = equipo;
            this.numeroGoles = numeroGoles;
            this.cod_Equipo = cod_Equipo;
            this.cod_Integrante = cod_Integrante;
        }


        public String NombreApellidos
        {
            get { return nombreApellidos; }
            set { nombreApellidos = value; }
        }


        public String Equipo
        {
            get { return equipo; }
            set { equipo = value; }
        }
        

        public int NumeroGoles
        {
            get { return numeroGoles; }
            set { numeroGoles = value; }
        }

        public int Cod_Equipo
        {
            get { return cod_Equipo; }
            set { cod_Equipo = value; }
        }

        public int Cod_Integrante
        {
            get { return cod_Integrante; }
            set { cod_Integrante = value; }
        }

    }
}
