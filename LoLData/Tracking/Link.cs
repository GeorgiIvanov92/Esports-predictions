using System;

namespace LoLData.Tracking
{
    public class Link
    {
        public SportEnum Sport;
        public Uri Uri;
        public string AdditionalData;
        public string LeagueName;
        public string HomeTeamName;
        public int MapNumber;
        public int BestOf;
        public int ScoreHome;
        public int ScoreAway;

        public enum SportEnum
        {
            Undefined = 0,
            LeagueOfLegends = 1,
            CounterStrike = 2,
            Dota2 = 3,
        }

        public Link(SportEnum sport, Uri uri, string additionaldata = null)
        {
            Sport = sport;
            Uri = uri;
            AdditionalData = additionaldata;
        }
        public Link(SportEnum sport, Uri uri, string leagueName, string additionaldata = null)
        {
            Sport = sport;
            Uri = uri;
            AdditionalData = additionaldata;
            LeagueName = leagueName;
        }
        public Link(SportEnum sport, Uri uri, string leagueName, int mapNumber, string additionaldata = null)
        {
            Sport = sport;
            Uri = uri;
            AdditionalData = additionaldata;
            LeagueName = leagueName;
            MapNumber = mapNumber;
        }
        public Link(SportEnum sport, Uri uri, string leagueName, int mapNumber,int bestOf, string additionaldata = null)
        {
            Sport = sport;
            Uri = uri;
            AdditionalData = additionaldata;
            LeagueName = leagueName;
            MapNumber = mapNumber;
            BestOf = bestOf;
        }
        public Link(SportEnum sport, Uri uri, string leagueName, int mapNumber, int bestOf,int scoreHome, int scoreAway, string additionaldata = null)
        {
            Sport = sport;
            Uri = uri;
            AdditionalData = additionaldata;
            LeagueName = leagueName;
            MapNumber = mapNumber;
            BestOf = bestOf;
            ScoreHome = scoreHome;
            ScoreAway = scoreAway;
        }
    }
}
