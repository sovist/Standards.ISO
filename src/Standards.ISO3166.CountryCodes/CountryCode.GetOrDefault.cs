namespace Standards.ISO3166.CountryCodes
{
    public partial class CountryCode
    {
        /// <summary>
        /// Retrieves the country code object corresponding to the provided code. If the code is invalid or not
        /// recognized, the default country code is returned.
        /// </summary>
        /// <param name="code">The country code to be parsed. This can be an alpha2, alpha3, or numeric code.</param>
        /// <param name="defaultCountryCode">
        /// The default country code to return if the provided code is invalid or not recognized.
        /// If not specified, the default value is null.
        /// </param>
        /// <returns>
        /// The <see cref="CountryCode"/> object matching the provided code, or the specified default country code
        /// if the code is not valid or recognized.
        /// </returns>
        public static CountryCode GetOrDefault(string code, CountryCode defaultCountryCode = null)
        {
            if (TryParse(code, out var countryCode))
            {
                return countryCode;
            }

            return defaultCountryCode;
        }

        /// <summary>
        /// Retrieves the country code object corresponding to the provided code. If the code is invalid or not
        /// recognized, the default country code is returned.
        /// </summary>
        /// <param name="alpha2Code">The country alpha2 code to be parsed</param>
        /// <param name="defaultCountryCode">
        /// The default country code to return if the provided code is invalid or not recognized.
        /// If not specified, the default value is null.
        /// </param>
        /// <returns>
        /// The <see cref="CountryCode"/> object matching the provided code, or the specified default country code
        /// if the code is not valid or recognized.
        /// </returns>
        public static CountryCode GetByAlpha2OrDefault(string alpha2Code, CountryCode defaultCountryCode = null)
        {
            if (TryParseAlpha2(alpha2Code, out var countryCode))
            {
                return countryCode;
            }

            return defaultCountryCode;
        }

        /// <summary>
        /// Retrieves the country code object corresponding to the provided code. If the code is invalid or not
        /// recognized, the default country code is returned.
        /// </summary>
        /// <param name="alpha3Code">The country alpha3 code to be parsed</param>
        /// <param name="defaultCountryCode">
        /// The default country code to return if the provided code is invalid or not recognized.
        /// If not specified, the default value is null.
        /// </param>
        /// <returns>
        /// The <see cref="CountryCode"/> object matching the provided code, or the specified default country code
        /// if the code is not valid or recognized.
        /// </returns>
        public static CountryCode GetByAlpha3OrDefault(string alpha3Code, CountryCode defaultCountryCode = null)
        {
            if (TryParseAlpha3(alpha3Code, out var countryCode))
            {
                return countryCode;
            }

            return defaultCountryCode;
        }

        /// <summary>
        /// Retrieves the country code object corresponding to the provided code. If the code is invalid or not
        /// recognized, the default country code is returned.
        /// </summary>
        /// <param name="numeric">The country numeric code to be parsed</param>
        /// <param name="defaultCountryCode">
        /// The default country code to return if the provided code is invalid or not recognized.
        /// If not specified, the default value is null.
        /// </param>
        /// <returns>
        /// The <see cref="CountryCode"/> object matching the provided code, or the specified default country code
        /// if the code is not valid or recognized.
        /// </returns>
        public static CountryCode GetByNumericOrDefault(string numeric, CountryCode defaultCountryCode = null)
        {
            if (TryParseNumeric(numeric, out var countryCode))
            {
                return countryCode;
            }

            return defaultCountryCode;
        }
    }
}