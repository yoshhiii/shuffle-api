using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shuffle.Data.Entities.Mappings
{
    public class UserTeamEntityMap : IEntityTypeConfiguration<UserTeamEntity>
    {
        public void Configure(EntityTypeBuilder<UserTeamEntity> builder)
        {
            builder.HasKey(bc => new { bc.UserId, bc.TeamId });
            builder.HasOne(bc => bc.User)
                .WithMany(b => b.UserTeams)
                .HasForeignKey(bc => bc.TeamId);
            builder.HasOne(bc => bc.Team)
                .WithMany(c => c.UserTeams)
                .HasForeignKey(bc => bc.UserId);
        }
    }
}
