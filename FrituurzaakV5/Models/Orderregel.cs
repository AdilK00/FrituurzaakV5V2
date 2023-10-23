namespace FrituurzaakV5.Models
{
    public class Orderregel
    {
        // Properties
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }

        // Relationships
        //One-to-one
        public virtual Product? Product { get; set; }
        public virtual Order? Order { get; set; }
    }
}
