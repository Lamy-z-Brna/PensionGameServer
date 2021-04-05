using PensionGame.Api.Domain.Validation;

namespace PensionGame.Api.Exceptions.Session
{
    public sealed class SessionDoesNotExistException : ValidationException
    {
        public SessionDoesNotExistException() : base("Selected session does not exist")
        {
        }
    }
}
