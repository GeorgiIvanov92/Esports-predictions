using System;
using System.Collections.Generic;
using System.Linq;
using EsportStats.Models;
using LolData.Data;
using LoLData.Tracking;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LoLData
{
    public class GetDataFunction
    {
        private readonly TrackerDBContext _trackerDb;
        public GetDataFunction(TrackerDBContext context) 
        {
            _trackerDb = context;
        }
        [FunctionName("GetDataFunction")]
        public void Run([TimerTrigger("0 0 */6 * * *")]TimerInfo myTimer, ILogger log)
        {
            try
            {
                var gol = new GamesOfLegends();
                var teams = gol.GetTeams();
                AddOrUpdateTeams(teams, _trackerDb);
                _trackerDb.SaveChanges();
                var players = gol.GetPlayers(_trackerDb.Team.ToList());
                AddOrUpdatePlayers(players, _trackerDb);
                _trackerDb.SaveChanges();
                AddOrUpdateChampionStats(gol.GetChampionStats(), _trackerDb);
                _trackerDb.SaveChanges();

                log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            }
            catch(Exception ex) 
            {
                log.LogError(ex.Message, ex);
            }
        }

        private void AddOrUpdateTeams(List<Team> newTeams, TrackerDBContext dBContext)
        {
            foreach(var team in newTeams)
            {
                var trackedTeam = dBContext.Team.FirstOrDefault(t => t.Name == team.Name && t.SportId == team.SportId);
                if (trackedTeam != null)
                {
                    var trackedTeamId = trackedTeam.Id;
                    trackedTeam = team;
                    trackedTeam.Id = trackedTeamId;
                }
                else
                {
                    dBContext.Team.Add(team);
                }
            }
        }

        private void AddOrUpdatePlayers(List<Player> players, TrackerDBContext dBContext)
        {
            foreach(var player in players)
            {
                try
                {
                    var dbPlayer = dBContext.Player.FirstOrDefault(p => p.Nickname == player.Nickname && p.SportId == player.SportId);
                    if (dbPlayer != null)
                    {
                        var id = dbPlayer.PlayerId;
                        var teamId = dbPlayer.TeamId;
                        dbPlayer = player;
                        dbPlayer.PlayerId = id;
                        dbPlayer.TeamId = teamId;
                    }
                    else
                    {
                        dBContext.Player.Add(player);
                    }
                }catch(Exception ex)
                {
                    //log
                }
            }
        }

        private void AddOrUpdateChampionStats(Dictionary<string,List<ChampionStat>> stats,TrackerDBContext dbContext)
        {
            foreach(var stat in stats)
            {
                foreach (var innerStat in stat.Value)
                {
                    try
                    {
                        var dbStat = dbContext.ChampionStat.FirstOrDefault(cs => cs.Player.Nickname == stat.Key && cs.ChampionName == innerStat.ChampionName);
                        if (dbStat != null)
                        {
                            var statId = dbStat.ChampionStatId;
                            var playerId = dbStat.PlayerId;
                            dbStat = innerStat;
                            dbStat.ChampionStatId = statId;
                            dbStat.PlayerId = playerId;
                        }
                        else
                        {
                            dbContext.ChampionStat.Add(innerStat);
                        }
                    }catch(Exception ex)
                    {
                        //log
                    }
                }
            }
        }
    }
}
