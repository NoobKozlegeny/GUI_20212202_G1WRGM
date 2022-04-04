using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Data
{
    public class DudeDbContext :DbContext
    {
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
    }
}
