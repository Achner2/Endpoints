using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace WebApplication2.Models.Entity
{
    public class Dog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "No puede tener mas de 100 caracteres")]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Timestamp]
        public DateTime CreatedDate { get; set; }
    }
}
