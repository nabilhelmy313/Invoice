using Domain.Entites;
using Microsoft.EntityFrameworkCore;
namespace Persistence
{
    public class InvoiceDbContext:DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options)
        {

        }
        public DbSet<InvoiceHDR>  InvoiceHDRs{ get; set; }
        public DbSet<ItemsDTL> ItemsDTLs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemsDTL>().Property(m => m.Price).HasPrecision(14, 3);
        }
    }
}
