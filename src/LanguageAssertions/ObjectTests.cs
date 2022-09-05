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

            // https://github.com/dotnet/roslyn-analyzers/issues/6149
#pragma warning disable CA2013
            // Act
            var result = ReferenceEquals(first, second);
#pragma warning restore CA2013

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

            // https://github.com/dotnet/roslyn-analyzers/issues/6149
#pragma warning disable CA2013
            // See comment by collinstevens on https://www.jetbrains.com/help/rider/ConditionIsAlwaysTrueOrFalse.html
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            // Act
            var result = ReferenceEquals(first, second);
#pragma warning restore CA2013

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnTrueForNullStringAndNullInteger()
        {
            // Arrange
            string? first = null;
            int? second = null;

            // https://github.com/dotnet/roslyn-analyzers/issues/6149
#pragma warning disable CA2013
            // See comment by collinstevens on https://www.jetbrains.com/help/rider/ConditionIsAlwaysTrueOrFalse.html
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            // Act
            var result = ReferenceEquals(first, second);
#pragma warning restore CA2013

            // Assert
            Assert.True(result);
        }
    }
}
