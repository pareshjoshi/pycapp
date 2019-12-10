namespace ContactsService.Models
{
    /// <summary>
    /// The work details of individual.
    /// </summary>
    public class WorkDetails
    {
        /// <summary>
        /// The name of the most recent organization.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// The most recent position held.
        /// </summary>
        public string Designation { get; set; }

        /// <summary>
        /// Skills or expertise.
        /// </summary>
        public string[] Skills { get; set; }

        /// <summary>
        /// A brief about work experience.
        /// </summary>
        public string Summary { get; set; }
    }
}
