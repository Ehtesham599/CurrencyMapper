namespace CurrencyMapper;

public interface ICalculateAmount
{
    public uint ConvertToInt(string currencyCode, float amount);

    public float ConvertToFloat(string currencyCode, uint amount);
}


public class CalculateAmount: ICalculateAmount
{
    private readonly CurrencyMap _currencyMap;

    public CalculateAmount(CurrencyMap currencyMap)
    {
        _currencyMap = currencyMap;
    }

    public uint ConvertToInt(string currencyCode, float amount)
    {
        float value;
        if (_currencyMap.Currencies.TryGetValue(currencyCode.ToUpper(), out value))
        {
            return Convert.ToUInt32(amount * value);
        }
        return Convert.ToUInt32(amount);
    }

    public float ConvertToFloat(string currencyCode, uint amount)
    {
        float value;
        if (_currencyMap.Currencies.TryGetValue(currencyCode.ToUpper(), out value))
        {
            return Convert.ToSingle(amount / value);
        }
        return Convert.ToSingle(amount);
    }

}

