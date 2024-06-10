
using System.ComponentModel.DataAnnotations;

namespace DTO.Client
{
    public class ClientDto
    {
        [Required]
        public string Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [StringLength(9, ErrorMessage = "Code Must be 9 characters", MinimumLength = 9)]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Code must be exactly 9 digits.")]
        [Required]
        public string Code { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string State { get; set; }

    }
}
