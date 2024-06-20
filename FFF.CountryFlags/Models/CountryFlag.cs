namespace FFF.CountryFlags
{
    /// <summary>
    /// Represents detailed information about a country, including its flag, demographic, and geographical data.
    /// </summary>
    public class CountryFlag
    {
        /// <summary>
        /// Gets or sets the common name of the country.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the top-level domain(s) for the country.
        /// </summary>
        public string[] TopLevelDomain { get; set; }

        /// <summary>
        /// Gets or sets the two-letter ISO 3166-1 alpha-2 code for the country.
        /// </summary>
        public string Alpha2Code { get; set; }

        /// <summary>
        /// Gets or sets the three-letter ISO 3166-1 alpha-3 code for the country.
        /// </summary>
        public string Alpha3Code { get; set; }

        /// <summary>
        /// Gets or sets the calling codes for the country.
        /// </summary>
        public string[] CallingCodes { get; set; }

        /// <summary>
        /// Gets or sets the area codes for the country.
        /// </summary>
        public string[] AreaCodes { get; set; }

        /// <summary>
        /// Gets or sets the capital city of the country.
        /// </summary>
        public string Capital { get; set; }

        /// <summary>
        /// Gets or sets alternative spellings of the country's name.
        /// </summary>
        public string[] AltSpellings { get; set; }

        /// <summary>
        /// Gets or sets the subregion to which the country belongs.
        /// </summary>
        public string Subregion { get; set; }

        /// <summary>
        /// Gets or sets the region to which the country belongs.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the population of the country.
        /// </summary>
        public long? Population { get; set; }

        /// <summary>
        /// Gets or sets the latitude and longitude of the country.
        /// </summary>
        public double[] LatLng { get; set; }

        /// <summary>
        /// Gets or sets the demonym of the country.
        /// </summary>
        public string Demonym { get; set; }

        /// <summary>
        /// Gets or sets the total land area of the country in square kilometers.
        /// </summary>
        public double? Area { get; set; }

        /// <summary>
        /// Gets or sets the Gini coefficient of the country, which measures income inequality.
        /// </summary>
        public double? Gini { get; set; }

        /// <summary>
        /// Gets or sets the time zones applicable in the country.
        /// </summary>
        public string[] Timezones { get; set; }

        /// <summary>
        /// Gets or sets the ISO codes of countries that share a border with this country.
        /// </summary>
        public string[] Borders { get; set; }

        /// <summary>
        /// Gets or sets the native name of the country.
        /// </summary>
        public string NativeName { get; set; }

        /// <summary>
        /// Gets or sets the numeric ISO code of the country.
        /// </summary>
        public string NumericCode { get; set; }

        /// <summary>
        /// Gets or sets the source URLs for the country's flag in different formats.
        /// </summary>
        public FlagSource FlagSource { get; set; }

        /// <summary>
        /// Gets or sets additional flag attachment details, potentially including style or size.
        /// </summary>
        public AttachFlag AttachFlag { get; set; }

        /// <summary>
        /// Gets or sets the URL of the flag image.
        /// </summary>
        public string Flag { get; set; }

        /// <summary>
        /// Gets or sets the currencies used in the country.
        /// </summary>
        public Currency[] Currencies { get; set; }

        /// <summary>
        /// Gets or sets the languages spoken in the country.
        /// </summary>
        public Language[] Languages { get; set; }

        /// <summary>
        /// Gets or sets translations of the country's name into various languages.
        /// </summary>
        public Translation Translations { get; set; }

        /// <summary>
        /// Gets or sets the regional blocs to which the country belongs.
        /// </summary>
        public RegionalBloc[] RegionalBlocs { get; set; }

        /// <summary>
        /// Gets or sets the International Olympic Committee (IOC) code for the country.
        /// </summary>
        public string Cioc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the country is recognized as an independent nation.
        /// </summary>
        public bool Independent { get; set; }
    }
}
