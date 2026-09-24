# Standards.ISO

[![NuGet](https://img.shields.io/nuget/v/Standards.ISO3166.CountryCodes.svg)](https://www.nuget.org/packages/Standards.ISO3166.CountryCodes)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Standards.ISO3166.CountryCodes.svg)](https://www.nuget.org/packages/Standards.ISO3166.CountryCodes)
[![Build & Tests](https://github.com/sovist/Standards.ISO/actions/workflows/dotnet.yml/badge.svg)](https://github.com/sovist/Standards.ISO/actions/workflows/dotnet.yml)
[![License: MIT](https://img.shields.io/github/license/sovist/Standards.ISO)](https://github.com/sovist/Standards.ISO/blob/master/LICENSE)

### How to use
```
using Standards.ISO3166.CountryCodes;

public void Demo_1()
{
    //by alpha2, alpha3 and numeric codes
    var countryCode = CountryCode.GetOrDefault("BE");

    //Belgium
    Console.WriteLine(countryCode.Name);
}
```

### Additional API
```
public void Demo_4()
{    
    //Try to parse by an alpha2, alpha3 or numeric code
    CountryCode.TryParseA("BE", out var countryCode);

    //Try to parse an alpha2 country code
    CountryCode.TryParseAlpha2("BE", out var countryCode);
    
    //Try to parse an alpha2 country code
    CountryCode.TryParseAlpha2("BE", out var countryCode);
    
    //Try to parse an alpha3 country code.
    CountryCode.TryParseAlpha3("BEL", out var countryCode);
    
    //Try to parse a numeric country code.
    CountryCode.TryParseNumeric("BEL", out var countryCode);
    
    //Retrieves a collection of all predefined country codes based on the ISO 3166 standard.
    CountryCode.GetCountryCodes();
}
```