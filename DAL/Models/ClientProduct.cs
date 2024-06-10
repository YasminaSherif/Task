using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class ClientProduct
    {
        public string Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string License { get; set; }

        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

        public string ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
