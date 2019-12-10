namespace ContactsService.Models
{
    public sealed class SatsangDetails
    {
        public string Center { get; set; }

        public bool IsSatsangiFamily { get; set; }

        public bool IsDoingPooja { get; set; }

        public bool IsDoingTilakChandalo { get; set; }

        public bool IsReadingVMSV { get; set; }

        public SatsangExam LastSatsangExam { get; set; }

        public bool IsAttendingYuvaSabha { get; set; }
    }
}
