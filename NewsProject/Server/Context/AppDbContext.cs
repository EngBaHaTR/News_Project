using Microsoft.EntityFrameworkCore;
using NewsProject.Client;
using NewsProject.Shared.Models;
using System.Text;

namespace NewsProject.Server.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<NewsList> NewsLists { get; set; }
        public DbSet<Comment> Comments { get; set; }


    }
}
