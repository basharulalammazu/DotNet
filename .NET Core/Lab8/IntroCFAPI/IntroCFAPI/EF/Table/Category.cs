using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroCFAPI.EF.Table
{
    public class Category
    {
        [Key] // It is not mandatory when variable name is id 
        public int Id { get; set; }
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }

    }
}
