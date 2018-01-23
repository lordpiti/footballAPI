using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using Util.Log;
using System.Collections;
using Futbol.Model.FachadaPartidos;
using Futbol.Model.Partido;
using Futbol.Model.Partido.VO;
using Futbol.Model.PartidoJugado;
using Futbol.Model.PartidoJugado.VO;
using Futbol.Model.Gol.VO;
using Futbol.Model.Tarjeta.VO;
using Futbol.Model.Cambio.VO;

namespace Futbol.ParsersXML
{
    public class ParserJornadaXML
    {
        private static bool isValid = true; 
        public static PartidoTotalCO parseJornadaXML(String rutaFichero)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            settings.IgnoreProcessingInstructions = true;
            settings.ProhibitDtd = false;
            settings.ValidationType = ValidationType.DTD;
            settings.ValidationEventHandler +=
new ValidationEventHandler(MyValidationEventHandler);


            XmlReader xmlReader = XmlReader.Create(rutaFichero, settings);
            PartidoVO partido = null;
            ArrayList partidosJugados = new ArrayList();
            var goles = new List<GolVO>();
            var cambios = new List<CambioVO>();
            var tarjetas = new List<TarjetaVO>();



            bool flag;
            while (flag = xmlReader.Read())
            {
          //      LogManager.RecordMessage(xmlReader.Name, LogManager.MessageType.INFO);
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:

                        switch (xmlReader.Name)
                        {
                            case "datosPartido":
                                int cod_Competicion = 0;
                                String jornada = "";
                                int cod_Local = 1;
                                int cod_Visitante = 2;
                                DateTime fecha = DateTime.Now;
                                String clima = "";
                                int goles_Local = 1;
                                int goles_Visitante = 2;
                                float posesion_Local = 50;
                                float posesion_Visitante = 50;
                                int corners_Local = 10;
                                int corners_Visitante = 5;
                                int fuerasJuego_Local = 1;
                                int fuerasJuego_Visitante = 2;
                                int asistencia = 1111;
                                int cod_Arbitro = 1;
                                int cod_Estadio = 1;

                                while (xmlReader.MoveToNextAttribute())
                                {
                                    switch (xmlReader.Name)
                                    {
                                        case "competicion":
                                            cod_Competicion = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "jornada":
                                            jornada = xmlReader.Value;
                                            break;
                                        case "equipoLocal":
                                            cod_Local = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "equipoVisitante":
                                            cod_Visitante = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "fecha":
                                            fecha = DateTime.Parse(xmlReader.Value);
                                            break;
                                        case "clima":
                                            clima = xmlReader.Value;
                                            break;
                                        case "golesLocal":
                                            goles_Local = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "golesVisitante":
                                            goles_Visitante = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "posesionLocal":
                                            posesion_Local = float.Parse(xmlReader.Value);
                                            break;
                                        case "posesionVisitante":
                                            posesion_Visitante = float.Parse(xmlReader.Value);
                                            break;
                                        case "cornersLocal":
                                            corners_Local = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "cornersVisitante":
                                            corners_Visitante = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "arbitro":
                                            cod_Arbitro = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "estadio":
                                            cod_Estadio = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "asistencia":
                                            asistencia = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "fuerasJuegoLocal":
                                            fuerasJuego_Local = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "fuerasJuegoVisitante":
                                            fuerasJuego_Visitante = Int32.Parse(xmlReader.Value);
                                            break;
                                        default:
                                            break;
                                    }

                                }
                                
                                partido = new PartidoVO(cod_Competicion, jornada, cod_Local, cod_Visitante,
                                    fecha, clima, goles_Local, goles_Visitante, posesion_Local, posesion_Visitante,
                                    corners_Local, corners_Visitante, fuerasJuego_Local, fuerasJuego_Visitante,
                                    asistencia, cod_Arbitro, cod_Estadio);
                                break;
                            case "partidoJugado":
                                int cod_Jugador = 1;
                                int cod_Partido = 1;
                                String titular = "Titular";
                                int minutos = 1;
                                int asistencias = 1;
                                int asistenciasGol = 1;
                                int remates = 1;
                                int rematesPorteria = 1;
                                int rematesPoste = 1;
                                int fuerasJuego = 4;
                                int tarjetasAmarillasProvocadas = 1;
                                int tarjetasRojasProvocadas = 1;
                                int faltasRecibidas = 1;
                                int faltasCometidas = 1;
                                int corners = 1;
                                int balonesRecuperados = 1;
                                int balonesPerdidos = 1;
                                int penaltisRecibidos = 1;
                                int penaltisCometidos = 1;

                                while (xmlReader.MoveToNextAttribute())
                                {
                                    switch (xmlReader.Name)
                                    {
                                        case "codJugador":
                                            cod_Jugador = Int32.Parse(xmlReader.Value);
                                    //        LogManager.RecordMessage(xmlReader.Name + "=" + xmlReader.Value, LogManager.MessageType.INFO);
                                            break;
                                        case "codPartido":
                                            cod_Partido = Int32.Parse(xmlReader.Value);
                                       //     LogManager.RecordMessage(xmlReader.Name + "=" + xmlReader.Value, LogManager.MessageType.INFO);
                                            break;
                                        case "titular":
                                            titular = xmlReader.Value;
                                       //     LogManager.RecordMessage(xmlReader.Name + "=" + xmlReader.Value, LogManager.MessageType.INFO);
                                            break;
                                        case "minutos":
                                            minutos = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "asistencias":
                                            asistencias = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "asistenciasGol":
                                            asistenciasGol = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "remates":
                                            remates = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "rematesPorteria":
                                            rematesPorteria = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "rematesPoste":
                                            rematesPoste = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "fuerasJuego":
                                            fuerasJuego = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "tarjetasAmarillasProvocadas":
                                            tarjetasAmarillasProvocadas = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "tarjetasRojasProvocadas":
                                            tarjetasRojasProvocadas = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "faltasRecibidas":
                                            faltasRecibidas = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "faltasCometidas":
                                            faltasCometidas = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "corners":
                                            corners = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "balonesRecuperados":
                                            balonesRecuperados = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "balonesPerdidos":
                                            balonesPerdidos = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "penaltisRecibidos":
                                            penaltisRecibidos = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "penaltisCometidos":
                                            penaltisCometidos = Int32.Parse(xmlReader.Value);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                
                                partidosJugados.Add(new PartidoJugadoVO(cod_Jugador, titular, minutos, asistencias,
                                    asistenciasGol, remates, rematesPorteria, rematesPoste, fuerasJuego,
                                    tarjetasAmarillasProvocadas, tarjetasRojasProvocadas, faltasRecibidas,
                                    faltasCometidas, corners, balonesRecuperados, balonesPerdidos, penaltisRecibidos,
                                    penaltisCometidos));
                                break;

                            case "gol":
                                int cod_Jugador_Gol = 1;
                                int minuto = 5;
                                String tipo = "";
                                while (xmlReader.MoveToNextAttribute())
                                {
                                    switch (xmlReader.Name)
                                    {
                                        case "codJugador":
                                            cod_Jugador_Gol = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "minuto":
                                            minuto = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "tipo":
                                            tipo = xmlReader.Value;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                goles.Add(new GolVO(cod_Jugador_Gol, minuto, tipo));
                                break;
                            case "tarjeta":
                                int cod_Jugador_Tarjeta = 5;
                                int minutoTarjeta = 6;
                                String tipoTarjeta = "";
                                String motivo = "";
                                while (xmlReader.MoveToNextAttribute())
                                {
                                    switch (xmlReader.Name)
                                    {
                                        case "codJugador":
                                            cod_Jugador_Tarjeta = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "minuto":
                                            minutoTarjeta = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "tipo":
                                            tipoTarjeta = xmlReader.Value;
                                            break;
                                        case "motivo":
                                            motivo = xmlReader.Value;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                tarjetas.Add(new TarjetaVO(cod_Jugador_Tarjeta, minutoTarjeta, tipoTarjeta, motivo));
                                break;

                            case "cambio":
                                int codJugadorEntra = 1;
                                int codJugadorSale = 2;
                                int minutoCambio = 1;
                                while (xmlReader.MoveToNextAttribute())
                                {
                                    switch (xmlReader.Name)
                                    {
                                        case "codJugadorEntra":
                                            codJugadorEntra = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "codJugadorSale":
                                            codJugadorSale = Int32.Parse(xmlReader.Value);
                                            break;
                                        case "minuto":
                                            minutoCambio = Int32.Parse(xmlReader.Value);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                cambios.Add(new CambioVO(codJugadorEntra, codJugadorSale, minutoCambio));
                                break;
                            default: break;
                        }
                        break;
                            case XmlNodeType.Text:
                                break;
                            case XmlNodeType.EndElement:
                                break;
                        }
                        
                }

                xmlReader.Close();
                LogManager.RecordMessage(isValid.ToString(), LogManager.MessageType.INFO); 
                if (isValid) 
                { //LogManager.RecordMessage("XML Es valido", LogManager.MessageType.INFO); 
                }
                else
                    throw new Exception("XML NO VALIDO");

                return new PartidoTotalCO(partido, partidosJugados, goles,
                    cambios, tarjetas);

            }


        public static void MyValidationEventHandler(object sender,
                            ValidationEventArgs args)
        {
            LogManager.RecordMessage("Evento de validación\n" + args.Message, LogManager.MessageType.INFO);
            isValid = false;
            LogManager.RecordMessage("Evento de validación\n" + args.Message, LogManager.MessageType.INFO);
        }

    }

}