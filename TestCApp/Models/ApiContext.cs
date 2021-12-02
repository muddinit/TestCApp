using Microsoft.EntityFrameworkCore;
using TestCApp.Models;

namespace TestCApp
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Dot> Dots { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}