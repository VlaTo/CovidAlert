using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using CovidAlert.Db;
using CovidAlert.Db.Models;
using CovidAlert.Models;
using CovidAlert.Models.Data;
using CovidAlert.Models.Interchange;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;
using CountryInfo = CovidAlert.Models.Interchange.CountryInfo;

namespace CovidAlert.Services
{
    public class CovidDataService : IDataService
    {
        private readonly CovidDbContext context;
        private readonly IDataProvider dataProvider;
        private readonly TaskExecutionManager taskManager;
        readonly List<Item> items;

        public CovidDataService()
            : this(
                DependencyService.Resolve<CovidDbContext>(),
                DependencyService.Resolve<IDataProvider>()
            )
        {
        }

        public CovidDataService(CovidDbContext context, IDataProvider dataProvider)
        {
            this.context = context;
            this.dataProvider = dataProvider;

            taskManager = new TaskExecutionManager(dataProvider);
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<CountryStatistic>> GetStatisticsAsync(bool forceRefresh = false)
        {
            //var statistics = await dataProvider.GetStatisticAsync(CancellationToken.None);

            try
            {
                var list = new List<CountryStatistic>();

                var statistic = await context.Statistics
                    .AsNoTracking()
                    .Include(statistics => statistics.Country)
                    .ThenInclude(country => country.CountryName)
                    .Where(statistics => false == statistics.Country.DoNotShow)
                    .OrderBy(statistics => statistics.Id)
                    .ToArrayAsync();

                foreach (var item in statistic)
                {
                    /*var lastConfirmed = 0UL;
                    var data = await context.Statistics
                        .Where(row => row.CountryCode == item.CountryInfo.Code && row.Province == item.CountryInfo.Province)
                        .FirstOrDefaultAsync(CancellationToken.None);

                    if (data != null)
                    {
                        lastConfirmed = data.Confirmed;

                        if (data.Confirmed != item.Confirmed)
                        {
                            data.Confirmed = item.Confirmed;
                            context.Statistics.Update(data);
                        }
                    }
                    else
                    {
                        lastConfirmed = item.Confirmed;
                        data = new StatisticItem
                        {
                            CountryCode = item.CountryInfo.Code,
                            Province = item.CountryInfo.Province,
                            Confirmed = item.Confirmed
                        };
                        await context.Statistics.AddAsync(data, CancellationToken.None);
                    }

                    await context.SaveChangesAsync(CancellationToken.None);*/

                    var country = new CountryInfo(item.Country.Code, item.Country.Province, item.Country.CountryName.EnglishName);
                    var last = new StatisticInfo(item.Confirmed, item.Deaths, item.Recovered, item.LastUpdated);
                    var latest = new StatisticInfo(0UL, 0UL, 0UL, DateTimeOffset.UtcNow);

                    list.Add(new CountryStatistic(item.Id, country, latest, last));
                }

                return list.AsEnumerable();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }

            return Array.Empty<CountryStatistic>();
        }

        /// <summary>
        /// Class <see cref="TaskExecutionManager" />.
        /// </summary>
        private class TaskExecutionManager
        {
            private readonly IDataProvider provider;
            private Task<IEnumerable<StatisticItem>> task;

            public TaskExecutionManager(IDataProvider provider)
            {
                this.provider = provider;
            }

            public IObservable<StatisticItem> GetStatisticItems()
            {
                if (null == task)
                {
                    task = provider.GetStatisticAsync(CancellationToken.None);
                }

                var observable= Observable.DeferAsync(
                    async cancellationToken =>
                    {
                        var feed = await task;

                        return Observable.Create<StatisticItem>(observer =>
                        {
                            foreach (var statisticItem in feed)
                            {
                                observer.OnNext(statisticItem);
                            }

                            observer.OnCompleted();

                            return Disposable.Create(() => task = null);
                        });
                    }
                );

                return observable;
            }
        }
    }
}