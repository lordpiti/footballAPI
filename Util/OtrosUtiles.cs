using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    public class OtrosUtiles
    {
        public static String verJornadaSiguiente(String jornada)
        {
            switch (jornada)
            {
                case "1/16 Final":
                    return "1/8 Final";
                default:
                    return (Convert.ToString(Int32.Parse(jornada) + 1));
            }

        }
    }
}
