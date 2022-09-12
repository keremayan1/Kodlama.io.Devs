using Core.Security.Entities;
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
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Github> Githubs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }

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
            DeveloperEntity(modelBuilder);
            GithubEntity(modelBuilder);
            UserEntity(modelBuilder);
            UserOperationClaimEntity(modelBuilder);
            OperationClaimEntity(modelBuilder);

        }

        private static void GithubEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Github>(a =>
            {
                a.ToTable("Githubs").HasKey(x => x.Id);
                a.Property(x => x.Id).HasColumnName("Id");
                a.Property(x => x.DeveloperId).HasColumnName("DeveloperId");
                a.Property(x => x.GithubAddressName).HasColumnName("GithubAddresses");
                a.HasOne(x => x.Developer);
            });
        }

        private static void OperationClaimEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(p => p.Id);
                a.Property(x => x.Id).HasColumnName("Id");
                a.Property(x => x.Name).HasColumnName("Name");
            });
        }

        private static void UserOperationClaimEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaims").HasKey(p => p.Id);
                a.Property(x => x.UserId).HasColumnName("UserId");
                a.Property(x => x.OperationClaimId).HasColumnName("OperationClaimId");
                a.HasOne(x => x.User);
                a.HasOne(x => x.OperationClaim);
            });
        }

        private static void DeveloperEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>(a =>
            {
                a.ToTable("Developers");
            });
        }

        private static void UserEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("User").HasKey(p => p.Id);
                a.Property(x => x.Id).HasColumnName("Id");
                a.Property(x => x.FirstName).HasColumnName("FirstName");
                a.Property(x => x.LastName).HasColumnName("LastName");
                a.Property(x => x.Email).HasColumnName("Email");
                a.Property(x => x.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(x => x.PasswordHash).HasColumnName("PasswordHash");
                a.Property(x => x.Status).HasColumnName("Status").HasDefaultValue(true);
                a.Property(x => x.AuthenticatorType).HasColumnName("AuthenticatorType");
                a.HasMany(p => p.RefreshTokens);
                a.HasMany(p => p.UserOperationClaims);
            });
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
