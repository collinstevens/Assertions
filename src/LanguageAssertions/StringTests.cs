namespace LanguageAssertions;

public class StringTests
{
    public class OperatorEqualsTests
    {
        [Fact]
        public void ShouldReturnTrueForNullStrings()
        {
            // Arrange
            string? first = null;
            string? second = null;

            // Act
            var result = first == second;

            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void ShouldReturnFalseForEmptyStringAndNullableNullString()
        {
            // Arrange
            string first = string.Empty;
            string? second = null;

            // Act
            var result = first == second;

            // Assert
            Assert.False(result);
        }
        
        [Fact]
        public void ShouldReturnFalseForNullableEmptyStringAndNullableNullString()
        {
            // Arrange
            string? first = string.Empty;
            string? second = null;

            // Act
            var result = first == second;

            // Assert
            Assert.False(result);
        }
    }
}