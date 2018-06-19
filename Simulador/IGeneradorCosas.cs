using System;
using System.Collections;
using System.Collections.Generic;

namespace Simulador
{
    public interface IGeneradorCosas
    {
        ArrayList generaGoleadoresLista(ArrayList lista, int x);
        List<List<Jornada>> generaLiga(List<int> equipos);
        float generarAltura();
        string generarApellidoAleatorio();
        string generarClima();
        DateTime generarFechaAleatoriaNacimiento();
        DateTime generarFechaAleatoriaPartido();
        int generarGoles();
        string generarNombreAleatorio();
        int generarPosesion();
        List<Jornada> generarRondaCopa(List<int> equipos);
        string generarZurdoDiestro();
        ArrayList generaXAleatoriosLista(ArrayList lista, int x);
        string obtenerNombreRondaCopa(int numeroEquipos);
    }
}