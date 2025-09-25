using Shouldly;
using Xunit;

namespace Standards.ISO3166.CountryCodes.Tests
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
        public void TryParseAlpha2_ShouldParse_Belgium(string code, string expectedCountryName)
        {
            //Act
            CountryCode.TryParseAlpha2(code, out var countryCode).ShouldBeTrue();

            //Assert
            countryCode.ShouldNotBeNull().Name.ShouldBe(expectedCountryName);
        }
    }
}