using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using Util.Log;
using System.Collections;
using Futbol.Model.Competicion.VO;
using Futbol.Model.FachadaPartidos;
using Futbol.Model.FachadaDatos;
using Futbol.Model.Calendario.VO;


namespace Futbol.ParsersXML
{
    public class ParserCompeticionXML
    {
        private static bool isValid = true; 
        public static CompeticionTotalCO parseCompeticionXML(String rutaFichero)
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
            

            CompeticionVO competicionVO = null;
            ArrayList calendario = new ArrayList();
            ArrayList listaParticipantes = new ArrayList();


            bool flag;
            while (flag = xmlReader.Read())
            {
                
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:

                        switch (xmlReader.Name)
                        {
                            case "info":
                                String nombre = "";
                                String temporada = "";
                                DateTime fechaInicio = DateTime.Now;
                                DateTime fechaFin = DateTime.Now;
                                String campeon = "";
                                String foto = "";
                                String tipo = "";


                                while (xmlReader.MoveToNextAttribute())
                                {
                                    switch (xmlReader.Name)
                                    {
                                        case "nombre":
                                            nombre = xmlReader.Value;
                                            break;
                                        case "temporada":
                                            temporada = xmlReader.Value;
                                            break;
                                        case "fechaInicio":
                                            fechaInicio = DateTime.Parse(xmlReader.Value);
                                            break;
                                        case "fechaFin":
                                            fechaFin = DateTime.Parse(xmlReader.Value);
                                            break;
                                        case "campeon":
                                            campeon=xmlReader.Value;
                                            break;
                                        case "foto":
                                            foto = xmlReader.Value;
                                            break;
                                        case "tipo":
                                            tipo = xmlReader.Value;
                                            break;
                                        default:
                                            break;
                                    }

                                }

                                competicionVO = new CompeticionVO(nombre, temporada, fechaInicio, fechaFin,
                                    campeon, foto, tipo);
                                break;
                            case "calendario":
                                String jornada = "";
                                int codLocal = 1;
                                int codVisitante = 30;
                                DateTime fecha = DateTime.Now;

                                while (xmlReader.MoveToNextAttribute())
                                {
                                    switch (xmlReader.Name)
                                    {
                                        case "jornada":
                                            jornada = xmlReader.Value;
                                            break;
                                        case "codLocal":
                                            codLocal= Int32.Parse(xmlReader.Value);
                                            
                                            break;
                                        case "codVisitante":
                                            codVisitante = Int32.Parse(xmlReader.Value);
                                            
                                            break;
                                        case "fecha":
                                            fecha = DateTime.Parse(xmlReader.Value);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                
                                calendario.Add(new CalendarioVO(900, jornada, codLocal, codVisitante, fecha));
                                break;
                            case "participa":
                                Int32 codigo = 1;

                                while (xmlReader.MoveToNextAttribute())
                                {
                                    switch (xmlReader.Name)
                                    {
                                        case "codigo":
                                            codigo = Int32.Parse(xmlReader.Value);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                
                                listaParticipantes.Add(codigo);
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
            if (isValid) { }//LogManager.RecordMessage("XML Es valido", LogManager.MessageType.INFO);
            else
                throw new Exception("XML NO VALIDO");

            return new CompeticionTotalCO(competicionVO, calendario,listaParticipantes);

        }

        public static void MyValidationEventHandler(object sender,
                                            ValidationEventArgs args)
        {
            isValid = false;
          //  LogManager.RecordMessage("Evento de validación\n" + args.Message, LogManager.MessageType.INFO);
        }

    }
}
