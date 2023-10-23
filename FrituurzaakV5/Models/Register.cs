namespace FrituurzaakV5.Models
{
    // Kassa
    public class Register
    {
        // Properties
        public int Id { get; set; }
        public float Total { get; set; }


        // Relationships
        //One-to-one
        public virtual Inventory? Inventory { get; set; }

        // Many-to-one
        public virtual ICollection<Customer>? Customers { get; set; }

        public virtual ICollection<Owner>? OwnerRegisters { get; set; }


    }
}
