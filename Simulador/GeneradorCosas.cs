using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util;


namespace Simulador
{
    public class GeneradorCosas
    {

        private Random rand = new Random();
        private ArrayList listaNombres=new ArrayList();
        private ArrayList listaApellidos=new ArrayList();

                
        private String nombres = "Juan Pedro Pablo Jose Alejandro Bruno Arturo Carlos" +
            " Miguel Manuel Israel Jonathan Luis Ignacio Javier Marcos Jorge Diego " +
            "Federico Francisco Jesus Rodrigo Pelayo Maximo Tomas Andres Borja Gonzalo " +
            "Fernando Rafael Lucas Pedro Alberto Alfonso Emilio Antonio Victor Vicente " +
            "Felix Ramon Jaime Raul Dario Iago David Daniel John Paul Michael Dwayne " +
            "Lionel Frank Charles Steven Ryan Seth Nicolas Tom Giovanni Francesco " +
            "Laurent Pierre Oliver James Jason Clifford Phillip Karl Leonardo Jean " +
            "Cesar Oscar Ruben Ricardo Leopoldo Clark Jack Arthur Angel Boris"+
            "Vladimir Hidetoshi Hiroshi Paolo Bernardo Harry Theo Lewis Mark Giancarlo "+
            "Gervasio Perry Hermenegildo Adrian Sebastian Heikki Kimi Robert Nick "+
            "Agustin Takuma Henry William Mateo Lothar Anderson Chris Brad George "+
            "Novak Wilfred Nikolay Nicolas";

        private String apellidos = "Abad Abadia Abadejo Amil Amor Amado Basanta Baltar " +
            "Bonigno Autista Atorao Basurero Bazofia Badulake Simpson Smith Garcia "+
            "Gonzalez Cachafeiro Mourenza Puy Amigo Doolie Schoolie Smith Perez "+
            "Messi Cassano Baggio Totti Gonzalez Gutierrez Kent Mason Carter Busto "+
            "Antas Jefferson Bryant Gasol Alonso Nadal Navarro Cardona Casal Rodriguez "+
            "Gomez Iglesias Lema Martinez Casanova Prieto Soto Vega Rey Palla Munoz "+
            "Figueroa Varela Campos Nogueira Ferreiro Blanco Zapatero Tourino Aguado "+
            "Meilan Pintos Rooney Lampard Terry Riquelme Batistuta Assis Silva Valle "+
            "Quiroga Stoyanoff Kiriakov Berbatov Rebrov Petrov Kirilenko Oneal Etoo "+
            "Alfaro Munitis Crespo Tevez Love Bosch Miller Ballack Castro Sobrino "+
            "King Queen Rojo Nito Torrente Sanchez Blas Somoza Benito Bamonde Lagar "+
            "Palanca Vila Lopez Corral Pena Patino Herrera Robles Cantizano Cruz "+
            "Nishikawa Diaz Moreno Rubio Andrade Bellas Palacios Vales Vizoso Calderon "+
            "Garbajosa Montero Balado Carballo Moreno Nowitzki Kovacevic Krkic Iniesta "+
            "Roman Hewitt Kirchner Blair Bush Aznar Berlusconi Hitler Ping Topalov "+
            "Hiroshima Ichikawa Kawashima Shiranui Sharapov Pestov Wiggum Simpson "+
            "Burns Moe Poe Brown Smithers Raikonnen Kovalainen Hamilton Schumacher "+
            "Chela Federer Djokovic Tsonga Davydenko Roddick Moya";



        public String generarNombreAleatorio()
        {
            Tokens f = new Tokens(nombres,
            new char[] { ' ', '-' });
            foreach (string item in f)
            {
                listaNombres.Add(item);
            }      

            return (String)listaNombres[rand.Next(0,listaNombres.Count)];
        }


        public String generarApellidoAleatorio()
        {
            Tokens f = new Tokens(apellidos,
            new char[] { ' ', '-' });
            foreach (string item in f)
            {
                listaApellidos.Add(item);
            }

            return (String)listaApellidos[rand.Next(0,listaApellidos.Count)];
        }

        //genera una fecha aleatoria de nacimiento de un jugador
        public DateTime generarFechaAleatoriaNacimiento()
        {          
            int dia = rand.Next(1, 28);
            int mes = rand.Next(1, 12);
            int ano = 1972 + rand.Next(1, 20);

            return (new DateTime(ano,mes,dia));

        }

        
        //genera una altura de un jugador
        public float generarAltura()
        {
            float margen = (float) ((float)rand.Next(165, 195)*0.01);

            return margen;

        }

       
        //genera una fecha aleatoria para un partido
        public DateTime generarFechaAleatoriaPartido()
        {
            int dia = rand.Next(1, 28);
            int mes = rand.Next(1, 12);
            int ano = 2008 + rand.Next(1, 2);

            return (new DateTime(ano,mes, dia));

        }

        
        //genera un string zurdo o diestro
        public String generarZurdoDiestro()
        {
            if (rand.Next(0, 100) < 75) return "Diestro";
            else return "Zurdo";
                
        }


        //genera un string clima despejado o lluvia
        public String generarClima()
        {
            if (rand.Next(0, 100) < 25) return "Lluvia";
            else return "Despejado";
        }


        //genera un numero de goles enttre 0 y 4
        public int generarGoles()
        {
            return rand.Next(0, 4);

        }


        //genera la posesion de un equipo
        public int generarPosesion()
        {
            return rand.Next(20, 80);
        }


        //elige x elementos aleatorios de una lista dada sin repetirse
        public ArrayList generaXAleatoriosLista(ArrayList lista,int x)
        {
            ArrayList listaFinal=new ArrayList();
            int indice;
            for (int i = 0; i < x; i++) {
                indice = rand.Next(0, lista.Count);
                listaFinal.Add(lista[indice]);
                lista.RemoveAt(indice);
            }
            int cambios = rand.Next(0, 4);
            for (int i = 0; i < cambios; i++)
            {
                indice = rand.Next(0, lista.Count);
                listaFinal.Add(lista[indice]);
                lista.RemoveAt(indice);
            }

            return listaFinal;
        }




        //elige x elementos aleatorios de una lista dada sin repetirse
        public ArrayList generaGoleadoresLista(ArrayList lista, int x)
        {
            ArrayList listaFinal = new ArrayList();
            int indice;
            for (int i = 0; i < x; i++)
            {
                indice = rand.Next(0, lista.Count);
                listaFinal.Add(lista[indice]);
                lista.RemoveAt(indice);
            }
            
            return listaFinal;
        }



        //Genera un ArrayList con el calendario de una liga

        public List<List<Jornada>> generaLiga(List<int> equipos) 
        {
        
            var lista1 = new List<int>();
            for (int p = 0; p < equipos.Count/2; p++) 
            {
                lista1.Add(equipos[p]);
            }

            
            var lista2 = new List<int>();
            for (int p = equipos.Count/2; p < equipos.Count; p++)
            {
                lista2.Add(equipos[p]);
            }

            
            lista2.Reverse();

            var liga = new List<List<Jornada>>();
            var temporal = new List<int>();
            int tamano=equipos.Count-1;
            int ultimo,primero;

            for (int j = 0; j < tamano; j++)
            {

                var jornada = new List<Jornada>();
                for (int i = 0; i < (equipos.Count)/2; i++)
                {
                    jornada.Add(new Jornada(lista1[i], lista2[i]));
                }

                temporal.Clear();
                for (int i = 1; i < lista1.Count - 1; i++)
                {
                    temporal.Add(lista1[i]);
                }

                primero = lista1[0];
                ultimo = lista1[lista1.Count - 1];

                lista1.Clear();
                lista1.Insert(0, primero);
                lista1.Insert(1, lista2[0]);
                lista1.InsertRange(2, temporal);
                lista2.RemoveAt(0);              
                lista2.Add(ultimo);

                liga.Add(jornada);
            }


            //Ahora generamos los partidos de vuelta

            //int contador = 1;
            var ligaDef = new List<List<Jornada>>();

            foreach (var item in liga)
            {
                ligaDef.Add(item);
            }

            foreach (var item in liga)
            {
                var vuelta = new List<Jornada>();
                foreach (var jor in item)
                {
                    vuelta.Add(new Jornada(jor.Visitante, jor.Local));
                }
                ligaDef.Add(vuelta);
            }



            return ligaDef;

        }

        public ArrayList generarRondaCopa(ArrayList equipos)
        {
            ArrayList equiposBombo1=new ArrayList();
            ArrayList equiposBombo2=new ArrayList();
            ArrayList emparejamientosRonda = new ArrayList();

            for (int i = 0; i < equipos.Count / 2; i++)
            {
                equiposBombo1.Add(equipos[i]);
            }

            for (int i = equipos.Count /2; i < equipos.Count; i++)
            {
                equiposBombo2.Add(equipos[i]);
            }


            int equipoRival;
            foreach (int item in equiposBombo1)
            {
                equipoRival = (int)equiposBombo2[rand.Next(0, equiposBombo2.Count - 1)];
                equiposBombo2.Remove(equipoRival);
                emparejamientosRonda.Add(new Jornada(item, equipoRival));
            }


            return emparejamientosRonda;
        }

        public String obtenerNombreRondaCopa(int numeroEquipos)
        {
            switch (numeroEquipos)
            {
                case 2: return "Final";
                    
                case 4: return "Semifinal";
                    
                case 8: return "1/4 Final";
                    
                case 16: return "1/8 Final";
                    
                case 32: return "1/16 Final";
                    
                default: return "Fase previa";
                    

            }

        }

    }
}
