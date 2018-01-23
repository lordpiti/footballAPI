using System;
using System.Collections.Generic;
using System.Text;
using Util.Exceptions;

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
using Futbol.Model.FachadaAdmin.Actions;
using Futbol.Model.FachadaAdmin.COs;



namespace Futbol.Model.FachadaAdmin
{
     public class FachadaAdmin
    {
        private static String providerName = "System.Data.SqlClient";

        private DbProviderFactory dbFactory;


        public FachadaAdmin()
        {
            dbFactory = DbProviderFactories.GetFactory(providerName);
        }

        
        public JugadorCO pruebaCrearJugadorTotal(JugadorCO jugadorCO)
        {      
             try
             {
                 CrearJugadorAction action = new CrearJugadorAction(jugadorCO);

                 return (JugadorCO)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }

        public EntrenadorCO crearEntrenadorTotal(EntrenadorCO entrenadorCO)
         {
             try
             {
                 CrearEntrenadorAction action = new CrearEntrenadorAction(entrenadorCO);

                 return (EntrenadorCO)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }

        public DirectivoCO crearDirectivoTotal(DirectivoCO directivoCO)
         {
             try
             {
                 CrearDirectivoAction action = new CrearDirectivoAction(directivoCO);

                 return (DirectivoCO)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }


         public MiembroCO crearMiembroTotal(MiembroCO miembroCO)
         {
             try
             {
                 TransactionalPlainAction action = null;
                 switch (miembroCO.GetType().Name)
                 {
                     case "JugadorCO": action = new CrearJugadorAction((JugadorCO)miembroCO);
                         break;
                     case "EntrenadorCO": action = new CrearEntrenadorAction((EntrenadorCO)miembroCO);
                         break;
                     case "DirectivoCO": action = new CrearDirectivoAction((DirectivoCO)miembroCO);
                         break;
                     default: action = new CrearJugadorAction((JugadorCO)miembroCO);
                         break;
                 }
                 
                 

                 return (MiembroCO)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }


        public ArbitroVO crearArbitro(ArbitroVO arbitroVO)
        {
             try
             {
                 CrearArbitroAction action = new CrearArbitroAction(arbitroVO);

                 return (ArbitroVO)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }

        public EstadioVO crearEstadio(EstadioVO estadioVO)
         {
             try
             {
                 CrearEstadioAction action = new CrearEstadioAction(estadioVO);

                 return (EstadioVO)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }

        public EquipoTotalCO crearEquipoTotal(EquipoTotalCO equipoTotal)
        {
             try
             {   
                 CrearEquipoTotalAction action = new CrearEquipoTotalAction(equipoTotal);
                 
                 return (EquipoTotalCO)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }

        public MiembroCO obtenerInfoJugadorEditar(int cod_Integrante)
        {
             try
             {
                 ObtenerInfoJugadorEditarAction action = new ObtenerInfoJugadorEditarAction(cod_Integrante);
                 
                 return (MiembroCO)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }

        public MiembroCO updateJugadorTotal(MiembroCO info)
         {
             try
             {
                 UpdateJugadorAction action = new UpdateJugadorAction(info);

                 return (MiembroCO)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }


         public bool checkClasificacionUpdate(int cod_Competicion, String jornada)
         {
             try
             {
                 CheckClasificacionUpdateAction action = new CheckClasificacionUpdateAction(cod_Competicion,jornada);

                 return (Boolean)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }


         }

  }
}