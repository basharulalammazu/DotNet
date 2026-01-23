using System.ComponentModel.DataAnnotations;

namespace IntroCFAPI.DTOs
{
    public class CategoryDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
