using PensionGame.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Core.Validation.Common
{
    public sealed class ValidationResult<TObj> : IEither<TObj, ValidationError>
    {
        private readonly IEither<TObj, ValidationError> _either;

        public ValidationResult(TObj obj)
        {
            _either = new Either<TObj, ValidationError>(obj);
        }

        public ValidationResult(ValidationError error)
        {
            _either = new Either<TObj, ValidationError>(error);
        }

        private ValidationResult(Either<TObj, ValidationError> either)
        {
            _either = either;
        }

        public Either<TObj, ValidationError> Do(Action<TObj> action1, Action<ValidationError> action2)
        {
            return _either.Do(action1, action2);
        }

        public TResult Match<TResult>(Func<TObj, TResult> func1, Func<ValidationError, TResult> func2)
        {
            return _either.Match(func1, func2);
        }

        public ValidationResult<TObj> OnValid<TResult>(Action<TObj> action) => new(_either.Do(action, (error) => { }));
    }
}
