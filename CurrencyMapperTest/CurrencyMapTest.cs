using CurrencyMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CurrencyMapperTest;

[TestClass]
public class CurrencyMapTest
{

    // float to uint
    [TestMethod]
    public void TestFloatToIntPass()
    {
        
        string currencyCode = "KWD";
        float value = 50.5f;

        uint expectedValue = 50500;

        CurrencyMap currencyMap = new CurrencyMap();
        ICalculateAmount _calculateAmount = new CalculateAmount(currencyMap);
        uint result = _calculateAmount.ConvertToInt(currencyCode, value);

        Assert.AreEqual(expectedValue, result);
    }

    [TestMethod]
    public void TestFloatToIntPass_Integer_Value()
    {
        
        string currencyCode = "KWD";
        float value = 50;

        uint expectedValue = 50000;

        CurrencyMap currencyMap = new CurrencyMap();
        ICalculateAmount _calculateAmount = new CalculateAmount(currencyMap);
        uint result = _calculateAmount.ConvertToInt(currencyCode, value);

        Assert.AreEqual(expectedValue, result);
    }


    [TestMethod]
    public void TestFloatToIntFail_Incorrect_Result()
    {
        
        string currencyCode = "KWD";
        float value = 50.5f;

        uint expectedValue = 12345;

        CurrencyMap currencyMap = new CurrencyMap();
        ICalculateAmount _calculateAmount = new CalculateAmount(currencyMap);
        uint result = _calculateAmount.ConvertToInt(currencyCode, value);

        Assert.AreNotEqual(expectedValue, result);
    }

    [TestMethod]
    public void TestFloatToIntFail_Incorrect_Result_Integer()
    {
        
        string currencyCode = "KWD";
        float value = 505;

        uint expectedValue = 50500;

        CurrencyMap currencyMap = new CurrencyMap();
        ICalculateAmount _calculateAmount = new CalculateAmount(currencyMap);
        uint result = _calculateAmount.ConvertToInt(currencyCode, value);

        Assert.AreNotEqual(expectedValue, result);
    }


    // uint to float
    [TestMethod]
    public void TestIntToFloatPass()
    {

        string currencyCode = "KWD";
        uint value = 50500;

        float expectedValue = 50.5f;

        CurrencyMap currencyMap = new CurrencyMap();
        ICalculateAmount _calculateAmount = new CalculateAmount(currencyMap);
        float result = _calculateAmount.ConvertToFloat(currencyCode, value);

        Assert.AreEqual(expectedValue, result);
    }

    [TestMethod]
    public void TestIntToFloatPass_Integer_Value()
    {
        
        string currencyCode = "KWD";
        uint value = 50000;

        float expectedValue = 50;

        CurrencyMap currencyMap = new CurrencyMap();
        ICalculateAmount _calculateAmount = new CalculateAmount(currencyMap);
        float result = _calculateAmount.ConvertToFloat(currencyCode, value);

        Assert.AreEqual(expectedValue, result);
    }


    [TestMethod]
    public void TestIntToFloatFail_Incorrect_Result()
    {
        
        string currencyCode = "KWD";
        uint value = 12345;

        float expectedValue = 50.5f;

        CurrencyMap currencyMap = new CurrencyMap();
        ICalculateAmount _calculateAmount = new CalculateAmount(currencyMap);
        float result = _calculateAmount.ConvertToFloat(currencyCode, value);

        Assert.AreNotEqual(expectedValue, result);
    }

    [TestMethod]
    public void TestIntToFloatFail_Incorrect_Result_Integer()
    {
        
        string currencyCode = "KWD";
        uint value = 50500;

        float expectedValue = 505;

        CurrencyMap currencyMap = new CurrencyMap();
        ICalculateAmount _calculateAmount = new CalculateAmount(currencyMap);
        float result = _calculateAmount.ConvertToFloat(currencyCode, value);

        Assert.AreNotEqual(expectedValue, result);
    }

    [TestMethod]
    public void TestIntToFloatPass_Currency_Not_Found()
    {

        string currencyCode = "INR";
        uint value = 50500;

        float expectedValue = 50500;

        CurrencyMap currencyMap = new CurrencyMap();
        ICalculateAmount _calculateAmount = new CalculateAmount(currencyMap);
        float result = _calculateAmount.ConvertToFloat(currencyCode, value);

        Assert.AreEqual(expectedValue, result);
    }

    [TestMethod]
    public void TestIntToFloatFail_Currency_Not_Found()
    {

        string currencyCode = "INR";
        uint value = 50500;

        float expectedValue = 505;

        CurrencyMap currencyMap = new CurrencyMap();
        ICalculateAmount _calculateAmount = new CalculateAmount(currencyMap);
        float result = _calculateAmount.ConvertToFloat(currencyCode, value);

        Assert.AreNotEqual(expectedValue, result);
    }
}
