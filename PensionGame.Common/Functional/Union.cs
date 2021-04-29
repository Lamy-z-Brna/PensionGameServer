using System;

namespace PensionGame.Common.Functional
{
    public class Union<TA, TB>
    {
        protected readonly int _item;
        protected readonly TA? _a;
        protected readonly TB? _b;

        public Union(TA a)
        {
            _a = a;
            _item = 1;
        }

        public Union(TB b)
        {
            _b = b;
            _item = 2;
        }

        public T Match<T>(Func<TA, T> funcA, Func<TB, T> funcB)
        {
            return _item switch
            {
                1 => funcA(_a!),
                2 => funcB(_b!),
                _ => throw new InvalidOperationException()
            };
        }

        public void Do(Action<TA> actionA, Action<TB> actionB)
        {
            switch (_item)
            {
                case 1:
                    actionA(_a!);
                    break;
                case 2:
                    actionB(_b!);
                    break;
            };
        }

        public static implicit operator Union<TA, TB>(TA a)
        {
            return new Union<TA, TB>(a);
        }

        public static implicit operator Union<TA, TB>(TB b)
        {
            return new Union<TA, TB>(b);
        }

        public void Deconstruct(out TA? a, out TB? b)
        {
            switch (_item)
            {
                case 1:
                    a = _a;
                    b = default;
                    break;
                case 2:
                    a = default;
                    b = _b;
                    break;
                default:
                    throw new InvalidOperationException();
            };            
        }

        public override bool Equals(object? obj)
        {
            return obj is Union<TA, TB> union && Equals(union);
        }

        public bool Equals(Union<TA, TB> union)
        {
            return union.Match(a => a != null && a.Equals(_a), b => b != null && b.Equals(_b));
        }

        public override int GetHashCode()
        {
            return _item switch
            {
                1 => _a!.GetHashCode(),
                2 => _b!.GetHashCode(),
                _ => throw new InvalidOperationException()
            };
        }
    }

    public class Union<TA, TB, TC>
    {
        protected readonly int _item;
        protected readonly TA? _a;
        protected readonly TB? _b;
        protected readonly TC? _c;

        public Union(TA a)
        {
            _a = a;
            _item = 1;
        }

        public Union(TB b)
        {
            _b = b;
            _item = 2;
        }

        public Union(TC c)
        {
            _c = c;
            _item = 3;
        }

        public T Match<T>(Func<TA, T> funcA, Func<TB, T> funcB, Func<TC, T> funcC)
        {
            return _item switch
            {
                1 => funcA(_a!),
                2 => funcB(_b!),
                3 => funcC(_c!),
                _ => throw new InvalidOperationException(),
            };
        }

        public void Do(Action<TA> actionA, Action<TB> actionB, Action<TC> actionC)
        {
            switch (_item)
            {
                case 1:
                    actionA(_a!);
                    break;
                case 2:
                    actionB(_b!);
                    break;
                case 3:
                    actionC(_c!);
                    break;
            };
        }

        public static implicit operator Union<TA, TB, TC>(TA a)
        {
            return new Union<TA, TB, TC>(a);
        }

        public static implicit operator Union<TA, TB, TC>(TB b)
        {
            return new Union<TA, TB, TC>(b);
        }

        public static implicit operator Union<TA, TB, TC>(TC c)
        {
            return new Union<TA, TB, TC>(c);
        }

        public static implicit operator Union<TA, TB, TC>(Union<TA, TB> ab)
        {
            return ab.Match(a => new Union<TA, TB, TC>(a), b => new Union<TA, TB, TC>(b));
        }

        public static implicit operator Union<TA, TB, TC>(Union<TA, TC> ac)
        {
            return ac.Match(a => new Union<TA, TB, TC>(a), c => new Union<TA, TB, TC>(c));
        }

        public static implicit operator Union<TA, TB, TC>(Union<TB, TC> bc)
        {
            return bc.Match(b => new Union<TA, TB, TC>(b), c => new Union<TA, TB, TC>(c));
        }

        public void Deconstruct(out TA? a, out TB? b, out TC? c)
        {
            switch (_item)
            {
                case 1:
                    a = _a;
                    b = default;
                    c = default;
                    break;
                case 2:
                    a = default;
                    b = _b;
                    c = default;
                    break;
                case 3:
                    a = default;
                    b = default;
                    c = _c;
                    break;
                default:
                    throw new InvalidOperationException();
            };
        }

        public override bool Equals(object? obj)
        {
            return obj is Union<TA, TB, TC> union && Equals(union);
        }

        public bool Equals(Union<TA, TB, TC> union)
        {
            return union.Match(
                a => a != null && a.Equals(_a), 
                b => b != null && b.Equals(_b),
                c => c != null && c.Equals(_c)
                );
        }

        public override int GetHashCode()
        {
            return _item switch
            {
                1 => _a!.GetHashCode(),
                2 => _b!.GetHashCode(),
                3 => _c!.GetHashCode(),
                _ => throw new InvalidOperationException()
            };
        }
    }
}
