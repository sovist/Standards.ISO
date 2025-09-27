using System.Linq;
using Shouldly;
using Xunit;

namespace Standards.ISO3166.CountryCodes.Tests.GetOrDefault
{
    public partial class CountryCodeTests
    {
        [Theory]
        [InlineData("BE", "Belgium")]
        [InlineData(" BE", "Belgium")]
        [InlineData("BE ", "Belgium")]
        [InlineData("bE", "Belgium")]
        [InlineData(" bE", "Belgium")]
        [InlineData(" be ", "Belgium")]
        public void GetByAlpha2OrDefault_ShouldParse_Belgium(string code, string expectedCountryName)
        {
            //Act
            var countryCode = CountryCode.GetByAlpha2OrDefault(code);

            //Assert
            countryCode.ShouldNotBeNull().Name.ShouldBe(expectedCountryName);
        }

        [Fact]
        public void GetByAlpha2OrDefault_ShouldBeNull()
        {
            //Act
            var countryCode = CountryCode.GetByAlpha2OrDefault("some_country_code");

            //Assert
            countryCode.ShouldBeNull();
        }

        [Fact]
        public void GetByAlpha2OrDefault_ShouldUseDefaultCountryCode()
        {
            var defaultCountryCode = CountryCode.GetCountryCodes().First();

            //Act
            var countryCode = CountryCode.GetByAlpha2OrDefault("some_country_code", defaultCountryCode);

            //Assert
            countryCode.ShouldBe(countryCode);
        }
    }
}