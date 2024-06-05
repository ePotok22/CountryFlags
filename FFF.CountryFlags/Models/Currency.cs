namespace FFF.CountryFlags
{
    /// <summary>
    /// Represents a currency with its standard attributes.
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Gets or sets the currency code. This is typically a three-letter code defined by ISO 4217,
        /// such as "USD" for US Dollar or "EUR" for Euro.
        /// </summary>
        /// <value>The international standard currency code.</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the full name of the currency, such as "United States Dollar" or "Euro".
        /// </summary>
        /// <value>The descriptive name of the currency.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the symbol used to denote the currency, such as "$" for US Dollar or "€" for Euro.
        /// </summary>
        /// <value>The graphical symbol or character representing the currency.</value>
        public string Symbol { get; set; }
    }
}
