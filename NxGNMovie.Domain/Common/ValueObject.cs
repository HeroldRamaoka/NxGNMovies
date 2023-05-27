namespace NxGNMovie.Domain.Common
{
    public abstract record ValueObject
    {
        public static bool operator <(ValueObject left, ValueObject right)
        {
            return left < right;
        }

        public static bool operator >(ValueObject left, ValueObject right)
        {
            return left > right;
        }

        public static bool operator <=(ValueObject left, ValueObject right)
        {
            return (left < right || left == right);
        }

        public static bool operator >=(ValueObject left, ValueObject right)
        {
            return (left > right || left == right);
        }
    }
}