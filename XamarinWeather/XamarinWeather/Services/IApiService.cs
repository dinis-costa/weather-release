using System.Threading.Tasks;
using XamarinWeather.Models;

namespace XamarinWeather.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string url);
        Task<Response> GetObjectAsync<T>(string url);
    }
}
