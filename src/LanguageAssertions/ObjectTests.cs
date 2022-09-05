namespace LanguageAssertions;

public class ObjectTests
{
    public class EqualsTests
    {
        [Fact]
        public void ShouldReturnTrueForNullObjects()
        {
            // Arrange
            object? first = null;
            object? second = null;

            // Act
            var result = Equals(first, second);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnTrueForNullIntegers()
        {
            // Arrange
            int? first = null;
            int? second = null;

            // Act
            var result = Equals(first, second);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnTrueForNullStrings()
        {
            // Arrange
            string? first = null;
            string? second = null;

            // Act
            var result = Equals(first, second);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnTrueForNullIntegerAndNullString()
        {
            // Arrange
            int? first = null;
            string? second = null;

            // Act
            var result = Equals(first, second);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnTrueForNullStringAndNullInteger()
        {
            // Arrange
            string? first = null;
            int? second = null;

            // Act
            var result = Equals(first, second);

            // Assert
            Assert.True(result);
        }
    }

    public class ReferenceEqualsTests
    {
        [Fact]
        public void ShouldReturnTrueForNullObjects()
        {
            // Arrange
            object? first = null;
            object? second = null;

            // Act
            var result = ReferenceEquals(first, second);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnTrueForNullIntegers()
        {
            // Arrange
            int? first = null;
            int? second = null;

            // Act
            var result = ReferenceEquals(first, second);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnTrueForNullStrings()
        {
            // Arrange
            string? first = null;
            string? second = null;

            // Act
            var result = ReferenceEquals(first, second);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnTrueForNullIntegerAndNullString()
        {
            // Arrange
            int? first = null;
            string? second = null;

            // Act
            var result = ReferenceEquals(first, second);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnTrueForNullStringAndNullInteger()
        {
            // Arrange
            string? first = null;
            int? second = null;

            // Act
            var result = ReferenceEquals(first, second);

            // Assert
            Assert.True(result);
        }
    }
}
