using System;

namespace CovidAlert.Models
{
    internal static class Endpoints
    {
        public static readonly Uri TrackerApi = new Uri("http://coronavirus-tracker-api.herokuapp.com/v2/locations", UriKind.Absolute);
    }
}