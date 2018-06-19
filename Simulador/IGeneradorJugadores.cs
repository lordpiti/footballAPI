using System.Collections;

namespace Simulador
{
    public interface IGeneradorJugadores
    {
        ArrayList generaCuerpoTécnico(int cod_Equipo);
        ArrayList generaDirectiva(int cod_Equipo);
        ArrayList generaPlantilla(int cod_Equipo);
    }
}