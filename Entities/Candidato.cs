using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace RRHHApi.Entities
{
    public class Candidato
    {
        public Candidato() { }


        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime? FechaDeNacimiento { get; set; }
        [Key]
        public string Email { get; set; }

        public string Telefono { get; set; }

        public ICollection<Empleo> Empleos { get; set; }
    }
}
