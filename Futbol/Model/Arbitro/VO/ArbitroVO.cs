using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Arbitro.VO
{
    public class ArbitroVO
    {
        private int cod_Arbitro;
        private String nombre;
        private String apellidos;
        private String colegio;
        private int anos_activo;
        private String foto;


        public ArbitroVO(int cod_Arbitro, String nombre, String apellidos, String colegio,
            int anos_activo, String foto)
        {
            this.cod_Arbitro = cod_Arbitro;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.colegio = colegio;
            this.anos_activo=anos_activo;
            this.foto=foto;
        }

        public ArbitroVO(String nombre, String apellidos, String colegio,
            int anos_activo, String foto)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.colegio = colegio;
            this.anos_activo = anos_activo;
            this.foto = foto;
        }


        public int Cod_Arbitro
        {
            get { return cod_Arbitro; }
            set { cod_Arbitro = value; }
        }


        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public String Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public String Colegio
        {
            get { return colegio; }
            set { colegio = value; }
        }

        public int Anos_Activo
        {
            get { return anos_activo; }
            set { anos_activo = value; }
        }

        public String Foto
        {
            get { return foto; }
            set { foto = value; }
        }


        public String toString()
        {
            return (" ");
        }
    }
}