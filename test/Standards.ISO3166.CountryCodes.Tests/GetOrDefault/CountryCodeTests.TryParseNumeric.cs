using System.Linq;
using Shouldly;
using Xunit;

namespace Standards.ISO3166.CountryCodes.Tests.GetOrDefault
{
    public partial class CountryCodeTests
    {
        [Theory]
        [InlineData("056", "Belgium")]
        [InlineData("56", "Belgium")]
        [InlineData("56 ", "Belgium")]
        [InlineData(" 56", "Belgium")]
        public void GetByNumericOrDefault_ShouldParse_Belgium(string code, string expectedCountryName)
        {
            //Act
            var countryCode = CountryCode.GetByNumericOrDefault(code);

            //Assert
            countryCode.ShouldNotBeNull().Name.ShouldBe(expectedCountryName);
        }

        [Fact]
        public void GetByNumericOrDefault_ShouldBeNull()
        {
            //Act
            var countryCode = CountryCode.GetByNumericOrDefault("some_country_code");

            //Assert
            countryCode.ShouldBeNull();
        }

        [Fact]
        public void GetByNumericOrDefault_ShouldUseDefaultCountryCode()
        {
            var defaultCountryCode = CountryCode.GetCountryCodes().First();

            //Act
            var countryCode = CountryCode.GetByNumericOrDefault("some_country_code", defaultCountryCode);

            //Assert
            countryCode.ShouldBe(countryCode);
        }
    }
}