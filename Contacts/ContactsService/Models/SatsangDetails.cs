namespace ContactsService.Models
{
    /// <summary>
    /// Satsang details of the contact.
    /// </summary>
    public sealed class SatsangDetails
    {
        /// <summary>
        /// Center to which this contact is associated with.
        /// </summary>
        public string Center { get; set; }

        /// <summary>
        /// Whether family is satsangi.
        /// </summary>
        public bool IsSatsangiFamily { get; set; }

        /// <summary>
        /// Whether doing pooja daily.
        /// </summary>
        public bool IsDoingPooja { get; set; }

        /// <summary>
        /// Whether wearing tilak chandalo daily.
        /// </summary>
        public bool IsDoingTilakChandalo { get; set; }

        /// <summary>
        /// Whether reading Vachanamrut or Swami Ni Vaato.
        /// </summary>
        public bool IsReadingVMSV { get; set; }

        /// <summary>
        /// Last satsang exam appeared for.
        /// </summary>
        public SatsangExam LastSatsangExam { get; set; }

        /// <summary>
        /// Whether attending youth assemblies regularly.
        /// </summary>
        public bool IsAttendingYuvaSabha { get; set; }
    }
}
