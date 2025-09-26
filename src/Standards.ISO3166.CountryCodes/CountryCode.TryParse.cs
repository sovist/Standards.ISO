using System.Collections.Generic;

namespace Standards.ISO3166.CountryCodes
{
    public partial class CountryCode
    {
        /// <summary>
        /// Try to parse a country code (alpha2 or alpha3 or numeric).
        /// </summary>
        /// <param name="code">The country code.</param>
        /// <param name="countryCode">The parsed country code.</param>
        public static bool TryParse(string code, out CountryCode countryCode)
        {
            return TryParseAlpha2(code, out countryCode) ||
                   TryParseAlpha3(code, out countryCode) ||
                   TryParseNumeric(code, out countryCode);
        }

        /// <summary>
        /// Try to parse an alpha2 country code.
        /// </summary>
        /// <param name="alpha2Code">The alpha2 country code.</param>
        /// <param name="countryCode">The parsed country code.</param>
        public static bool TryParseAlpha2(string alpha2Code, out CountryCode countryCode)
        {
            return TryParseString(IndexByAlpha2, alpha2Code, out countryCode);
        }

        /// <summary>
        /// Try to parse an alpha3 country code.
        /// </summary>
        /// <param name="alpha3Code">The alpha3 country code.</param>
        /// <param name="countryCode">The parsed country code.</param>
        public static bool TryParseAlpha3(string alpha3Code, out CountryCode countryCode)
        {
            return TryParseString(IndexByAlpha3, alpha3Code, out countryCode);
        }

        private static bool TryParseString(IReadOnlyDictionary<string, CountryCode> index, string code, out CountryCode countryCode)
        {
            countryCode = null;

            code = code?.Trim();

            if (string.IsNullOrEmpty(code))
            {
                return false;
            }

            return index.TryGetValue(code, out countryCode);
        }

        /// <summary>
        /// Try to parse a numeric country code.
        /// </summary>
        /// <param name="numeric">The numeric country code.</param>
        /// <param name="countryCode">The parsed country code.</param>
        public static bool TryParseNumeric(string numeric, out CountryCode countryCode)
        {
            countryCode = null;

            if (!int.TryParse(numeric, out var numericNumber))
            {
                return false;
            }

            return IndexByNumeric.TryGetValue(numericNumber, out countryCode);
        }
    }
}