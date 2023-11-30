namespace Descope.Types
{
    public readonly struct SecondsSinceEpoch(long seconds)
    {
        private readonly long _seconds = seconds;

        public SecondsSinceEpoch(DateTime date) : this(new DateTimeOffset(date))
        {

        }

        public SecondsSinceEpoch(DateTimeOffset offset) : this(offset.ToUnixTimeSeconds())
        {

        }

        public static implicit operator long(SecondsSinceEpoch s) => s._seconds;
        public static implicit operator SecondsSinceEpoch(long l) => new(l);

        public static implicit operator DateTime(SecondsSinceEpoch s) => DateTimeOffset.FromUnixTimeSeconds(s._seconds).DateTime;
        public static implicit operator SecondsSinceEpoch(DateTime d) => new(d);

        public static implicit operator DateTimeOffset(SecondsSinceEpoch s) => DateTimeOffset.FromUnixTimeSeconds(s._seconds);
        public static implicit operator SecondsSinceEpoch(DateTimeOffset d) => new(d);

        public override string ToString() => _seconds.ToString();
    }
}
