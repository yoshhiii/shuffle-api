using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shuffle.Data.Entities.Mappings
{
    public class RulesetEntityMap : IEntityTypeConfiguration<RulesetEntity>
    {
        public void Configure(EntityTypeBuilder<RulesetEntity> builder)
        {
            builder.ToTable("Ruleset");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).IsRequired();
        }
    }
}
