using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Drawing;
using System.Text.Json;

namespace Data
{
    public class DudeDbContext :DbContext
    {
        public virtual DbSet<Map> MapTable { get; set; }
        public virtual DbSet<Character> CharacterTable { get; set; }
        public virtual DbSet<Item> ItemTable { get; set; }
        public virtual DbSet<WorldBuildingElement> WorldBuildingElementTable { get; set; }
        public DudeDbContext()
        {
            Database.EnsureCreated();
        }
        public DudeDbContext(DbContextOptions<DudeDbContext> builder) : base(builder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            if (!optionsBuilder.IsConfigured)
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // so DB almost ready but have some semantical issue with relations
            // to fix those models need changes, finish DB once models ready
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DudeDbContext).Assembly);
        }
    }
}
