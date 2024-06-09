using System.ComponentModel.DataAnnotations;

namespace DTO.Client
{
    public class ClientUpdateDto
    {
        
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string State { get; set; }
    }
}
