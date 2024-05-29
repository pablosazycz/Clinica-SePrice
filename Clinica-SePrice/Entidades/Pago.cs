using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_SePrice.Entidades
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Turno")]
        public int TurnoId { get; set; }

        [Required]
        public string MetodoPago { get; set; }

        public string NombreObraSocial { get; set; }

        public string NumeroObraSocial { get; set; }

        public DateTime FechaPago { get; set; }

        public Turno Turno { get; set; }
    }
}
