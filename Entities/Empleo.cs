using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace RRHHApi.Entities
{
    public class Empleo
    {
        public Empleo() { }

        public int Id { get; set; }

        public string NombreEmpresa { get; set; }

        public string Periodo { get; set; }


    }
}
