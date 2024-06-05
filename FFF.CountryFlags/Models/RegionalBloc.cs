namespace FFF.CountryFlags
{
    /// <summary>
    /// Represents a regional bloc or group of nations, detailing its acronym, name, and other identifiers.
    /// </summary>
    public class RegionalBloc
    {
        /// <summary>
        /// Gets or sets the primary acronym used to identify the regional bloc.
        /// </summary>
        /// <value>The main acronym of the regional bloc, such as 'EU' for European Union.</value>
        public string Acronym { get; set; }

        /// <summary>
        /// Gets or sets the formal name of the regional bloc.
        /// </summary>
        /// <value>The full name of the bloc, such as 'European Union'.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets an array of alternative acronyms that the regional bloc might also be known by.
        /// </summary>
        /// <value>An array of alternative or less common acronyms.</value>
        public string[] OtherAcronyms { get; set; }

        /// <summary>
        /// Gets or sets an array of other names by which the regional bloc might be referred.
        /// </summary>
        /// <value>An array of alternative or unofficial names.</value>
        public string[] OtherNames { get; set; }
    }

}
