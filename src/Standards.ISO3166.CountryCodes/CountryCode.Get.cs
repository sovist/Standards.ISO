using System.Collections.Generic;

namespace Standards.ISO3166.CountryCodes
{
    public partial class CountryCode
    {
        /// <summary>
        /// Retrieves a collection of all predefined country codes based on the ISO 3166 standard.
        /// </summary>
        /// <returns>
        /// A read-only collection of <see cref="CountryCode"/> objects representing the available country codes.
        /// </returns>
        public static IReadOnlyCollection<CountryCode> GetCountryCodes()
        {
            return CountryCodes;
        }
    }
}