using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Futbol.Model.Integrante.VO;
using Futbol.Model.HcoIntegrante.VO;

namespace Futbol.Model.FachadaDatos
{
    public class MiembroCO
    {
        public List<HcoIntegranteVO> ListaHcoIntegrantes { get; set; }
        public IntegranteVO Integrante { get; set; }

        public MiembroCO(IntegranteVO integrante, List<HcoIntegranteVO> listaHcoIntegrantes)
        {
            this.Integrante = integrante;
            this.ListaHcoIntegrantes = listaHcoIntegrantes;
        }

        public MiembroCO()
        {
        }


        public virtual int cod_Integrante()
        {
            return 1;
        }

    }
}
