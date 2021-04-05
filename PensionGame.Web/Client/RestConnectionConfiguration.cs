using System;

namespace PensionGame.Web.Client
{
    public class RestConnectionConfiguration : IRestConnectionConfiguration
    {
        public Uri RestApiUri => GetUri();

        private static Uri GetUri()
        {
#if DEBUG
            return new("https://localhost:44386/api/");
#else
            return new("https://pensiongameapi.azurewebsites.net/api/");
#endif
        }
    }
}
