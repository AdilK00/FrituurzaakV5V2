using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FrituurzaakV5.Models;

namespace FrituurzaakV5.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FrituurzaakV5.Models.Product> Product { get; set; } = default!;
        public DbSet<FrituurzaakV5.Models.Order> Order { get; set; } = default!;
        public DbSet<FrituurzaakV5.Models.Orderregel> Orderregel { get; set; } = default!;
    }
}