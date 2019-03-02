using Futbol.ActionProcessor;
using Futbol.Model.Directivo;
using Futbol.Model.Entrenador;
using Futbol.Model.Estadio.VO;
using Futbol.Model.FachadaAdmin.COs;
using Futbol.Model.FachadaDatos.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Util.Exceptions;
using Westwind.Utilities;

using System.Configuration;
using System.Data.Common;
using System.Collections;
using System.Xml;
using Futbol.Model.Estadio.VO;
using Futbol.Model.Arbitro.VO;
using Futbol.Model.Integrante.VO;
using Futbol.Model.Entrenador.VO;
using Futbol.Model.Directivo.VO;
using Futbol.Model.HcoIntegrante.VO;
using Futbol.Model.Jugador.VO;
using Futbol.Model.Competicion.VO;
using Futbol.Model.Equipo.VO;
using Futbol.Model.Partido.VO;
using Futbol.Model.PartidoJugado.VO;
using Futbol.ActionProcessor;
using Futbol.Model.FachadaDatos.Actions;
using Futbol.Model.FachadaAdmin.COs;
using Futbol.Model.Directivo;
using Futbol.Model.Entrenador;

namespace Futbol.Model.FachadaDatos
{
    public class FachadaDatos
    {
        private static String providerName = "system.data.sqlclient";
     /*   private static String connectionString = "Data Source=localhost\\SQLExpress;" +
            "Initial Catalog=criticas;" +
            "User ID=user;Password=password";*/
        private DbProviderFactory dbFactory;


        public FachadaDatos()
        {
            dbFactory = DataUtils.GetDbProviderFactory(providerName);
        }


        public ArrayList verEquiposCompeticion(int cod_Competicion)
         {
             try
             {
                 VerEquiposCompeticionAction action = new VerEquiposCompeticionAction(cod_Competicion);

                 return (ArrayList)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }


         public List<EquipoVO> verEquipos()
         {
             try
             {
                 VerTodosEquiposAction action = new VerTodosEquiposAction();

                 return (List<EquipoVO>)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }


        public ArrayList verListaJugadoresEquipo(int cod_Equipo)
         {
             try
             {
                 VerJugadoresEquipoAction action = new VerJugadoresEquipoAction(cod_Equipo);

                 return (ArrayList)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }


        public ArrayList verPlantillaEquipo(int cod_Equipo)
         {
             try
             {
                 VerPlantillaEquipoAction action = new VerPlantillaEquipoAction(cod_Equipo);

                 return (ArrayList)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }

        public PerfilCompletoJugador verPerfilCompletoJugador(int cod_Jugador)
         {
             try
             {
                 VerPerfilJugadorAction action = new VerPerfilJugadorAction(cod_Jugador);

                 return (PerfilCompletoJugador)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }

        public List<EntrenadorPlantillaCO> verEntrenadoresEquipo(int cod_Equipo)
         {
             try
             {
                 var action = new VerEntrenadoresEquipoAction(cod_Equipo);

                 return (List<EntrenadorPlantillaCO>)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }

        public List<DirectivoPlantillaCO> verDirectivaEquipo(int cod_Equipo)
         {
             try
             {
                 var action = new VerJuntaDirectivaAction(cod_Equipo);

                 return (List<DirectivoPlantillaCO>)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }


         public EstadioVO verEstadio(int cod_Estadio)
         {
             try
             {
                 VerEstadioAction action = new VerEstadioAction(cod_Estadio);

                 return (EstadioVO)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }


         public EquipoTotalCO verEquipoTotal(int cod_Equipo)
         {
             try
             {
                 VerEquipoTotalAction action = new VerEquipoTotalAction(cod_Equipo);

                 return (EquipoTotalCO)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }

         public ArbitroCO verArbitro(int cod_Arbitro)
         {
             try
             {
                 VerPerfilArbitroAction action = new VerPerfilArbitroAction(cod_Arbitro);

                 return (ArbitroCO)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }

  }
}