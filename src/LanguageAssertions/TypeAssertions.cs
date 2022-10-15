using System.Collections;

namespace LanguageAssertions;

public class TypeAssertions
{
    public class GetGenericTypeDefinitionTests
    {
        [Fact]
        public void ShouldReturnSameDefinitionForUnboundedGeneric()
        {
            // Arrange
            var type = typeof(List<>);

            // Act
            var result = type.GetGenericTypeDefinition();

            // Assert
            Assert.Equal(type, result);
        }
    }
    
    public class IsGenericTypeTests
    {
        [Theory]
        [InlineData(typeof(IList<>))]
        [InlineData(typeof(IList<int>))]
        [InlineData(typeof(List<>))]
        [InlineData(typeof(List<int>))]
        public void ShouldReturnTrue(Type type)
        {
            // Act
            var result = type.IsGenericType;

            // Assert
            Assert.True(result);
        }
        
        [Theory]
        [InlineData(typeof(object))]
        [InlineData(typeof(IList))]
        public void ShouldReturnFalse(Type type)
        {
            // Act
            var result = type.IsGenericType;

            // Assert
            Assert.False(result);
        }
    }
    
    public class IsGenericTypeDefinitionTests
    {
        [Theory]
        [InlineData(typeof(IList<>))]
        [InlineData(typeof(List<>))]
        public void ShouldReturnTrue(Type type)
        {
            // Act
            var result = type.IsGenericTypeDefinition;

            // Assert
            Assert.True(result);
        }
        
        [Theory]
        [InlineData(typeof(object))]
        [InlineData(typeof(IList))]
        [InlineData(typeof(List<int>))]
        [InlineData(typeof(IList<int>))]
        public void ShouldReturnFalse(Type type)
        {
            // Act
            var result = type.IsGenericTypeDefinition;

            // Assert
            Assert.False(result);
        }
    }
    
    public class IsConstructedGenericTypeTests
    {
        [Theory]
        [InlineData(typeof(List<int>))]
        [InlineData(typeof(IList<int>))]
        public void ShouldReturnTrue(Type type)
        {
            // Act
            var result = type.IsConstructedGenericType;

            // Assert
            Assert.True(result);
        }
        
        [Theory]
        [InlineData(typeof(object))]
        [InlineData(typeof(IList))]
        [InlineData(typeof(IList<>))]
        [InlineData(typeof(List<>))]
        public void ShouldReturnFalse(Type type)
        {
            // Act
            var result = type.IsConstructedGenericType;

            // Assert
            Assert.False(result);
        }
    }
}
