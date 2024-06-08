using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.ClientProduct
{
    public class ClientProductCreateDto
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        [MaxLength(255)]
        [Required]
        public string License { get; set; }
        public string ClientId { get; set; }
        public string ProductId { get; set; }

    }
}
