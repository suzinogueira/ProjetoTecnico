using Microsoft.EntityFrameworkCore;
using TesteVaiVoa.Models;

namespace TesteVaiVoa.Repositories{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){}

            public DbSet<CartaoVirtual> CartaoVirtual {get; set; }

            public DbSet<Usuario> Usuarios {get; set; }
        
    }
    
}