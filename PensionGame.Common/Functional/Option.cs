namespace PensionGame.Common.Functional
{
    public class Option<T> : Union<Some<T>, None>
    {
        public Option(Some<T> some) : base(some)
        {
        }

        public Option(T value) : base(Of.Some(value))
        {
        }

        public Option() : base(Of.None)
        {
        }

        public static implicit operator Option<T>(Some<T> some) => new(some);

        public static implicit operator Option<T>(T value) => new(value);

        public static implicit operator Option<T>(None _) => new();
    }

    public class Some<T>
    {
        public T Value { get; }

        public Some(T value)
        {
            Value = value;
        }

        public override bool Equals(object? obj)
        {
            return obj is Some<T> some && Equals(some);
        }

        public bool Equals(Some<T> some)
        {
            return some.Value != null && some.Value.Equals(Value);
        }

        public override int GetHashCode()
        {
            return Value?.GetHashCode() ?? 0;
        }
    }

    public class None
    {
        public None()
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is None;
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }

    public static class Of
    {
        public static Some<T> Some<T>(T value) => new(value);

        public static None None => new();
    }
}
