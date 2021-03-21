using System;

namespace PensionGame.Web.Client
{
    public interface IRestConnectionConfiguration
    {
        Uri RestApiUri { get; }
    }
}
