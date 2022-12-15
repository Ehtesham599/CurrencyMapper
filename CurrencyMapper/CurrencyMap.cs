using System;
namespace CurrencyMapper
{
	public class CurrencyMap
	{
        public readonly Dictionary<string, float> Currencies = new Dictionary<string, float>()
        {
            {"KWD", 1000},
            {"OMR", 1000},
            {"BHD", 1000},
            {"SAR", 100},
            {"AED", 100},
            {"QAR", 100},
            {"USD", 100},
        };
    }
}

