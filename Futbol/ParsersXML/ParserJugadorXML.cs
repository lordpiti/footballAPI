using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using Util.Log;
using System.Collections;
using Futbol.Model.FachadaAdmin;
using Futbol.Model.FachadaAdmin.COs;
using Futbol.Model.Equipo;
using Futbol.Model.Equipo.VO;
using Futbol.Model.Estadio;
using Futbol.Model.Estadio.VO;
using Futbol.Model.Jugador;
using Futbol.Model.Jugador.VO;
using Futbol.Model.Entrenador;
using Futbol.Model.Entrenador.VO;
using Futbol.Model.Directivo;
using Futbol.Model.Directivo.VO;
using Futbol.Model.Integrante;
using Futbol.Model.Integrante.VO;
using Futbol.Model.HcoIntegrante.VO;
//NO ESTA HECHO



namespace Futbol.ParsersXML
{
    public class ParserJugadorXML
    {
        private static bool isValid = true; 
        public static ArrayList parseJugadorXML(String rutaFichero)
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
            int cod_Integrante = 1;
            int cod_Equipo = 1;
            IntegranteVO integrante = null;
            HcoIntegranteVO hcoIntegrante = null;
            JugadorVO jugadorVO = null;
            EntrenadorVO entrenadorVO = null;
            DirectivoVO directivoVO = null;
            JugadorCO jugador = null;
            EntrenadorCO entrenador = null;
            DirectivoCO directivo = null;
            ArrayList listaJugadores = new ArrayList();
            ArrayList listaEntrenadores = new ArrayList();
            ArrayList listaDirectivos = new ArrayList();
            ArrayList listaHcoIntegrantes = new ArrayList();



            bool flag;
            while (flag = xmlReader.Read())
            {

                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:

                        switch (xmlReader.Name)
                        {
                            case "miembro":
                                listaHcoIntegrantes = new ArrayList();
                                while (flag = xmlReader.Read())
                                {
                                    if (xmlReader.NodeType == XmlNodeType.EndElement) break;
                                    switch (xmlReader.NodeType)
                                    {
                                        case XmlNodeType.Element:

                                            switch (xmlReader.Name)
                                            {
                                                case "integrante":
                                                    String nombreIntegrante = "";
                                                    String apellidos = "";
                                                    DateTime fechaNacimiento = DateTime.Now;
                                                    String fotoIntegrante = "";

                                                    while (xmlReader.MoveToNextAttribute())
                                                    {
                                                        switch (xmlReader.Name)
                                                        {
                                                            case "codIntegrante":
                                                                cod_Integrante = Int32.Parse(xmlReader.Value);
                                                                break;
                                                            case "nombreIntegrante":
                                                                nombreIntegrante = xmlReader.Value;
                                                                break;
                                                            case "apellidosIntegrante":
                                                                apellidos = xmlReader.Value;
                                                                break;
                                                            case "fechaNacimiento":
                                                                fechaNacimiento = DateTime.Parse(xmlReader.Value);
                                                                break;
                                                            case "foto":
                                                                fotoIntegrante = xmlReader.Value;
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                    }
                                                    integrante = new IntegranteVO(cod_Integrante, nombreIntegrante, apellidos,
                                                        fechaNacimiento, fotoIntegrante);
                                                    break;
                                                case "hcoIntegrante":
                                                    DateTime fechaInicio = DateTime.Now;
                                                    DateTime fechaFin = DateTime.Now;
                                                    DateTime fechaFinContrato = DateTime.Now;
                                                    int sueldo = 100;
                                                    int dorsal = 1;

                                                    while (xmlReader.MoveToNextAttribute())
                                                    {
                                                        switch (xmlReader.Name)
                                                        {
                                                            case "codEquipo":
                                                                cod_Equipo = Int32.Parse(xmlReader.Value);

                                                                break;
                                                            case "fechaInicio":
                                                                fechaInicio = DateTime.Parse(xmlReader.Value);
                                                                break;
                                                            case "fechaFin":
                                                                if (xmlReader.Value != "En vigor")
                                                                    fechaFin = DateTime.Parse(xmlReader.Value);
                                                                else fechaFin = DateTime.MinValue;
                                                                break;
                                                            case "fechaFinContrato":
                                                                fechaFinContrato = DateTime.Parse(xmlReader.Value);
                                                                break;
                                                            case "sueldo":
                                                                sueldo = Int32.Parse(xmlReader.Value);
                                                                break;
                                                            case "dorsal":
                                                                dorsal = Int32.Parse(xmlReader.Value);
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                    }
                                                    hcoIntegrante = new HcoIntegranteVO(cod_Integrante, cod_Equipo,
                                                        fechaInicio, fechaFin, fechaFinContrato, sueldo, dorsal);
                                                    listaHcoIntegrantes.Add(hcoIntegrante);
                                                    break;

                                                case "jugador":
                                                    float altura = 1;
                                                    String posicion = "";
                                                    String pierna = "diestro";

                                                    while (xmlReader.MoveToNextAttribute())
                                                    {
                                                        switch (xmlReader.Name)
                                                        {
                                                            case "altura":
                                                                altura = float.Parse(xmlReader.Value);
                                                                //     LogManager.RecordMessage(xmlReader.Name + "=" + xmlReader.Value, LogManager.MessageType.INFO);
                                                                break;
                                                            case "posicion":
                                                                posicion = xmlReader.Value;
                                                                //      LogManager.RecordMessage(xmlReader.Name + "=" + xmlReader.Value, LogManager.MessageType.INFO);
                                                                break;
                                                            case "pierna":
                                                                pierna = xmlReader.Value;
                                                                //      LogManager.RecordMessage(xmlReader.Name + "=" + xmlReader.Value, LogManager.MessageType.INFO);
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                    }
                                                    //     LogManager.RecordMessage("HAY " + listaHcoIntegrantes.Count + " HISTORICOS", LogManager.MessageType.INFO);
                                                    jugadorVO = new JugadorVO(cod_Integrante, cod_Equipo, altura, posicion, pierna);
                                                    jugador = new JugadorCO(jugadorVO, listaHcoIntegrantes, integrante);
                                                    listaJugadores.Add(jugador);

                                                    break;
                                                case "entrenador":
                                                    String cargo = "";
                                                    DateTime fechaProfesional = DateTime.Now;

                                                    while (xmlReader.MoveToNextAttribute())
                                                    {
                                                        switch (xmlReader.Name)
                                                        {
                                                            case "cargo":
                                                                cargo = xmlReader.Value;
                                                                break;
                                                            case "fechaProfesional":
                                                                fechaProfesional = DateTime.Parse(xmlReader.Value);
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                    }
                                                    entrenadorVO = new EntrenadorVO(cod_Integrante, cod_Equipo, cargo, fechaProfesional);
                                                    entrenador = new EntrenadorCO(entrenadorVO, listaHcoIntegrantes, integrante);
                                                    listaEntrenadores.Add(entrenador);

                                                    break;
                                                case "directivo":
                                                    String puesto = "";
                                                    String profesion = "";

                                                    while (xmlReader.MoveToNextAttribute())
                                                    {
                                                        switch (xmlReader.Name)
                                                        {
                                                            case "cargo":
                                                                puesto = xmlReader.Value;
                                                                break;
                                                            case "profesion":
                                                                profesion = xmlReader.Value;
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                    }
                                                    directivoVO = new DirectivoVO(cod_Integrante, cod_Equipo, puesto, profesion);
                                                    directivo = new DirectivoCO(directivoVO, listaHcoIntegrantes, integrante);
                                                    listaDirectivos.Add(directivo);

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
            if (isValid) { LogManager.RecordMessage("XML Es valido", LogManager.MessageType.INFO); }
            else
                throw new Exception("XML NO VALIDO");
            ArrayList listaDefinitiva = new ArrayList();
            listaDefinitiva.AddRange(listaJugadores);
            listaDefinitiva.AddRange(listaEntrenadores);
            listaDefinitiva.AddRange(listaDirectivos);
            return listaDefinitiva;

        }


        public static void MyValidationEventHandler(object sender,
                                    ValidationEventArgs args)
        {
            isValid = false;
              LogManager.RecordMessage("Evento de validación\n" + args.Message, LogManager.MessageType.INFO);
        }

    }
}