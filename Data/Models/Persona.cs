using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("Personas")]
    public class Persona
    {
        [Column("PersonaID")]
        public int PersonaId { get; set; }
        [Required, StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Range(typeof(decimal), "0", "999999999999999999.99")]
        [Column(TypeName = "numeric(20, 2)")]
        public decimal CreditoMaximo { get; set; }

        public ICollection<Telefono> Telefonos { get; set; }
    }
}
