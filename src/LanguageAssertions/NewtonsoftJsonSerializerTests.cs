using Newtonsoft.Json;

namespace LanguageAssertions;

public class NewtonsoftJsonSerializerTests
{
    public class DeserializeTests
    {
        public class DateTimeOffsetTests
        {
            [Theory]
            [InlineData("2019-04-24T14:50:17.101Z")]
            public void ShouldSetOffsetEqualToUtcOffset(string value)
            {
                // Arrange
                var json = $"\"{value}\"";
            
                // Act
                var dateTimeOffset = JsonConvert.DeserializeObject<DateTimeOffset>(json);
            
                // Assert
                Assert.Equal(TimeZoneInfo.Utc.BaseUtcOffset, dateTimeOffset.Offset);
            }
        
            [Theory]
            [InlineData("2019-04-24T14:50:17.101")]
            public void ShouldSetOffsetEqualToLocalOffset(string value)
            {
                // Arrange
                var json = $"\"{value}\"";
            
                // Act
                var dateTimeOffset = JsonConvert.DeserializeObject<DateTimeOffset>(json);
            
                // Assert
                var offset = TimeZoneInfo.Local.GetUtcOffset(DateTimeOffset.UtcNow);
                Assert.Equal(offset, dateTimeOffset.Offset);
            }
        }
        
        public class DateTimeTests
        {
            [Theory]
            [InlineData("2019-04-24T14:50:17.101Z")]
            public void ShouldSetKindToUtc(string value)
            {
                // Arrange
                var json = $"\"{value}\"";
            
                // Act
                var dateTime = JsonConvert.DeserializeObject<DateTime>(json);
            
                // Assert
                Assert.Equal(DateTimeKind.Utc, dateTime.Kind);
            }
        
            [Theory]
            [InlineData("2019-04-24T14:50:17.101")]
            public void ShouldSetKindToUnspecified(string value)
            {
                // Arrange
                var json = $"\"{value}\"";

                // Act
                var dateTime = JsonConvert.DeserializeObject<DateTime>(json);

                // Assert
                Assert.Equal(DateTimeKind.Unspecified, dateTime.Kind);
            }
            
            [Theory]
            [InlineData("2022-01-01T00:00:00.000")] // Mountain Standard Time
            [InlineData("2022-04-01T00:00:00.000")] // Mountain Daylight Time
            public void ShouldNotSetDateTimeKindEqualToDateTimeKindFromToLocalTime(string value)
            {
                // Arrange
                var json = $"\"{value}\"";

                // Act
                var dateTime = JsonConvert.DeserializeObject<DateTime>(json);
                var dateTimeOffset = JsonConvert.DeserializeObject<DateTimeOffset>(json);
                var dateTimeFromDateTimeOffset = dateTimeOffset.LocalDateTime;
                
                // Assert
                Assert.Equal("Mountain Standard Time", TimeZoneInfo.Local.StandardName);
                Assert.Equal("Mountain Daylight Time", TimeZoneInfo.Local.DaylightName);
                Assert.Equal(DateTimeKind.Unspecified, dateTime.Kind);
                Assert.Equal(DateTimeKind.Local, dateTimeFromDateTimeOffset.Kind);
                Assert.NotEqual(dateTime.Kind, dateTimeFromDateTimeOffset.Kind);
                Assert.Equal(dateTime, dateTimeFromDateTimeOffset);
            }
        }
    }
}