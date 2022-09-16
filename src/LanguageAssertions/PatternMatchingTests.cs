namespace LanguageAssertions;

public class PatternMatchingTests
{
    public enum Colors
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }

    [Theory]
    [CombinatorialData]
    public void ColorIsRedOrOrangeOrYellowOrGreenOrBlueOrIndigoOrVioletShouldReturnTrue(Colors color)
    {
        // Arrange
        static bool Func(Colors color) =>
            color is (
                Colors.Red or 
                Colors.Orange or 
                Colors.Yellow or 
                Colors.Green or 
                Colors.Blue or 
                Colors.Indigo or 
                Colors.Violet); 
        
        // Act
        var result = Func(color);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void RedIsNotOrOrangeOrYellowOrGreenOrBlueOrIndigoOrVioletShouldReturnTrue()
    {
        // Arrange
        static bool Func(Colors color) =>
            color is not (
                Colors.Orange or 
                Colors.Yellow or 
                Colors.Green or 
                Colors.Blue or 
                Colors.Indigo or 
                Colors.Violet); 
        
        // Act
        var result = Func(Colors.Red);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void IsNotOneOrTwoWithThreeShouldReturnTrue()
    {
        // Arrange
        var three = 3;
        
        // Act
        var result = three is not (1 or 2);
        
        // Assert
        Assert.True(result);
    }
}