using IntroCFAPI.EF.Table;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace IntroCFAPI.EF
{
    public class PMSContext : DbContext
    {
        public PMSContext(DbContextOptions<PMSContext> options) : base (options)
        { 

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

    
}
