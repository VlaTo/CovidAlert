using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CovidAlert.Models.Data;

namespace CovidAlert.Services
{
    public interface IDataProvider
    {
        Task<IEnumerable<StatisticItem>> GetStatisticAsync(CancellationToken cancellationToken);
    }
}