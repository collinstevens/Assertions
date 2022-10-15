namespace LanguageAssertions.Extensions;

public class TypeExtensionsTests
{
    public class IsDictionaryTests
    {
        [Theory]
        [InlineData(typeof(IDictionary<,>))]
        [InlineData(typeof(Dictionary<,>))]
        [InlineData(typeof(IDictionary<int, int>))]
        [InlineData(typeof(Dictionary<int, int>))]
        public void ShouldReturnTrue(Type type)
        {
            // Act
            var result = type.IsDictionary();

            // Assert
            Assert.True(result);            
        }
        
        [Theory]
        [InlineData(typeof(IList<>))]
        [InlineData(typeof(List<>))]
        [InlineData(typeof(IList<int>))]
        [InlineData(typeof(List<int>))]
        [InlineData(typeof(int))]
        [InlineData(typeof(object))]
        public void ShouldReturnFalse(Type type)
        {
            // Act
            var result = type.IsDictionary();

            // Assert
            Assert.False(result);            
        }
    }
}