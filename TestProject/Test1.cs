using BMICalculator;
namespace TestProject;

[TestClass]
public sealed class Test1
{
    //claude gen
    [TestMethod]
    public void BMIValue_ValidImperialInput_ReturnsCorrectBMI()
    {
        // Arrange: 11 stone 0 lbs (154 lbs), 5 ft 10 in (70 in)
        var bmi = new BMI
        {
            WeightStones = 11,
            WeightPounds = 0,
            HeightFeet = 5,
            HeightInches = 10
        };

        // Expected: 154 * 0.453592 = 69.853168 kg
        //           70 * 0.0254   = 1.778 m
        //           69.853168 / (1.778^2) = ~22.10
        double expected = 22.10;

        // Act
        double actual = bmi.BMIValue;

        // Assert (delta of 0.01 for floating point)
        Assert.AreEqual(expected, actual, 0.01);
    }
    
    //claude gen
    [TestMethod]
    [DataRow(7, 0, 5, 10, BMICategory.Underweight)]   // 98 lbs,  70 in -> ~14.1
    [DataRow(11, 0, 5, 10, BMICategory.Normal)]       // 154 lbs, 70 in -> ~22.1
    [DataRow(13, 7, 5, 10, BMICategory.Overweight)]   // 189 lbs, 70 in -> ~27.1
    [DataRow(18, 0, 5, 10, BMICategory.Obese)]        // 252 lbs, 70 in -> ~36.2
    public void BMICategory_VariousInputs_ReturnsExpectedCategory(
        int stones, int pounds, int feet, int inches, BMICategory expected)
    {
        // Arrange
        var bmi = new BMI
        {
            WeightStones = stones,
            WeightPounds = pounds,
            HeightFeet = feet,
            HeightInches = inches
        };

        // Act
        BMICategory actual = bmi.BMICategory;

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
