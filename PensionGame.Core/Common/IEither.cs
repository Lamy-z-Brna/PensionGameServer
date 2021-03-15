using System;

namespace PensionGame.Core.Common
{
    public interface IEither<TA, TB>
    {
        TResult Match<TResult>(Func<TA, TResult> func1, Func<TB, TResult> func2);

        Either<TA, TB> Do(Action<TA> action1, Action<TB> action2);
    }
}
