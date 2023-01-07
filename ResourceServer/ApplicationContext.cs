using Microsoft.EntityFrameworkCore;
using ResourceServer.Models;

namespace ResourceServer
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    }
}
