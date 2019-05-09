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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityMap());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}