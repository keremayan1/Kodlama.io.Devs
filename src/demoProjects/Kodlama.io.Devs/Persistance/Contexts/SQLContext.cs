using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Contexts
{
    public class SQLContext : DbContext
    {
        public IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies { get; set; }

        public SQLContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString")));
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ProgrammingLanguageEntity(modelBuilder);
            ProgrammingLanguageTechnologyEntity(modelBuilder);
        }

        private static void ProgrammingLanguageEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(p => p.Id);
                a.Property(x => x.Id).HasColumnName("Id");
                a.Property(x => x.Name).HasColumnName("Name");
                a.HasMany(x => x.ProgrammingLanguageTechnologies);
            });

            ProgrammingLanguage[] programmingLanguagesSeedData = { new(1, "Next.js") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguagesSeedData);
        }

        private static void ProgrammingLanguageTechnologyEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguageTechnology>(a =>
            {
                a.ToTable("ProgrammingLanguageTechnologies").HasKey(p => p.Id);
                a.Property(x => x.Id).HasColumnName("Id");
                a.Property(x => x.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.Property(x => x.ProgrammingLanguageTechnologyName).HasColumnName("ProgrammingLanguageTechnologyName");
                a.HasOne(x => x.ProgrammingLanguage);
            });
            ProgrammingLanguageTechnology[] programmingLanguageTechnologiesSeedData = { new(1, 3, "MVC") };
            modelBuilder.Entity<ProgrammingLanguageTechnology>().HasData(programmingLanguageTechnologiesSeedData);
        }
    }
}
