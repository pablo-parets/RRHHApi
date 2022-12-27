using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RRHHApi.Entities;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace RRHHApi.Helpers
{
    public class DataContext:DbContext
    {

        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("RRHHDatabase"));
        }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Empleo> Empleos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Candidato>()
            .HasMany(ur => ur.Empleos)
            .WithOne()
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasForeignKey("CandidatoEmail"); 

            modelBuilder.Entity<Candidato>()
            .Navigation(b => b.Empleos)
            .UsePropertyAccessMode(PropertyAccessMode.Property);
        }

    }
}


