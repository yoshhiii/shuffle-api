using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shuffle.Data.Entities;
using Shuffle.Data.Entities.Mappings;

namespace Shuffle.Data
{
    public class ShuffleDbContext : DbContext
    {
        public ShuffleDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<MatchEntity> Matches { get; set; }
        public virtual DbSet<RulesetEntity> Rulesets { get; set; }
        public virtual DbSet<TeamEntity> Teams { get; set; }
        public virtual DbSet<TeamRecordEntity> TeamRecords { get; set; }
        public virtual DbSet<UserTeamEntity> UserTeams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityMap());
            modelBuilder.ApplyConfiguration(new MatchEntityMap());
            modelBuilder.ApplyConfiguration(new RulesetEntityMap());
            modelBuilder.ApplyConfiguration(new TeamEntityMap());
            modelBuilder.ApplyConfiguration(new TeamRecordEntityMap());
            modelBuilder.ApplyConfiguration(new UserTeamEntityMap());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}