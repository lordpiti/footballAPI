using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Futbol.Model.HcoIntegrante.VO;
using Futbol.Model.Jugador.VO;
using Futbol.Model.Integrante.VO;

namespace Futbol.Model.FachadaAdmin.COs
{
    public class InfoJugadorEditar
    {
        private IntegranteVO integranteVO;
        private HcoIntegranteVO hcoIntegranteVO;
        private JugadorVO jugadorVO;


        public InfoJugadorEditar(IntegranteVO integranteVO,HcoIntegranteVO hcoIntegranteVO,
            JugadorVO jugadorVO)
        {
            this.integranteVO = integranteVO;
            this.hcoIntegranteVO = hcoIntegranteVO;
            this.jugadorVO = jugadorVO;
        }



        public IntegranteVO Integrante
        {
            get { return integranteVO; }
            set { integranteVO = value; }
        }

        public HcoIntegranteVO HcoIntegrante
        {
            get { return hcoIntegranteVO; }
            set { hcoIntegranteVO = value; }
        }


        public JugadorVO Jugador
        {
            get { return jugadorVO; }
            set { jugadorVO = value; }
        }
    }
}

