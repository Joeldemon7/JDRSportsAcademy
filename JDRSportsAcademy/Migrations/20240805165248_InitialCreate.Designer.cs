﻿// <auto-generated />
using System;
using JDRSportsAcademy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JDRSportsAcademy.Migrations
{
    [DbContext(typeof(SportContext))]
    [Migration("20240805165248_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JDRSportsAcademy.Models.Fixture", b =>
                {
                    b.Property<int>("FixtureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FixtureID"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("FixtureName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SportID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("FixtureID");

                    b.HasIndex("SportID");

                    b.HasIndex("StudentID");

                    b.ToTable("Fixture", (string)null);
                });

            modelBuilder.Entity("JDRSportsAcademy.Models.Sport", b =>
                {
                    b.Property<int>("SportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SportID"), 1L, 1);

                    b.Property<string>("SportName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SportID");

                    b.ToTable("Sport", (string)null);
                });

            modelBuilder.Entity("JDRSportsAcademy.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("JDRSportsAcademy.Models.Fixture", b =>
                {
                    b.HasOne("JDRSportsAcademy.Models.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JDRSportsAcademy.Models.Student", "Student")
                        .WithMany("Fixtures")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sport");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("JDRSportsAcademy.Models.Student", b =>
                {
                    b.Navigation("Fixtures");
                });
#pragma warning restore 612, 618
        }
    }
}
