namespace ContactsService.Models
{
    using System;

    /// <summary>
    /// Personal details of the contact.
    /// </summary>
    public sealed class PersonalDetails
    {
        /// <summary>
        /// Full name of the contact.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Birthdate of the contact.
        /// </summary>
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// Primary mobile number of the contact.
        /// </summary>
        public string Mobile1 { get; set; }

        /// <summary>
        /// Secondary mobile number of the contact.
        /// </summary>
        public string Mobile2 { get; set; }

        /// <summary>
        /// Mother toungue spoken by the contact.
        /// </summary>
        public string MotherTongue { get; set; }

        /// <summary>
        /// Personal email address of the contact.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Current postal address.
        /// </summary>
        public string CurrentAddress { get; set; }

        /// <summary>
        /// Permanant postal address.
        /// </summary>
        public string PermanantAddress { get; set; }

        /// <summary>
        /// Url to the profile picture.
        /// </summary>
        public string ProfilePicture { get; set; }

        /// <summary>
        /// Hobbies.
        /// </summary>
        public string[] Hobbies { get; set; }
    }
}
