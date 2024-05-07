using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_SePrice.Entidades
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public bool EnSalaEspera { get; set;}


        //public string NroTelefono { get; set; }
        //public string HistoriaClinica { get; set; }
        //public string NroAfiliado { get; set; }
        //public string ObraSocial { get; set; }
    }

}
