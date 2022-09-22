using DemoApplication.Interface;
using DemoApplication.Models;
using DemoApplication.Repo;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext>options):base(options)
        {

        }
        
        public DbSet<Product> Products { get; set; }    
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<LoginMatch> LoginMatches { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
