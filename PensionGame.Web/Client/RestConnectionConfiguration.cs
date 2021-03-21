using System;

namespace PensionGame.Web.Client
{
    public class RestConnectionConfiguration : IRestConnectionConfiguration
    {
        private Uri _restApiUri => new("https://pensiongameapi.azurewebsites.net/api/");
        public Uri RestApiUri => _restApiUri;
    }
}
