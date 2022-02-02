using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistence
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration):base(dbContextOptions)
        {
            Configuration = configuration;
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Fuel> Fuels { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured) { 
            //    base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("RentACarConnectionString")));
            //}
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Brand>(b =>
            {
                b.ToTable("Brands").HasKey(k => k.Id);
                b.Property(p=>p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.HasMany(p=>p.Models);
            });

            modelBuilder.Entity<Color>(b =>
            {
                b.ToTable("Colors").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.HasMany(p => p.Cars);
            });

            modelBuilder.Entity<Fuel>(b =>
            {
                b.ToTable("Fuels").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.HasMany(p => p.Models);
            });

            modelBuilder.Entity<Transmission>(b =>
            {
                b.ToTable("Transmissions").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.HasMany(p => p.Models);
            });

            modelBuilder.Entity<Car>(b =>
            {
                b.ToTable("Cars").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.ModelYear).HasColumnName("ModelYear");
                b.Property(p => p.Plate).HasColumnName("Plate");
                b.Property(p => p.ColorId).HasColumnName("ColorId");
                b.Property(p => p.ModelId).HasColumnName("ModelId");
                b.Property(p => p.CarState).HasColumnName("State");
                b.HasOne(p => p.Color);
                b.HasOne(p => p.Model);
            });
        }
    }
}