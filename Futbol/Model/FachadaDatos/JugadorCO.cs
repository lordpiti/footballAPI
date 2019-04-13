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


        public JugadorCO(JugadorVO jugador, List<HcoIntegranteVO> listaHcoIntegrantes,
            IntegranteVO integrante)
        {
            
            base.Integrante = integrante;
            base.ListaHcoIntegrantes = listaHcoIntegrantes;
            this.Jugador = jugador;
        }


        public JugadorVO Jugador { get; set; }

        public override int cod_Integrante()
        {
            return this.Jugador.Cod_Integrante;
        }


    }
}
