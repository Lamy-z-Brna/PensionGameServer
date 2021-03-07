namespace PensionGame.Api.Handlers.Common
{
    public interface ICommand
    {
    }

    public interface ICommand<out TResult>
    {
    }
}
