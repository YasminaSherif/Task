using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ClientProduct
{
    public class ClientProductDetailesDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [MaxLength(255)]
        [Required]
        public string License { get; set; }
        [Required]
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        [Required]
        public string ProductId { get; set; }
        public string ProductName { get; set; }

    }
}
