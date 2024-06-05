using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace FFF.CountryFlags
{
    internal static class AssemblyExtension
    {
        /// <summary>
        /// Reads the embedded resource as a string from the assembly.
        /// </summary>
        /// <param name="assembly">The assembly containing the embedded resource.</param>
        /// <param name="name">The name of the embedded resource.</param>
        /// <returns>The content of the embedded resource as a string, or null if the resource cannot be found.</returns>
        public static string GetResourceString(this Assembly assembly, string name)
        {
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            // Utilizes GetResourceStream to abstract the fetching of the resource stream.
            using (Stream stream = assembly.GetResourceStream(name))
            {
                // If no stream is found, return null.
                if (stream == null)
                    return null;
                // Using StreamReader to read the stream's content into a string.
                // Encoding.UTF8 is explicitly specified to ensure correct character decoding.
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Gets the stream of an embedded resource from the assembly.
        /// </summary>
        /// <param name="assembly">The assembly containing the embedded resource.</param>
        /// <param name="name">The name of the embedded resource.</param>
        /// <returns>The stream of the embedded resource, or null if the resource cannot be found.</returns>
        public static Stream GetResourceStream(this Assembly assembly, string name)
        {
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            // Directly retrieving the assembly name and constructing the full resource name.
            string assemblyName = assembly.GetName().Name;
            // Attempting to get the manifest resource stream using the constructed name.
            return assembly.GetManifestResourceStream($"{assemblyName}.{name}");
        }
    }
}
