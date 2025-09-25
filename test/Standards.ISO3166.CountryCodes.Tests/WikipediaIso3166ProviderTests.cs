using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Standards.ISO3166.CountryCodes.Providers;
using Xunit;

namespace Standards.ISO3166.CountryCodes.Tests
{
    public class WikipediaIso3166ProviderTests
    {
        public WikipediaIso3166Provider Provider { get; } = new WikipediaIso3166Provider();

        [Fact(Skip = "Manual, to generate countries.txt")]
        public async Task Load_Should_Return_Countries()
        {
            //Act
            var countryCodes = await Provider.Load();

            countryCodes = countryCodes.OrderBy(_ => _.Name).ToList();

            //Assert
            var sb = new System.Text.StringBuilder();

            foreach (var country in countryCodes)
            {
                sb.AppendLine($"new CountryCode(\"{country.Alpha2}\", \"{country.Alpha3}\", {country.Numeric:000}, \"{country.Name}\"),");
            }

            await File.WriteAllTextAsync("countries.txt", sb.ToString());
        }

        [Fact]
        public async Task Load_ShouldBe_UpToDate()
        {
            //Act
            var remoteCountryCodes = await Provider.Load();

            //Assert
            AssertUpToDateBy(country => country.Name, StringComparer.OrdinalIgnoreCase);

            AssertUpToDateBy(country => country.Alpha2, StringComparer.OrdinalIgnoreCase);

            AssertUpToDateBy(country => country.Alpha3, StringComparer.OrdinalIgnoreCase);

            AssertUpToDateBy(country => country.Numeric);

            return;

            void AssertUpToDateBy<TProperty>(Func<CountryCode, TProperty> propertySelector, IEqualityComparer<TProperty> comparer = null)
            {
                var localCountryCodes = CountryCode.GetCountryCodes();

                localCountryCodes.ExceptBy(remoteCountryCodes.Select(propertySelector), propertySelector, comparer).ShouldBeEmpty();

                remoteCountryCodes.ExceptBy(localCountryCodes.Select(propertySelector), propertySelector, comparer).ShouldBeEmpty();
            }
        }
    }
}