using Microsoft.Win32;

namespace FrituurzaakV5.Models
{
    public class Customer
    {
        // Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RegisterId { get; set; }

        // Relationships
        //One-to-one
        public virtual Register Register { get; set; }

        // Many-to-one
        public virtual ICollection<Order> Orders { get; set; }

    }
}
