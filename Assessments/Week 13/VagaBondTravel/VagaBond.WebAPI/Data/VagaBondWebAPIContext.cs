using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VagaBond.WebAPI.Model;

namespace VagaBond.WebAPI.Data
{
    public class VagaBondWebAPIContext : DbContext
    {
        public VagaBondWebAPIContext(DbContextOptions<VagaBondWebAPIContext> options)
            : base(options)
        {
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destination>(entity =>
            {
                entity.HasKey(d => d.Id);
                entity.Property(d => d.CityName).IsRequired();
                entity.Property(d => d.Country).IsRequired();
                entity.Property(d => d.Description).HasMaxLength(200);
                entity.Property(d => d.Rating).HasDefaultValue(3);
            });
        }

        public DbSet<VagaBond.WebAPI.Model.Destination> Destination { get; set; } = default!;
    }
}
