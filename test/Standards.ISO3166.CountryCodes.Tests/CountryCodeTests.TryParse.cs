using Shouldly;
using Xunit;

namespace Standards.ISO3166.CountryCodes.Tests
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
        public void TryParse_ShouldParse_Belgium(string code, string expectedCountryName)
        {
            //Act
            CountryCode.TryParse(code, out var countryCode).ShouldBeTrue();

            //Assert
            countryCode.ShouldNotBeNull().Name.ShouldBe(expectedCountryName);
        }
    }
}