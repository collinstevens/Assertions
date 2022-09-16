namespace LanguageAssertions;

public class DateTimeOffsetTests
{
    public class ToLocalTimeTests
    {
        [Fact]
        public void ShouldReturnLocalDateTimeInDaylightSavings()
        {
            // Arrange
            var utcDateTimeOffset = DateTimeOffset.UtcNow;
            var localDateTimeOffset = DateTimeOffset.Now;
            
            var timeZone = TimeZoneInfo.Local;
            var standardOffset = timeZone.BaseUtcOffset;
            var daylightSavingsOffset = timeZone.GetUtcOffset(DateTime.UtcNow);
            
            Assert.Equal(TimeSpan.Parse("-07:00:00"), standardOffset);
            Assert.Equal(TimeSpan.Parse("-06:00:00"), daylightSavingsOffset);

            // Act
            var dateTime = utcDateTimeOffset.LocalDateTime;
            
            // Assert
            Assert.Equal(DateTimeKind.Local, dateTime.Kind);
            Assert.Equal(daylightSavingsOffset, localDateTimeOffset.Offset);
        }
    }
}