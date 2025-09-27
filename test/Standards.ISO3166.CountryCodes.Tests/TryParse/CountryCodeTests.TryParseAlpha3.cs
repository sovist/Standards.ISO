using Shouldly;
using Xunit;

namespace Standards.ISO3166.CountryCodes.Tests.TryParse
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
        public void TryParseAlpha3_ShouldParse_Belgium(string code, string expectedCountryName)
        {
            //Act
            CountryCode.TryParseAlpha3(code, out var countryCode).ShouldBeTrue();

            //Assert
            countryCode.ShouldNotBeNull().Name.ShouldBe(expectedCountryName);
        }
    }
}