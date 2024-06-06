using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_SePrice.Entidades
{
    public class TransaccionInsumo
    {
        [Key]
        public int Id { get; set; }

        public int InsumoId { get; set; }
        public Insumo Insumo { get; set; }

        public int CantidadUtilizada { get; set; }

        public DateTime Fecha { get; set; }

        public int TurnoId { get; set; }
        public Turno Turno { get; set; }
    }
}
