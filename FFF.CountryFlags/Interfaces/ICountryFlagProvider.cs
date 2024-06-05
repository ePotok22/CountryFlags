using System.Collections.Generic;
using System.Threading.Tasks;

namespace FFF.CountryFlags
{
    public interface ICountryFlagProvider
    {
        /// <summary>
        /// Asynchronously retrieves all country flags. If the flags have not been initialized, it initializes them.
        /// This method is thread-safe and ensures that country flags are loaded only once across all requests.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation and contains the country flags.</returns>
        Task<IEnumerable<CountryFlag>> GetRawAsync();

        /// <summary>
        /// Asynchronously retrieves the raw JSON data for country flags.
        /// This method reads from the embedded resource and returns the raw JSON string.
        /// </summary>
        /// <returns>A task that represents the asynchronous read operation and contains the raw JSON data as a string.</returns>
        Task<string> GetRawJsonAsync();

        /// <summary>
        /// Asynchronously retrieves a flag image as a byte array. The image is selected based on the provided flag code, size, and style.
        /// </summary>
        /// <param name="flagCode">The code of the flag to retrieve.</param>
        /// <param name="flagSize">The size category of the flag to retrieve.</param>
        /// <param name="style">The style of the flag to retrieve.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the byte array of the flag image.
        /// If the image is not found, returns null or default(byte[]).
        /// </returns>
        Task<byte[]> GetFlagAsync(string flagCode, FlagSize flagSize, FlagStyle style);
    }
}
