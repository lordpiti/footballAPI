using System.Collections;

namespace Simulador
{
    public interface IGeneradorJugadores
    {
        ArrayList generaCuerpoTecnico(int cod_Equipo);
        ArrayList generaDirectiva(int cod_Equipo);
        ArrayList generaPlantilla(int cod_Equipo);
    }
}