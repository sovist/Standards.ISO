using Shouldly;
using Xunit;

namespace Standards.ISO3166.CountryCodes.Tests
{
    public partial class CountryCodeTests
    {
        [Theory]
        [InlineData("056", "Belgium")]
        [InlineData("56", "Belgium")]
        [InlineData("56 ", "Belgium")]
        [InlineData(" 56", "Belgium")]
        public void TryParseNumeric_ShouldParse_Belgium(string code, string expectedCountryName)
        {
            //Act
            CountryCode.TryParseNumeric(code, out var countryCode).ShouldBeTrue();

            //Assert
            countryCode.ShouldNotBeNull().Name.ShouldBe(expectedCountryName);
        }
    }
}