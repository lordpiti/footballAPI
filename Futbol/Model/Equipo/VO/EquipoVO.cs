using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Equipo.VO
{
    public class EquipoVO
    {
        private int cd_Equipo;
        private String nombre;
        private String ciudad;
        private int cd_Estadio;
        private String fotoEscudo;
        private String fotoPlantilla;


        public EquipoVO(int cd_Equipo, String nombre, String ciudad, int cd_Estadio,
            String fotoEscudo,String fotoPlantilla)
        {
            this.cd_Equipo = cd_Equipo;
            this.ciudad = ciudad;
            this.nombre = nombre;
            this.cd_Estadio = cd_Estadio;
            this.fotoEscudo = fotoEscudo;
            this.fotoPlantilla = fotoPlantilla;
        }


        public EquipoVO(String nombre, String ciudad, int cd_Estadio, String fotoEscudo,
            String fotoPlantilla)
        {
            this.ciudad = ciudad;
            this.nombre = nombre;
            this.cd_Estadio = cd_Estadio;
            this.fotoEscudo = fotoEscudo;
            this.fotoPlantilla = fotoPlantilla;
        }


        public int Cd_Estadio
        {
            get { return cd_Estadio; }
            set { cd_Estadio = value; }
        }

        public String Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Cd_Equipo
        {
            get { return cd_Equipo; }
            set { cd_Equipo = value; }
        }

        public String FotoEscudo
        {
            get { return fotoEscudo; }
            set { fotoEscudo = value; }
        }

        public String FotoPlantilla
        {
            get { return fotoPlantilla; }
            set { fotoPlantilla = value; }
        }


        public String toString()
        {
            return (cd_Equipo.ToString() + " " + nombre + " " + ciudad + " ");
        }
    }
}
