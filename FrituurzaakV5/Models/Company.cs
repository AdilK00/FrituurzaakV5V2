﻿namespace FrituurzaakV5.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<Owner> Owners { get; set; }
    }
}
