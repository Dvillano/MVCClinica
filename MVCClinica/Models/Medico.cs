using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCClinica.Models
{
    [Table("Medico")]
    public class Medico
    {
        [Key]
        public int MedicoId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; }

        public int NroMatricula { get; set; }

        [Required]
        [MaxLength(50)]
        public string Especialidad { get; set; }
    }
}