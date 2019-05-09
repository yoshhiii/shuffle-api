﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shuffle.Data.Entities.Mappings
{
    public class MatchEntityMap : IEntityTypeConfiguration<MatchEntity>
    {
        public void Configure(EntityTypeBuilder<MatchEntity> builder)
        {
            builder.ToTable("Match");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Challenger)
                .WithMany(x => x.ChallengerMatches)
                .HasForeignKey(x => x.ChallengerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Opposition)
                .WithMany(x => x.OppositionMatches)
                .HasForeignKey(x => x.OppositionId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Ruleset)
                .WithMany(x => x.Matches)
                .HasForeignKey(x => x.RulesetId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.MatchDate).IsRequired();
        }
    }
}
