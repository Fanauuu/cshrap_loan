using System;

namespace WinFormsApp1.Models
{
    public class Customer
    {
        public int CID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string? PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CurrentAddress { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public string FullName => $"{FirstName} {LastName}".Trim();
        public int Age => DateTime.Now.Year - DateOfBirth.Year - (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);
    }
}
