using Microsoft.EntityFrameworkCore;

namespace ProductandCategoryManagementAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Model.Category> Categories { get; set; }
        public DbSet<Model.Product> Products { get; set; }
    }
}
