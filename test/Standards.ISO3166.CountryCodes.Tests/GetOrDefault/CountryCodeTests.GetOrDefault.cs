using System.Linq;
using Shouldly;
using Xunit;

namespace Standards.ISO3166.CountryCodes.Tests.GetOrDefault
{
    public partial class CountryCodeTests
    {
        [Theory]
        //by alpha2
        [InlineData("BE", "Belgium")]
        [InlineData(" BE", "Belgium")]
        [InlineData("BE ", "Belgium")]
        [InlineData("bE", "Belgium")]
        [InlineData(" bE", "Belgium")]
        [InlineData(" be ", "Belgium")]
        //by alpha3
        [InlineData("BEL", "Belgium")]
        [InlineData(" BEL", "Belgium")]
        [InlineData("BEL ", "Belgium")]
        [InlineData("bEL", "Belgium")]
        [InlineData("Bel", "Belgium")]
        [InlineData("bel", "Belgium")]
        [InlineData("bel ", "Belgium")]
        [InlineData(" bel ", "Belgium")]
        //by numeric
        [InlineData("056", "Belgium")]
        [InlineData("56", "Belgium")]
        [InlineData("56 ", "Belgium")]
        [InlineData(" 56", "Belgium")]
        public void GetOrDefault_ShouldParse_Belgium(string code, string expectedCountryName)
        {
            //Act
            var countryCode = CountryCode.GetOrDefault(code);

            //Assert
            countryCode.ShouldNotBeNull().Name.ShouldBe(expectedCountryName);
        }

        [Fact]
        public void GetOrDefault_ShouldBeNull()
        {
            //Act
            var countryCode = CountryCode.GetOrDefault("some_country_code");

            //Assert
            countryCode.ShouldBeNull();
        }

        [Fact]
        public void GetOrDefault_ShouldUseDefaultCountryCode()
        {
            var defaultCountryCode = CountryCode.GetCountryCodes().First();

            //Act
            var countryCode = CountryCode.GetOrDefault("some_country_code", defaultCountryCode);

            //Assert
            countryCode.ShouldBe(countryCode);
        }
    }
}