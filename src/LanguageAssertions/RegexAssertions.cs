using System.Text.RegularExpressions;

namespace LanguageAssertions;

public class RegexAssertions
{
    public class IsMatchTests
    {
        [Theory]
        [InlineData("abc1")]
        [InlineData("abc 1")]
        [InlineData("1abc")]
        [InlineData("1 abc")]
        [InlineData(" abc")]
        [InlineData("abc ")]
        [InlineData(" abc ")]
        public void ShouldReturnFalseIfOnlyMatchesSubsetOfInput(string input)
        {
            // Arrange
            var regex = new Regex("^[a-z]+$");
            
            // Act
            var matches = regex.IsMatch(input);
            
            // Assert
            Assert.False(matches);
        }
    }
}