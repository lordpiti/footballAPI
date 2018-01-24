using System;
using System.Collections.Generic;
using System.Text;
using Util.Exceptions;

using System.Configuration;
using System.Data.Common;
using System.Collections;
using System.Xml;
using Futbol.Model.Integrante.VO;
using Futbol.Model.Jugador.VO;
using Futbol.Model.Equipo.VO;
using Futbol.Model.HcoIntegrante.VO;

namespace Futbol.Model.FachadaDatos
{
    public class JugadorCO : MiembroCO
    {
        private JugadorVO jugador;


        public JugadorCO(JugadorVO jugador, ArrayList listaHcoIntegrantes,
            IntegranteVO integrante)
        {
            
            base.Integrante = integrante;
            base.ListaHcoIntegrantes = listaHcoIntegrantes;
            this.jugador = jugador;
        }


        public JugadorVO Jugador
        {
            get { return jugador; }
            set { jugador = value; }
        }

        public override int cod_Integrante()
        {
            return this.jugador.Cod_Integrante;
        }


    }
}
