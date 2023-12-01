using Descope.Types;

namespace Descope.Test.Types
{
    public class SecondsSinceEpochTests
    {
        [Fact]
        public void ShouldCreateFromConstructors()
        {
            var secondsAsLong = new SecondsSinceEpoch(946684800);
            var secondsAsDate = new SecondsSinceEpoch(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            var secondsAsDateTimeOffset = new SecondsSinceEpoch(new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero));

            Assert.Equal(946684800, secondsAsLong);
            Assert.Equal(946684800, secondsAsDate);
            Assert.Equal(946684800, secondsAsDateTimeOffset);
        }

        [Fact]
        public void ShouldStringify()
        {
            var epoch = new SecondsSinceEpoch(946684800);

            Assert.Equal("946684800", epoch.ToString());
        }

        [Fact]
        public void ShouldConvertImplicit_long()
        {
            SecondsSinceEpoch epochFromLong = 946684800;
            long longFromEpoch = new SecondsSinceEpoch(946684800);

            Assert.Equal(946684800, epochFromLong);
            Assert.Equal(946684800, longFromEpoch);
        }

        [Fact]
        public void ShouldConvertImplicit_DateTime()
        {
            SecondsSinceEpoch epochFromDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime dateTimeFromEpoch = new SecondsSinceEpoch(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc));

            Assert.Equal(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), epochFromDateTime);
            Assert.Equal(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), dateTimeFromEpoch);
        }

        [Fact]
        public void ShouldConvertImplicit_DateTimeOffset()
        {
            SecondsSinceEpoch epochFromDateTimeOffset = new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset dateTimeOffsetFromEpoch = new SecondsSinceEpoch(new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero));

            Assert.Equal(new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero), epochFromDateTimeOffset);
            Assert.Equal(new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero), dateTimeOffsetFromEpoch);
        }
    }
}
