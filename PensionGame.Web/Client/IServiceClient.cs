using PensionGame.Api.Domain.Validation;
using PensionGame.Common.Functional;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PensionGame.Web.Client
{
    public interface IServiceClient
    {
        Task<ValidationResultModel?> Post(string requestAddress, object? requestBody = null,
            Dictionary<string, object>? parameters = null);

        Task<Union<T, ValidationResultModel>> Post<T>(string requestAddress, object? requestBody = null,
            Dictionary<string, object>? parameters = null);        

        Task<ValidationResultModel> Put(string requestAddress, object? requestBody = null,
            Dictionary<string, object>? parameters = null);

        Task<T?> Put<T>(string requestAddress, object? requestBody = null,
            Dictionary<string, object>? parameters = null);

        Task<T?> Get<T>(string requestAddress, Dictionary<string, object>? parameters = null);
    }
}
