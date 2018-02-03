using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Futbol.Model.Integrante.VO;
using Futbol.Model.HcoIntegrante.VO;

namespace Futbol.Model.FachadaAdmin.COs
{
    public class MiembroCO
    {
        protected List<HcoIntegranteVO> listaHcoIntegrantes;
        protected IntegranteVO integrante;

        public MiembroCO(IntegranteVO integrante, List<HcoIntegranteVO> listaHcoIntegrantes)
        {
            this.integrante = integrante;
            this.listaHcoIntegrantes = listaHcoIntegrantes;
        }

        public MiembroCO()
        {
        }

        public IntegranteVO Integrante
        {
            get { return integrante; }
            set { integrante = value; }
        }


        public List<HcoIntegranteVO> ListaHcoIntegrantes
        {
            get { return listaHcoIntegrantes; }
            set { listaHcoIntegrantes = value; }
        }

        public virtual int cod_Integrante()
        {
            return 1;
        }

    }
}
