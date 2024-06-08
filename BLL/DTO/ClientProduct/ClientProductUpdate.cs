using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.ClientProduct
{
    public class ClientProductUpdate
    {
     
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [MaxLength(255)]
        [Required]
        public string License { get; set; }
        [Required]
        public string ClientId { get; set; }
        [Required]
        public string ProductId { get; set; }
    }
}
