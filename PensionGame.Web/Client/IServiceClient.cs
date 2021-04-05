using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PensionGame.Web.Client
{
    public interface IServiceClient
    {
        Task<T> Request<T>(string requestAddress, Method method, object? requestBody = null,
            Dictionary<string, object>? parameters = null);

        Task<bool> Request(string requestAddress, Method method, object? requestBody = null,
            Dictionary<string, object>? parameters = null);
    }
}
