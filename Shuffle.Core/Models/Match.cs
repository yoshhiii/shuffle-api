﻿
using System;

namespace Shuffle.Core.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int ChallengerId { get; set; }
        public int OppositionId { get; set; }
        public int TeamScore1 { get; set; }
        public int TeamScore2 { get; set; }
        public DateTime MatchDate { get; set; }
        public int RulesetId { get; set; }
    }
}