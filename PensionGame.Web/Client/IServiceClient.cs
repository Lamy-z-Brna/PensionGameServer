using System;
using System.Threading.Tasks;
using PensionGame.Web.Data.Entities;
using Newtonsoft.Json;
using RestSharp;

namespace PensionGame.Web.Client
{
    public interface IServiceClient
    {
        Task<T> PostRequest<T>(string requestAddress, object? requestContent = null);
    }
}
