using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_SePrice.Entidades
{
    public class EspecialidadEstudioMedico
    {
        [Key]
        public int Id { get; set; }

        
        [ForeignKey("EstudioMedico")]
        public int EstudioMedicoId { get; set; }

        [ForeignKey("Especialidad")]
        public int EspecialidadId { get; set; }

        
        public EstudioMedico EstudioMedico { get; set; }
        public Especialidad Especialidad { get; set; }
    }
}
