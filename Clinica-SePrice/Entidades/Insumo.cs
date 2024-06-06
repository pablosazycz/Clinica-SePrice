using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_SePrice.Entidades
{
    public class Insumo
    {
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public int Cantidad { get; set; }

        public int StockMaximo { get; set; }

        public int StockActual { get; set; }
    }
}
