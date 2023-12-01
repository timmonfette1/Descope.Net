using Descope.Types;

namespace Descope.Test.Types
{
    public class MillisecondsSinceEpochTests
    {
        [Fact]
        public void ShouldCreateFromConstructors()
        {
            var secondsAsLong = new MillisecondsSinceEpoch(946684800000);
            var secondsAsDate = new MillisecondsSinceEpoch(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            var secondsAsDateTimeOffset = new MillisecondsSinceEpoch(new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero));

            Assert.Equal<long>(946684800000, secondsAsLong);
            Assert.Equal<long>(946684800000, secondsAsDate);
            Assert.Equal<long>(946684800000, secondsAsDateTimeOffset);
        }

        [Fact]
        public void ShouldStringify()
        {
            var epoch = new MillisecondsSinceEpoch(946684800000);

            Assert.Equal("946684800000", epoch.ToString());
        }

        [Fact]
        public void ShouldConvertImplicit_long()
        {
            MillisecondsSinceEpoch epochFromLong = 946684800000;
            long longFromEpoch = new MillisecondsSinceEpoch(946684800000);

            Assert.Equal<long>(946684800000, epochFromLong);
            Assert.Equal(946684800000, longFromEpoch);
        }

        [Fact]
        public void ShouldConvertImplicit_DateTime()
        {
            MillisecondsSinceEpoch epochFromDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime dateTimeFromEpoch = new MillisecondsSinceEpoch(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc));

            Assert.Equal(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), epochFromDateTime);
            Assert.Equal(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), dateTimeFromEpoch);
        }

        [Fact]
        public void ShouldConvertImplicit_DateTimeOffset()
        {
            MillisecondsSinceEpoch epochFromDateTimeOffset = new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset dateTimeOffsetFromEpoch = new MillisecondsSinceEpoch(new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero));

            Assert.Equal(new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero), epochFromDateTimeOffset);
            Assert.Equal(new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero), dateTimeOffsetFromEpoch);
        }
    }
}
