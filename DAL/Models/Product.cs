using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Product
    {
        public string Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public bool IsActive { get; set; }

        public virtual List<ClientProduct> ClientProducts { get; set; } = new List<ClientProduct> { };
    }
}
