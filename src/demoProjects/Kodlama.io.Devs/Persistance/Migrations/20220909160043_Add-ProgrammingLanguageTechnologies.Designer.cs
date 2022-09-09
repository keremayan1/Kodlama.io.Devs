﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance.Contexts;

#nullable disable

namespace Persistance.Migrations
{
    [DbContext(typeof(SQLContext))]
    [Migration("20220909160043_Add-ProgrammingLanguageTechnologies")]
    partial class AddProgrammingLanguageTechnologies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.ProgrammingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("ProgrammingLanguages", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Next.js"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ProgrammingLanguageTechnology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProgrammingLanguageId")
                        .HasColumnType("int")
                        .HasColumnName("ProgrammingLanguageId");

                    b.Property<string>("ProgrammingLanguageTechnologyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ProgrammingLanguageTechnologyName");

                    b.HasKey("Id");

                    b.HasIndex("ProgrammingLanguageId");

                    b.ToTable("ProgrammingLanguageTechnologies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProgrammingLanguageId = 3,
                            ProgrammingLanguageTechnologyName = "MVC"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ProgrammingLanguageTechnology", b =>
                {
                    b.HasOne("Domain.Entities.ProgrammingLanguage", "ProgrammingLanguage")
                        .WithMany("ProgrammingLanguageTechnologies")
                        .HasForeignKey("ProgrammingLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgrammingLanguage");
                });

            modelBuilder.Entity("Domain.Entities.ProgrammingLanguage", b =>
                {
                    b.Navigation("ProgrammingLanguageTechnologies");
                });
#pragma warning restore 612, 618
        }
    }
}
