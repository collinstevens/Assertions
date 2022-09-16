using System.Text.Json;

namespace LanguageAssertions;

public class JsonSerializerTests
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
                var dateTimeOffset = JsonSerializer.Deserialize<DateTimeOffset>(json);
            
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
                var dateTimeOffset = JsonSerializer.Deserialize<DateTimeOffset>(json);
            
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
                var dateTime = JsonSerializer.Deserialize<DateTime>(json);
            
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
                var dateTime = JsonSerializer.Deserialize<DateTime>(json);

                // Assert
                Assert.Equal(DateTimeKind.Unspecified, dateTime.Kind);
            }
        }
    }
}