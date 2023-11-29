namespace Descope.Types
{
    public readonly struct MillisecondsSinceEpoch(long seconds)
    {
        private readonly long _seconds = seconds;

        public MillisecondsSinceEpoch(DateTime date) : this(new DateTimeOffset(date.ToUniversalTime()))
        {

        }

        public MillisecondsSinceEpoch(DateTimeOffset offset) : this(offset.ToUnixTimeMilliseconds())
        {

        }

        public static implicit operator long(MillisecondsSinceEpoch s) => s._seconds;
        public static implicit operator MillisecondsSinceEpoch(long l) => new(l);

        public static implicit operator DateTime(MillisecondsSinceEpoch s) => DateTimeOffset.FromUnixTimeMilliseconds(s._seconds).DateTime;
        public static implicit operator MillisecondsSinceEpoch(DateTime d) => new(d);

        public static implicit operator DateTimeOffset(MillisecondsSinceEpoch s) => DateTimeOffset.FromUnixTimeMilliseconds(s._seconds);
        public static implicit operator MillisecondsSinceEpoch(DateTimeOffset d) => new(d);

        public override string ToString() => _seconds.ToString();
    }
}
