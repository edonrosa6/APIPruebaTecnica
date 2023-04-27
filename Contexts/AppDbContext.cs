
using APIPrueba.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIPrueba.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<SendMail> SendMail { get; set; }
        public DbSet<CiudadYEstado> CiudadYEstado { get; set; }    
    }
}
