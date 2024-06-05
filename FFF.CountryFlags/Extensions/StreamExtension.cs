using System.IO;
using System.Threading.Tasks;

namespace FFF.CountryFlags
{
    /// <summary>
    /// Provides extension methods for the Stream class.
    /// </summary>
    internal static class StreamExtension
    {
        /// <summary>
        /// Asynchronously reads all bytes from the given stream and returns a byte array.
        /// </summary>
        /// <param name="input">The stream from which to read.</param>
        /// <returns>A task that represents the asynchronous read operation. The value of the TResult parameter contains a byte array of the data read from the stream.</returns>
        public static async Task<byte[]> AsReadByteAsync(this Stream input)
        {
            // Buffer to hold read data temporarily. Size is set to 16KB.
            byte[] buffer = new byte[16 * 1024];

            // MemoryStream to accumulate the results.
            using (MemoryStream ms = new MemoryStream())
            {
                int read; // Variable to hold the count of bytes read in each iteration.

                // Read from the stream until no more data is available.
                while ((read = await input.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    // Write the data read from the input stream into the MemoryStream.
                    await ms.WriteAsync(buffer, 0, read);

                // Return the accumulated bytes from the MemoryStream as an array.
                return ms.ToArray();
            }
        }
    }
}
