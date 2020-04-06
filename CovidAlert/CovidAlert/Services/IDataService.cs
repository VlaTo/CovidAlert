using System.Collections.Generic;
using System.Threading.Tasks;
using CovidAlert.Models;
using CovidAlert.Models.Interchange;

namespace CovidAlert.Services
{
    public interface IDataService
    {
        Task<IEnumerable<CountryStatistic>> GetStatisticsAsync(bool forceRefresh = false);
    }
}
