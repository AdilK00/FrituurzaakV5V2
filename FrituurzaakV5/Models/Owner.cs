namespace FrituurzaakV5.Models
{
    public class Owner
    {
        // Properties
        public int Id { get; set; }
        public string? Ownerusername { get; set; }
        public string? Ownerpassword { get; set; }
        public int CompanyId { get; set; }

        // Relationships
        //One-to-one
        public virtual Company? Company { get; set; }
        // Many-to-one
        public virtual ICollection<Register>? Registers { get; set; }

    }
}