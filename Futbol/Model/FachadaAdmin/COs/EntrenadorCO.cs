using System;
using System.Collections.Generic;
using System.Text;
using Util.Exceptions;

using System.Configuration;
using System.Data.Common;
using System.Collections;
using System.Xml;
using Futbol.Model.Integrante.VO;
using Futbol.Model.Entrenador.VO;
using Futbol.Model.Equipo.VO;
using Futbol.Model.HcoIntegrante.VO;

namespace Futbol.Model.FachadaAdmin.COs
{
    public class EntrenadorCO:MiembroCO
    {
        private EntrenadorVO entrenador;


        public EntrenadorCO(EntrenadorVO entrenador, List<HcoIntegranteVO> listaHcoIntegrantes,
            IntegranteVO integrante)
        {
            this.entrenador = entrenador;
            base.Integrante = integrante;
            base.ListaHcoIntegrantes = listaHcoIntegrantes;
        }


        public EntrenadorVO Entrenador
        {
            get { return entrenador; }
            set { entrenador = value; }
        }


    }

}
