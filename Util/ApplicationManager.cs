using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml;
using Util.Log;
using System.Xml.XPath;


namespace Util
{
    public class ApplicationManager
    {
  /*      public static ArrayList configureParameters(String ruta)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = false;
            
            XmlReader xmlReader = XmlReader.Create(ruta,settings);
           
            ArrayList competiciones = new ArrayList();
            String comp = null;
            Int32 numero=1;
            String codEquipo;

            
            bool flag;
            while (flag = xmlReader.Read())
            {
                
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (xmlReader.Name == "equipoActual")
                        {
                            while (xmlReader.MoveToNextAttribute())
                                switch (xmlReader.Name)
                                {
                                    case "codEquipo":
                                        codEquipo = xmlReader.Value;
                                        break;
                                    default:
                                        break;                                   
                                }
                        }
                        else 
                        {
                            while (xmlReader.Read())
                            {
                                switch (xmlReader.NodeType)
                                {
                                    case XmlNodeType.Element:
                                        if (xmlReader.Name == "competicion")
                                        {
                                            while (xmlReader.MoveToNextAttribute())
                                            {
                                                switch (xmlReader.Name)
                                                {
                                                    case "id":
                                                        comp = xmlReader.Value;
                                                        numero=Int32.Parse(comp);                                                   
                                                        break;
                                                    case "jornada":
                                                        comp = xmlReader.Value;
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }
                                            competiciones.Add(new CompeticionJornadaCO(numero,comp));
                                        }
                                        break;
                                }
                            }
                        }
                        
                        break;                      
                    case XmlNodeType.Text:
                        break;
                    case XmlNodeType.EndElement:
                        break;
                 }
                break;
            }
            
            return competiciones;

        }*/


        public static ArrayList verCompeticionesActuales(String rutaFichero)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(rutaFichero);
            ArrayList competiciones = new ArrayList();

            XPathNavigator nav = doc.CreateNavigator();
            XPathNodeIterator iterator = nav.Select("//configuracion/listaCompeticiones/competicion/@id");
            XPathNodeIterator iterator2 = nav.Select("//configuracion/listaCompeticiones/competicion/@jornada");

            while (iterator.MoveNext())
             {
                 iterator2.MoveNext();
                competiciones.Add(new CompeticionJornadaCO(Int32.Parse(iterator.Current.Value),iterator2.Current.Value));
             }
            return competiciones;
        }


        public static void modificarCompeticionesActuales(String rutaFichero, ArrayList listaCompeticiones)
        {
            XmlTextReader reader = new XmlTextReader(rutaFichero);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();

            XmlElement root = doc.DocumentElement;

            XmlElement newListaCompeticiones = doc.CreateElement("listaCompeticiones");

            XmlNode oldListaCompeticiones;
            oldListaCompeticiones = root.SelectSingleNode("/configuracion/listaCompeticiones");
            //newRSS = doc.CreateElement("rss");

            foreach (CompeticionJornadaCO item in listaCompeticiones)
            {
                XmlElement newCompeticion = doc.CreateElement("competicion");
                newCompeticion.SetAttribute("id", Convert.ToString(item.Cod_Competicion));
                newCompeticion.SetAttribute("jornada", item.Jornada);
                newListaCompeticiones.AppendChild(newCompeticion);
            }

            root.SelectSingleNode("/configuracion").ReplaceChild(newListaCompeticiones, oldListaCompeticiones);

            doc.Save(rutaFichero);
        }

    }
}
