using System;

namespace PensionGame.Core.Common
{
    public sealed class Either<TA, TB> : IEither<TA, TB>
    {
        private readonly int _item;
        private readonly TA? _a;
        private readonly TB? _b;

        public Either(TA a)
        {
            _a = a;
            _item = 1;
        }

        public Either(TB b)
        {
            _b = b;
            _item = 2;
        }

        public Either<TA, TB> Do(Action<TA> action1, Action<TB> action2)
        {
            if (_item == 1 && _a != null)
            {
                action1(_a);
                return this;
            }
            if (_item == 2 && _b != null)
            {
                action2(_b);
                return this;
            }

            throw new InvalidOperationException();
        }

        public TResult Match<TResult>(Func<TA, TResult> func1, Func<TB, TResult> func2)
        {
            if (_item == 1 && _a != null) 
                return func1(_a);
            if (_item == 2 && _b != null)
                return func2(_b);

            throw new InvalidOperationException();
        }
    }
}
