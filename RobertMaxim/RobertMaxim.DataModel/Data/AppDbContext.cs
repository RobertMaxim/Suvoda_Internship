using Microsoft.EntityFrameworkCore;
using RobertMaxim.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertMaxim.DataModel
{
    public class AppDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Depot> Depots { get; set; }
        public DbSet<DrugType> DrugTypes { get; set; }
        public DbSet<DrugUnit> DrugUnits { get; set; }
        public DbSet<Site> Sites { get; set; }

        public AppDbContext():base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InternshipDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasOne(c => c.Supplier)
                .WithMany(d => d.CountriesSupplied)
                .HasForeignKey(c => c.SupplierId)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
