using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectsDbAPI.Models
{
    public class ProjectContext : DbContext
    {
        private string _connString = "Server=DESKTOP-3P9I28U\\MATEUSZSQL;Database=ProjectsDb;Trusted_Connection=True;";

        public DbSet<Project> Projects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designer> Designers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasOne(x => x.Department)
                .WithOne(x => x.Project)
                .HasForeignKey<Department>(x => x.ProjectId);

            modelBuilder.Entity<Project>()
                .HasMany(x => x.Designers)
                .WithOne(x => x.Project);

            modelBuilder.Entity<Project>()
                .Property(x => x.IsFinished)
                .HasDefaultValue(false);

            modelBuilder.Entity<Project>()
                .Property(x => x.DateAdded)
                .HasDefaultValueSql("getdate()");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
        }
    }
}
