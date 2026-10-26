using FootyCore.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.DataAccessLayer.Concrete
{
    public class FootyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=FootyCoreDb;Trusted_Connection=True; TrustServerCertificate=True;");
        }

        public DbSet<Team> Teams  { get; set; }
        public DbSet<Season> Seasons  { get; set; }
        public DbSet<League> Leagues  { get; set; }
        public DbSet<Stadium> Stadium { get; set; }
        public DbSet<MatchStatistic> MatchStatistics  { get; set; }
        public DbSet<MatchDetail> MatchDetails  { get; set; }
        public DbSet<MatchStatus> MatchStatuses  { get; set; }
        public DbSet<Match> Matches  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Stadium)
                .WithMany()
                .HasForeignKey(m => m.StadiumId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.MatchStatistic)
                .WithOne(s => s.Match)
                .HasForeignKey<MatchStatistic>(s => s.MatchId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MatchDetail>()
                .HasOne(d => d.Team)
                .WithMany()
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
