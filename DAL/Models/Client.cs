using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Client
    {
        public string Id { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        public ClientClass Class { get; set; }
        public ClientState State { get; set; }

        public virtual List<ClientProduct> ClientProducts { get; set; } = new List<ClientProduct> { };
    }

    public enum ClientClass
    {
        A,
        B,
        C
    }

    public enum ClientState
    {
        Active,
        Inactive,
        Pending
    }
}
