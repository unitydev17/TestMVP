using mine.calculator.utils;
using NUnit.Framework;


public class TestCalculatorUtils
{
    [Test]
    public void TestCalculatorUtilsSimplePasses()
    {
        Assert.AreEqual(1, StateConverter.Convert(true));
        Assert.AreEqual(2, StateConverter.Convert(false, true, false, false));
    }
}