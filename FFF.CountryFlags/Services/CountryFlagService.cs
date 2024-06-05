using FFF.CountryFlags.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFF.CountryFlags
{
    /// <summary>
    /// Provides services for retrieving and managing country flags, handling flag data via a provider that supports lazy initialization.
    /// </summary>
    public class CountryFlagService : ICountryFlagService
    {
        /// <summary>
        /// File extension for flag images.
        /// </summary>
        private const string EXTENSION = ".png";

        /// <summary>
        /// MIME type for flag images.
        /// </summary>
        private const string MIME = "image/png";

        /// <summary>
        /// Lazy loader for country flag provider to ensure efficient resource usage.
        /// </summary>
        private readonly Lazy<ICountryFlagProvider> _countryFlagProvider;

        /// <summary>
        /// Static default provider for country flags, initialized using a lazy pattern.
        /// </summary>
        public static Lazy<ICountryFlagProvider> DefaultEmailProvider { get; set; } = new Lazy<ICountryFlagProvider>(() => new CountryFlagProvider());

        /// <summary>
        /// Provides access to the country flag provider, ensuring it is initialized on first use.
        /// </summary>
        public ICountryFlagProvider CountryFlagProvider => _countryFlagProvider.Value;

        /// <summary>
        /// Initializes a new instance of the CountryFlagService class using the default provider.
        /// </summary>
        public CountryFlagService() : this(DefaultEmailProvider) { }

        /// <summary>
        /// Initializes a new instance of the CountryFlagService class with a specified Lazy provider.
        /// </summary>
        /// <param name="countryFlagProvider">A Lazy instance of ICountryFlagProvider to be used for fetching flag data.</param>
        public CountryFlagService(Lazy<ICountryFlagProvider> countryFlagProvider)
        {
            if (countryFlagProvider == null)
                throw new ArgumentNullException(nameof(countryFlagProvider));

            _countryFlagProvider = countryFlagProvider;
        }

        /// <summary>
        /// Initializes a new instance of the CountryFlagService class with a factory function for the provider.
        /// </summary>
        /// <param name="countryFlagProviderFactory">A function to create an ICountryFlagProvider instance.</param>
        public CountryFlagService(Func<ICountryFlagProvider> countryFlagProviderFactory)
        {
            if (countryFlagProviderFactory == null)
                throw new ArgumentNullException(nameof(countryFlagProviderFactory));

            _countryFlagProvider = new Lazy<ICountryFlagProvider>(countryFlagProviderFactory);
        }

        /// <summary>
        /// Initializes a new instance of the CountryFlagService class with a direct provider.
        /// </summary>
        /// <param name="countryFlag">An instance of ICountryFlagProvider to be used directly.</param>
        public CountryFlagService(ICountryFlagProvider countryFlag) : this(() => countryFlag)
        {
            if (countryFlag == null)
                throw new ArgumentNullException(nameof(countryFlag));
        }

        /// <summary>
        /// Asynchronously retrieves a list of country flags with their attachments based on specified size and style.
        /// </summary>
        /// <param name="size">The size of the flags to retrieve.</param>
        /// <param name="style">The style of the flags to retrieve.</param>
        /// <returns>A task that when completed will return a list of CountryFlag objects, each potentially containing a flag attachment.</returns>
        public async Task<List<CountryFlag>> GetCountryFlagAsync(FlagSize size, FlagStyle style)
        {
            var countries = await _countryFlagProvider.Value.GetRawAsync();
            var tasks = countries.Select(country => AttachFlagAsync(country, size, style));
            return (await Task.WhenAll(tasks)).ToList();
        }

        /// <summary>
        /// Asynchronously retrieves raw JSON data representing country flags from the provider.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, which, upon completion, returns a string containing the raw JSON data.</returns>
        public async Task<string> GetJsonAsync() =>
            await _countryFlagProvider.Value.GetRawJsonAsync();

        /// <summary>
        /// Asynchronously attaches a flag to a country object based on size and style.
        /// </summary>
        /// <param name="country">The country to which the flag will be attached.</param>
        /// <param name="size">The size of the flag.</param>
        /// <param name="style">The style of the flag.</param>
        /// <returns>The country object with an attached flag, if available.</returns>
        private async Task<CountryFlag> AttachFlagAsync(CountryFlag country, FlagSize size, FlagStyle style)
        {
            var blob = await _countryFlagProvider.Value.GetFlagAsync(country.Alpha2Code, size, style);
            if (blob != null)
            {
                country.AttachFlag = new AttachFlag
                {
                    Blob = blob,
                    Size = ((int)size).ToString(),
                    Style = style.ToString(),
                    Mime = MIME,
                    Extension = EXTENSION,
                };
            }
            return country;
        }
    }
}
