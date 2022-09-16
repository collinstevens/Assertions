namespace LanguageAssertions;

public class RangeTests
{
    public class FromEndTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("ab")]
        [InlineData("abc")]
        public void ShouldThrowWhenGoingPastEnd(string value)
        {
            // Arrange
            static string Func(string word) => word[^(word.Length + 1)..];
            
            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Func(value));
        }
    }
}