using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Materiales { get; set; }
        public string Observaciones { get; set; }
        public int Duracion { get; set; }
        public bool Validado { get; set; }
        public bool Sobreturno { get; set; } = false;      // public string Estado { get; set; }

        // Propiedades de las claves foráneas
        public int? MedicoId { get; set; }
        public int PacienteId { get; set; }
        public int? SalaEsperaId { get; set; }
        public int? EstudioMedicoId { get; set; }

        
        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }

        [ForeignKey("PacienteId")]
        public Paciente Paciente { get; set; }

        [ForeignKey("EstudioMedicoId")]
        public EstudioMedico Estudio { get; set; }

        [ForeignKey("SalaEsperaId")]
        public SalaEspera SalaEspera { get; set; }



    }
}
