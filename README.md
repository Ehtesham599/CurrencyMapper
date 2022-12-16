# CurrencyMapper
> A simple class library to manage currency values in a global system.

## Overview
<b>CurrecncyMapper</b> is a class library solution proposed to solve the problem of storing and managing localized values (amounts) corresponding to different currencies and their formats.

For example, let's assume a product is being sold with different prices in two different countries, each having their own currency. It is not ideal to store these values directly into a database as they may get rounded off to the nearest decimal value.\
An added challenge would be the implementation of precision handling for each country based on the currency's minor unit.

Proposed solution is to store localized values (amounts) as integers depending upon the currency's minor unit. On retrieving this value, it can be converted to float and precision set according to the minor unit.

Hence, this solution provides a helper interface to carry out the above operations.

### Example
Currency: KWD\
Minor unit: 1000\
Amount: 50.5

Store in DB -> `50.5 x 1000 = 50500`\
On retrieval -> `50500 / 1000 = 50.5`

## Usage

Currency codes and their respective minor units are stored as a dictionary in the `CurrencyMap` class.
```
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
```

The solution provides an `ICalculateAmount` interface with two methods:
```
public interface ICalculateAmount
{
    public uint ConvertToInt(string currencyCode, float amount);

    public float ConvertToFloat(string currencyCode, uint amount);
}
```

The `ConvertToInt` method converts float value to integer based the currency code provided.\
The `ConvertToFloat` method can be used to get the actual value of type float based on the currency code provided.
