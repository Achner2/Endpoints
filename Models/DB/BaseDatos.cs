using Microsoft.EntityFrameworkCore;
using WebApplication2.Models.Entity;

namespace WebApplication2.Models.DB
{
    public class BaseDatos : DbContext
    {
        public DbSet<User> usuarios { get; set; }
        public DbSet<Dog> dogs { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=pruebanumero1;user=root;password=2004",
                ServerVersion.AutoDetect("server=localhost;database=pruebanumero1;user=root;password=2004"));
        }
    }
}