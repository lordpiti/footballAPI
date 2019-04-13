using System;
using System.Collections.Generic;
using System.Text;
using Util.Exceptions;

using System.Configuration;
using System.Data.Common;
using System.Collections;
using System.Xml;
using Futbol.Model.Integrante.VO;
using Futbol.Model.Directivo.VO;
using Futbol.Model.Equipo.VO;
using Futbol.Model.HcoIntegrante.VO;

namespace Futbol.Model.FachadaDatos
{
    public class DirectivoCO:MiembroCO
    {
        private DirectivoVO directivo;



        public DirectivoCO(DirectivoVO directivo, List<HcoIntegranteVO> listaHcoIntegrantes,
            IntegranteVO integrante)
        {
            this.directivo = directivo;
            base.Integrante = integrante;
            base.ListaHcoIntegrantes = listaHcoIntegrantes;
        }


        public DirectivoVO Directivo
        {
            get { return directivo; }
            set { directivo = value; }
        }


    }

}
