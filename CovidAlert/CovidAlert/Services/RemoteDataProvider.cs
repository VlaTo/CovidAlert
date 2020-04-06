using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CovidAlert.Models;
using CovidAlert.Models.Data;
using CountryInfo = CovidAlert.Models.Data.CountryInfo;

namespace CovidAlert.Services
{
    internal class RemoteDataProvider : IDataProvider
    {
        private readonly HttpClient httpClient;

        public RemoteDataProvider()
        {
            httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Models.Data.StatisticItem>> GetStatisticAsync(CancellationToken cancellationToken)
        {
            try
            {
                using (var response = await httpClient.GetAsync(Endpoints.TrackerApi, cancellationToken))
                {
                    var message = response.EnsureSuccessStatusCode();
                    var stream = await message.Content.ReadAsStreamAsync();
                    var feed = await JsonSerializer.DeserializeAsync<Feed>(stream, cancellationToken: cancellationToken);

                    var list = new List<Models.Data.StatisticItem>();

                    foreach (var location in feed.Locations)
                    {
                        var countryInfo = new CountryInfo(location.CountryCode, location.Country, location.Province);
                        list.Add(
                            new Models.Data.StatisticItem(location.Id, countryInfo, location.Latest.Confirmed)
                        );
                    }

                    return list.AsEnumerable();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return Array.Empty<Models.Data.StatisticItem>();
        }
    }
}