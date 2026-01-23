using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroCFAPI.EF.Table
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }
        public double Price { get; set; }
        [ForeignKey("Category")]
        public int CId { get; set; }
        public virtual Category Category { get; set; }
    }
}
