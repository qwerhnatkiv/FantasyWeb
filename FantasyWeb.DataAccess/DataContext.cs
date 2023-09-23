using FantasyWeb.DataAccess.Entities;
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

        public virtual DbSet<FGame> FGameOdds { get; set; }

        public virtual DbSet<FTeamNST> FTeamsNST { get; set; }

        public virtual DbSet<FPlayerNST> FPlayersNST { get; set; }

        public virtual DbSet<DPlayer> DPlayers { get; set; }

        public virtual DbSet<DMPlayerSeasonPreds> DMPlayerSeasonPreds { get; set; }

        public virtual DbSet<DPosition> DPositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DGame>()
                .HasMany(e => e.FGameOdds)
                .WithOne(e => e.DGame)
                .HasForeignKey(e => e.GameId)
                .IsRequired();

            modelBuilder.Entity<DGame>()
                .HasMany(e => e.FTeamsNST)
                .WithOne(e => e.DGame)
                .HasForeignKey(e => e.GameID)
                .IsRequired();

            modelBuilder.Entity<DTeam>()
                .HasMany(e => e.Players)
                .WithOne(e => e.DTeam)
                .HasForeignKey(e => e.TeamID)
                .IsRequired();
        }
    }
}