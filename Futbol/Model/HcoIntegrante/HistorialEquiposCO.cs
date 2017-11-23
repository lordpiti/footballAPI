using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.HcoIntegrante
{
    class HistorialEquiposCO
    {
        private String nombre;
        private DateTime fecha_Comienzo;
        private DateTime fecha_Final;


        public HistorialEquiposCO(String nombre, DateTime fecha_Comienzo, DateTime fecha_Final)
        {
            this.nombre = nombre;
            this.fecha_Comienzo = fecha_Comienzo;
            this.fecha_Final = fecha_Final;
        }


        public DateTime Fecha_Comienzo
        {
            get { return fecha_Comienzo; }
            set { fecha_Comienzo = value; }
        }


        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public DateTime Fecha_Final
        {
            get { return fecha_Final; }
            set { fecha_Final = value; }
        }

    }
}
