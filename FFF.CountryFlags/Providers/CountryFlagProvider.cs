using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FFF.CountryFlags.Providers
{
    /// <summary>
    /// Provides functionality to retrieve country flags and raw JSON data for countries.
    /// This class ensures data is loaded efficiently and cached for quick access, optimizing performance in concurrent scenarios.
    /// </summary>
    internal class CountryFlagProvider : ICountryFlagProvider
    {
        // Constant for the data file name.
        private const string DATA = "data.json";
        private const string RESOURCES = "Resources.{0}.{1}.{2}.png";

        // Static JsonSerializerOptions configured for camel case property naming to match JSON data.
        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        // Static reference to the executing assembly to access embedded resources.
        private readonly Assembly _assembly = Assembly.GetExecutingAssembly();

        // Semaphore to control access to initialization task in a thread-safe manner.
        private readonly SemaphoreSlim _initializationSemaphore = new SemaphoreSlim(1, 1);

        // Task to hold the initialization of country flags data, ensuring it's done only once asynchronously.
        private Task<IEnumerable<CountryFlag>> _countryFlagsInitializationTask;

        /// <summary>
        /// Asynchronously retrieves all country flags. If the flags have not been initialized, it initializes them.
        /// This method is thread-safe and ensures that country flags are loaded only once across all requests.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation and contains the country flags.</returns>
        public async Task<IEnumerable<CountryFlag>> GetRawAsync()
        {
            // Check if the initialization task is null and initialize if necessary.
            if (_countryFlagsInitializationTask == null)
            {
                // Wait asynchronously to enter the semaphore.
                await _initializationSemaphore.WaitAsync();
                try
                {
                    // Double-check to avoid initializing more than once.
                    if (_countryFlagsInitializationTask == null)
                        _countryFlagsInitializationTask = InitializeCountryFlagsAsync();
                }
                finally
                {
                    // Release the semaphore regardless of the task's outcome.
                    _initializationSemaphore.Release();
                }
            }
            // Await the initialization task to ensure flags are loaded.
            return await _countryFlagsInitializationTask;
        }

        /// <summary>
        /// Asynchronously retrieves the raw JSON data for country flags.
        /// This method reads from the embedded resource and returns the raw JSON string.
        /// </summary>
        /// <returns>A task that represents the asynchronous read operation and contains the raw JSON data as a string.</returns>
        public async Task<string> GetRawJsonAsync()
        {
            using (var stream = _assembly.GetResourceStream(DATA))
            {
                if (stream == null)
                    throw new FileNotFoundException($"Resource {DATA} not found.");

                using (var reader = new StreamReader(stream, Encoding.UTF8))
                    // Read the entire JSON data as a string asynchronously.
                    return await reader.ReadToEndAsync();
            }
        }

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
        public async Task<byte[]> GetFlagAsync(string flagCode, FlagSize flagSize, FlagStyle style)
        {
            // Construct the resource path using the flag code, style, and size.
            string resourcePath = string.Format(RESOURCES, flagCode, style, (int)flagSize);

            // Ensure proper disposal of the stream after usage.
            using (var stream = _assembly.GetResourceStream(resourcePath))
            {
                // Check if the stream is null and return default if it is.
                if (stream == null)
                    return default;

                // Read the stream asynchronously into a byte array and return it.
                return await stream.AsReadByteAsync();
            }
        }

        /// <summary>
        /// Private helper method to asynchronously load country flags from the embedded JSON data resource.
        /// </summary>
        /// <returns>A task that represents the asynchronous load operation and contains the deserialized country flags.</returns>
        private async Task<IEnumerable<CountryFlag>> InitializeCountryFlagsAsync()
        {
            using (var stream = _assembly.GetResourceStream(DATA))
            {
                if (stream == null)
                    throw new FileNotFoundException($"Resource {DATA} not found.");
                // Deserialize JSON data from stream asynchronously.
                return await JsonSerializer.DeserializeAsync<IEnumerable<CountryFlag>>(stream, _jsonSerializerOptions);
            }
        }
    }
}
