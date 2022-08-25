using IncrementApi.Services;

namespace TestIncrementApi;

public class StringIncrementServiceTest
{
    private readonly StringIncrementService _service = new();
    
    [TestCase("1", 3, "4")]
    [TestCase("1w", 3, "4w")]
    [TestCase("1w2", 3, "4w5")]
    [TestCase("1w2s0", 3, "4w5s3")]
    [TestCase("1w2s01", 3, "4w5s34")]
    [TestCase("1w2s01r9", 3, "4w5s34r1")]
    
    [TestCase("1", 13, "1")]
    [TestCase("1w", 13, "1w")]
    [TestCase("1w2", 13, "1w1")]
    [TestCase("1w10", 13, "1w23")]
    [TestCase("1w10s21", 13, "1w23s34")]
    [TestCase("1w10s21r0t05", 13, "1w23s34r1t11")]
    
    [TestCase("WORK123CODE56", 55, "WORK178CODE11")]
    
    public void Increment(string input, int increment, string expected)
    {
        // Act
        var result = _service.Increment(input,increment);
            
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}