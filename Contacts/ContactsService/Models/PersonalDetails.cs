namespace ContactsService.Models
{
    using System;

    public sealed class PersonalDetails
    {
        public string FullName { get; set; }

        public DateTime Birthdate { get; set; }

        public string Mobile1 { get; set; }

        public string Mobile2 { get; set; }

        public string MotherTongue { get; set; }

        public string Email { get; set; }

        public string CurrentAddress { get; set; }

        public string PermanantAddress { get; set; }

        public string ProfilePicture { get; set; }

        public string[] Hobbies { get; set; }
    }
}
