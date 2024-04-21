using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_SePrice.Entidades
{
    public class Turno
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string Lugar { get; set; }
        public string? Materiales { get; set; }
        public string? Observaciones { get; set; }
        public int Duracion { get; set; }

        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
    }
}
