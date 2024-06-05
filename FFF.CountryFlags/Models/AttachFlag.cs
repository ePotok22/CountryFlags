namespace FFF.CountryFlags
{
    /// <summary>
    /// Represents the data and attributes of a flag attachment.
    /// </summary>
    public class AttachFlag
    {
        /// <summary>
        /// Gets or sets the binary data of the flag attachment.
        /// </summary>
        /// <value>The binary data represented as a byte array.</value>
        public byte[] Blob { get; set; }

        /// <summary>
        /// Gets or sets the style of the flag, which could describe visual characteristics like 'waving', 'flat', or 'shiny'.
        /// </summary>
        /// <value>The style of the flag as a string.</value>
        public string Style { get; set; }

        /// <summary>
        /// Gets or sets the size of the flag, typically describing dimensions or scale.
        /// </summary>
        /// <value>The size of the flag as a string, which might include specific dimensions or a size category.</value>
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the MIME type of the flag attachment, indicating the file format.
        /// </summary>
        /// <value>The MIME type as a string, such as 'image/png' or 'image/jpeg'.</value>
        public string Mime { get; set; }

        /// <summary>
        /// Gets or sets the file extension for the flag attachment.
        /// </summary>
        /// <value>The file extension as a string, such as '.png' or '.jpg'.</value>
        public string Extension { get; set; }
    }
}
