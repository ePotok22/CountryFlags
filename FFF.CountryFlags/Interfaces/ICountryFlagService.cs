using System.Collections.Generic;
using System.Threading.Tasks;

namespace FFF.CountryFlags
{
    public interface ICountryFlagService
    {
        /// <summary>
        /// Asynchronously retrieves a list of country flags with their attachments based on specified size and style.
        /// </summary>
        /// <param name="size">The size of the flags to retrieve.</param>
        /// <param name="style">The style of the flags to retrieve.</param>
        /// <returns>A task that when completed will return a list of CountryFlag objects, each potentially containing a flag attachment.</returns>
        Task<List<CountryFlag>> GetCountryFlagAsync(FlagSize size, FlagStyle style);

        /// <summary>
        /// Asynchronously retrieves raw JSON data representing country flags from the provider.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, which, upon completion, returns a string containing the raw JSON data.</returns>
        Task<string> GetJsonAsync();
    }
}
