using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("Telefonos")]
    public class Telefono
    {
        [Column("TelefonoID")]
        public int TelefonoId { get; set; }
        [Required]
        [Column("Telefono", TypeName = "varchar(20)")]
        public string Numero { get; set; } // La propiedad no puede llamarse como la clase

        public Persona Persona { get; set; }
        [Column("PersonaID")]
        public int PersonaId { get; set; }
    }
}
