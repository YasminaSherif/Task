using System.ComponentModel.DataAnnotations;

namespace DTO.Product
{
    public class productUpdateDto
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(150)]
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
