using System;
using System.Linq;
using Shouldly;
using Xunit;

namespace Standards.ISO3166.CountryCodes.Tests
{
    public partial class CountryCodeTests
    {
        [Fact]
        public void Load_ShouldBeUnique_WhenByName()
        {
            //Assert
            AssertIsUniqueBy(_ => _.Name);
        }

        [Fact]
        public void Load_ShouldBeUnique_WhenByAlpha2()
        {
            //Assert
            AssertIsUniqueBy(_ => _.Alpha2);
        }

        [Fact]
        public void Load_ShouldBeUnique_WhenByAlpha3()
        {
            //Assert
            AssertIsUniqueBy(_ => _.Alpha3);
        }

        [Fact]
        public void Load_ShouldBeUnique_WhenByNumeric()
        {
            //Assert
            AssertIsUniqueBy(_ => _.Numeric);
        }

        private static void AssertIsUniqueBy<TProperty>(Func<CountryCode, TProperty> propertySelector)
        {
            //Act
            var countries = CountryCode.GetCountryCodes();

            //Assert
            countries.GroupBy(propertySelector).Where(_ => _.Count() > 1).ShouldBeEmpty();
        }
    }
}