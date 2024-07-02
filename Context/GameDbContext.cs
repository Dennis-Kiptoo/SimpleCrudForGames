using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CarSales.Entity;
using Microsoft.EntityFrameworkCore;
namespace CarSales.Context

{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
            .ToTable("Game")
            .Property(g=>g.Price)
            .HasColumnType("decimal(18,2)")
            .HasPrecision(18, 4);;
            
        }
    }
}