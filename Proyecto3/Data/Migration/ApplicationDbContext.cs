using Microsoft.EntityFrameworkCore;
using Proyecto3.Models;

namespace Proyecto3.Data.Migration
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Contactos> Contactos { get; set; }
        public DbSet<Correos> Correos { get; set; }
        public DbSet<Direcciones> Direcciones { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Municipios> Municipios { get; set; }
        public DbSet<Seguimientos> Seguimientos { get; set; }
    }
}
