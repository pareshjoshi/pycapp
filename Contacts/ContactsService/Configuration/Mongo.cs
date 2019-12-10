namespace ContactsService.Configuration
{
    public class Mongo
    {
        public const string SectionName = "Mongo";

        public string ConnectionString { get; set; }

        public string Database { get; set; }

        public string ContactsCollection { get; set; }
    }
}
