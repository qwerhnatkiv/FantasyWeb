﻿using FantasyWeb.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace FantasyWeb.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<DTeam> DTeams { get; set; }

        public virtual DbSet<DGame> DGames { get; set; }

        public virtual DbSet<FGameOdd> FGameOdds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DGame>()
                .HasMany(e => e.FGameOdds)
                .WithOne(e => e.DGame)
                .HasForeignKey(e => e.GameId)
                .IsRequired();
        }
    }
}