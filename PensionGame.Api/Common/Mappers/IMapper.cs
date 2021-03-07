namespace PensionGame.Api.Common.Mappers
{
    public interface IMapper<in TIn, out TOut>
    {
        TOut Map(TIn @in);
    }
}
