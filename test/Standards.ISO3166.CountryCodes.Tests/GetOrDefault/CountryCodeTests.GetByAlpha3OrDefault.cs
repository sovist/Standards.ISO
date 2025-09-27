using System.Linq;
using Shouldly;
using Xunit;

namespace Standards.ISO3166.CountryCodes.Tests.GetOrDefault
{
    public partial class CountryCodeTests
    {
        [Theory]
        [InlineData("BEL", "Belgium")]
        [InlineData(" BEL", "Belgium")]
        [InlineData("BEL ", "Belgium")]
        [InlineData("bEL", "Belgium")]
        [InlineData("Bel", "Belgium")]
        [InlineData("bel", "Belgium")]
        [InlineData("bel ", "Belgium")]
        [InlineData(" bel ", "Belgium")]
        public void GetByAlpha3OrDefault_ShouldParse_Belgium(string code, string expectedCountryName)
        {
            //Act
            var countryCode = CountryCode.GetByAlpha3OrDefault(code);

            //Assert
            countryCode.ShouldNotBeNull().Name.ShouldBe(expectedCountryName);
        }

        [Fact]
        public void GetByAlpha3OrDefault_ShouldBeNull()
        {
            //Act
            var countryCode = CountryCode.GetByAlpha3OrDefault("some_country_code");

            //Assert
            countryCode.ShouldBeNull();
        }

        [Fact]
        public void GetByAlpha3OrDefault_ShouldUseDefaultCountryCode()
        {
            var defaultCountryCode = CountryCode.GetCountryCodes().First();

            //Act
            var countryCode = CountryCode.GetByAlpha3OrDefault("some_country_code", defaultCountryCode);

            //Assert
            countryCode.ShouldBe(countryCode);
        }
    }
}