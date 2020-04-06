using System;

namespace CovidAlert.Models.Interchange
{
    public sealed class StatisticInfo
    {
        public ulong Confirmed
        {
            get;
        }

        public ulong Deaths
        {
            get;
        }

        public ulong Recovered
        {
            get;
        }

        public DateTimeOffset LastUpdated
        {
            get;
        }

        public StatisticInfo(ulong confirmed, ulong deaths, ulong recovered, DateTimeOffset lastUpdated)
        {
            Confirmed = confirmed;
            Deaths = deaths;
            Recovered = recovered;
            LastUpdated = lastUpdated;
        }
    }
}