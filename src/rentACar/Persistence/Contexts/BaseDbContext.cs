using Domain.Entities;
using Domain.Enums;
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

            modelBuilder.Entity<Model>(b =>
            {
                b.ToTable("Models").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
                b.Property(p => p.BrandId).HasColumnName("BrandId");
                b.Property(p => p.TransmissionId).HasColumnName("TransmissionId");
                b.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
                b.Property(p => p.FuelId).HasColumnName("FuelId");
                b.HasOne(p => p.Transmission);
                b.HasOne(p => p.Fuel);
                b.HasOne(p => p.Brand);
                b.HasMany(p => p.Cars);
            });

            var brand1 = new Brand(1,"BMW");
            var brand2 = new Brand(2, "Mercedes");
            modelBuilder.Entity<Brand>().HasData(brand1,brand2);

            var color1 = new Color(1, "Red");
            var color2 = new Color(2, "Blue");
            modelBuilder.Entity<Color>().HasData(color1, color2);

            var transmission1 = new Transmission(1, "Manuel");
            var transmission2 = new Transmission(2, "Automatic");
            modelBuilder.Entity<Transmission>().HasData(transmission1, transmission2);

            var fuel1 = new Fuel(1, "Diesel");
            var fuel2 = new Fuel(2, "Electric");
            modelBuilder.Entity<Fuel>().HasData(fuel1, fuel2);

            var model1 = new Model(1,"418i",1000,2,1,1,"");
            var model2 = new Model(2, "CLA 180D", 600, 2, 1, 2, "");
            modelBuilder.Entity<Model>().HasData(model1, model2);

            modelBuilder.Entity<Car>().HasData(new Car(1,1,1,"06ABC06",2018,CarState.Available));
            modelBuilder.Entity<Car>().HasData(new Car(2, 2, 2, "34ABC34", 2018, CarState.Available));
        }
    }
}