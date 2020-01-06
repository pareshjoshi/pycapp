namespace ContactsService.Configuration
{
    /// <summary>
    /// MongoDB configuration.
    /// </summary>
    public class Mongo
    {
        /// <summary>
        /// Configuration section.
        /// </summary>
        public const string SectionName = "Mongo";

        /// <summary>
        /// Connection string.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Database name.
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// Name of the contacts collection.
        /// </summary>
        public string ContactsCollection { get; set; }
    }
}
