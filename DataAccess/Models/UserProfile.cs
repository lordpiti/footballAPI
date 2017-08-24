using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class UserProfile
    {
        public string LoginName { get; set; }
        public string EnPassword { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int? Cp { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public string Tarjeta { get; set; }
        public string FechaTarjeta { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
    }
}
