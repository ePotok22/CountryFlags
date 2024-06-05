namespace FFF.CountryFlags
{
    /// <summary>
    /// Represents a language with properties for its ISO codes, English name, and native name.
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Gets or sets the ISO 639-1 code for the language, which is a two-letter code used for language identification.
        /// </summary>
        /// <value>The two-letter ISO 639-1 code.</value>
        public string Iso639_1 { get; set; }

        /// <summary>
        /// Gets or sets the ISO 639-2 code for the language, which is a three-letter code that offers a wider range of language identifiers than ISO 639-1.
        /// </summary>
        /// <value>The three-letter ISO 639-2 code.</value>
        public string Iso639_2 { get; set; }

        /// <summary>
        /// Gets or sets the common name of the language in English.
        /// </summary>
        /// <value>The English name of the language.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the language as it is written in the language itself.
        /// </summary>
        /// <value>The native script or form of the language name.</value>
        public string NativeName { get; set; }
    }
}
