using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentAPI.Model;

namespace FluentAPI.Data
{
    public class FluentAPIContext : DbContext
    {
        public FluentAPIContext (DbContextOptions<FluentAPIContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(s => s.Email)
                    .IsUnique();
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Title).IsRequired();
            });
        }
        public DbSet<FluentAPI.Model.Student> Student { get; set; } = default!;
        public DbSet<FluentAPI.Model.Course> Course { get; set; } = default!;
    }
}
