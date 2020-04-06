using System.Threading.Tasks;

namespace CovidAlert.Core
{
    public interface IInitializeAsync
    {
        Task InitializeAsync();
    }
}