using System;

namespace FFF.CountryFlags
{
    /// <summary>
    /// Represents the sources for flag images in different formats.
    /// </summary>
    public class FlagSource
    {
        /// <summary>
        /// Gets or sets the URI for the SVG (Scalable Vector Graphics) format of the flag.
        /// SVG is a vector format that can be scaled to any size without loss of quality.
        /// </summary>
        /// <value>The URI pointing to the SVG file.</value>
        public Uri Svg { get; set; }

        /// <summary>
        /// Gets or sets the URI for the PNG (Portable Network Graphics) format of the flag.
        /// PNG is a raster format that provides lossless compression and is suitable for detailed, high-quality images.
        /// </summary>
        /// <value>The URI pointing to the PNG file.</value>
        public Uri Png { get; set; }
    }

}
