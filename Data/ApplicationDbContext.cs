using NewsApi.Models;
using Microsoft.EntityFrameworkCore;
namespace NewsApi.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) { }
        public DbSet<News> News { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}