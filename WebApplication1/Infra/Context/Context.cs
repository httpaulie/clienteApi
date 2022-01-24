using ClienteAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Infra.Context
{
    public class Context : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClienteAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(entity => entity.HasKey(e => new { e.Id }));
            modelBuilder.Entity<Cliente>()
                .HasOne(a => a.Endereco)
                .WithMany(t => t.Clientes)
                .HasForeignKey(a => a.EnderecoId);

            modelBuilder.Entity<Endereco>(entity => entity.HasKey(e => new { e.Id }));
            modelBuilder.Entity<Endereco>()
                .HasMany(t => t.Clientes);
        }
    }
}
