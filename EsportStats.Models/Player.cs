﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EsportStats.Models
{
    public class Player
    {  
        [Key]
        public int? PlayerId { get; set; }
        public string Nickname { get; set; }
        public int SportId { get; set; }
        [ForeignKey("TeamId")]
        public Team Team { get; set; }
        public int? TeamId { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public float KDA { get; set; }
        public float CSPerMinute { get; set; }
        public float GoldPerMinute { get; set; }
        public float GoldPercent { get; set; }
        public float KillParticipation { get; set; }
        public float DamagePerMinute { get; set; }
        public float DamagePercent { get; set; }
        public float KillsAndAssistsPerMinute { get; set; }
        public int SoloKills { get; set; }
        public int Pentakills { get; set; }
        public float VisionScorePerMinute { get; set; }
        public float WardPerMinute { get; set; }
        public float VisionWardsPerMinute { get; set; }
        public float WardsClearedPerMinute { get; set; }
        public float AheadInCSAt15Percent { get; set; }
        public float CSDifferenceAt15 { get; set; }
        public float GoldDifferenceAt15 { get; set; }
        public float XPDifferenceAt15 { get; set; }
        public float FirstBloodParticipationPercent { get; set; }
        public float FirstBloodVictimPercent { get; set; }

    }
}
