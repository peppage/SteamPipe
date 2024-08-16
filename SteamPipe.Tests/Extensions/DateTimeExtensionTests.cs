namespace SteamPipe.Tests.Extensions
{
    public static class DateTimeExtensionsTests
    {
        [Fact]
        public static void ToUnixTimeSeconds_KnownDateTime_ReturnsExpectedUnixTime()
        {
            var dateTime = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            const long expectedUnixTime = 1672531200L;

            var unixTime = dateTime.ToUnixTimeSeconds();

            Assert.Equal(expectedUnixTime, unixTime);
        }

        [Fact]
        public static void ToUnixTimeSeconds_UnixEpochStart_ReturnsZero()
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            const long expectedUnixTime = 0L;

            var unixTime = dateTime.ToUnixTimeSeconds();

            Assert.Equal(expectedUnixTime, unixTime);
        }

        [Fact]
        public static void ToUnixTimeSeconds_FarFutureDateTime_ReturnsExpectedUnixTime()
        {
            var dateTime = new DateTime(3000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            const long expectedUnixTime = 32503680000L;

            var unixTime = dateTime.ToUnixTimeSeconds();

            Assert.Equal(expectedUnixTime, unixTime);
        }

        [Fact]
        public static void ToUnixTimeSeconds_FarPastDateTime_ReturnsExpectedUnixTime()
        {
            var dateTime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            const long expectedUnixTime = -2208988800L;

            var unixTime = dateTime.ToUnixTimeSeconds();

            Assert.Equal(expectedUnixTime, unixTime);
        }
    }
}