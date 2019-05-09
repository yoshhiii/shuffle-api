using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shuffle.Data.Entities.Mappings
{
    class TeamRecordEntityMap : IEntityTypeConfiguration<TeamRecordEntity>
    {
        public void Configure(EntityTypeBuilder<TeamRecordEntity> builder)
        {
            builder.ToTable("TeamRecord");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Elo).IsRequired();
            builder.Property(x => x.Wins).IsRequired();
            builder.Property(x => x.Losses).IsRequired();

            builder.HasOne(x => x.Ruleset)
                .WithMany(x => x.TeamRecords)
                .HasForeignKey(x => x.RulesetId);

            builder.HasOne(x => x.Team)
                .WithMany(x => x.TeamRecords)
                .HasForeignKey(x => x.TeamId);
        }
    }
}
