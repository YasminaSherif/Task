﻿using System.ComponentModel.DataAnnotations;

namespace DTO.ClientProduct
{
    public class ClientProductUpdateDto
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
