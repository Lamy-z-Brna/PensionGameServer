using System;

namespace PensionGame.Web.Client
{
    public record RestConnectionConfiguration(Uri RestApiUri) : IRestConnectionConfiguration
    {
    }
}
