﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using EsportStats.Models;
using Microsoft.Extensions.Configuration;

namespace LolData.Data
{
    public class TrackerDBContext : DbContext
    {
        public TrackerDBContext()
        {

        }
        public TrackerDBContext(DbContextOptions<TrackerDBContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Prelive> Prelive { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<ChampionStat> ChampionStat { get; set; }
    }
}
