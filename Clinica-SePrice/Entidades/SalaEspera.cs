using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_SePrice.Entidades
{
    public class SalaEspera
    {
        [Key]
        public int Id { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraLlamado { get; set; }
        public int TurnoId { get; set; }

        public Turno Turno { get; set; }

    }
}
