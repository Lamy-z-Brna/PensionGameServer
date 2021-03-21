using Castle.Windsor;
using PensionGame.Web.Client;

namespace PensionGame.Web.Services
{
    public abstract class ServicesBase
    {
        protected ServiceClient Client { get; }

        protected ServicesBase()
        {
            Client = ServiceClient.Instance; //TODO VB take care of this
        }
    }
}
