using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_SePrice.Entidades
{
    public class Medico
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }

        public string NombreCompleto
        {
            get { return $"{Nombre} {Apellido}"; }
        }

    }
}
