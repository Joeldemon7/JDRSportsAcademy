using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JDRSportsAcademy.Models;

namespace JDRSportsAcademy.Data
{
    public class SportContext : DbContext
    {
        public SportContext (DbContextOptions<SportContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sport>().ToTable("Sport");
            modelBuilder.Entity<Fixture>().ToTable("Fixture");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Coach>().ToTable("Coach");
        }
    }
}
