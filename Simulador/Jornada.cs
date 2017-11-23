using System;
using System.Collections.Generic;
using System.Text;

namespace Simulador
{
    public class Jornada
    {
        private Object local, visitante;


        public Jornada(Object local, Object visitante)
        {
            this.local = local;
            this.visitante = visitante;
        }

        public Object Local
        {
            get { return local; }
            set { local = value; }
        }

        public Object Visitante
        {
            get { return visitante; }
            set { visitante = value; }
        }

        public String toString() 
        {
            return " " + local + " vs " + visitante;
        }
    }
}
