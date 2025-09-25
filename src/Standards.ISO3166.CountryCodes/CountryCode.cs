namespace Standards.ISO3166.CountryCodes
{
    public partial class CountryCode
    {
        public CountryCode(string alpha2, string alpha3, int numeric, string name)
        {
            Alpha2 = alpha2;
            Alpha3 = alpha3;

            Numeric = numeric;
            Name = name;
        }

        public string Alpha2 { get; }

        public string Alpha3 { get; }

        public int Numeric { get; }

        public string Name { get; }

        public override string ToString()
        {
            return $"{Alpha2}, {Alpha3}, {Numeric:000}, {Name}";
        }

        public override bool Equals(object obj)
        {
            if (obj is CountryCode other)
            {
                return Alpha2 == other.Alpha2;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Alpha2.GetHashCode();
        }
    }
}