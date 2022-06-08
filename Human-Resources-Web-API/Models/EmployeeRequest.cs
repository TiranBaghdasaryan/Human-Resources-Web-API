using System;
using System.ComponentModel.DataAnnotations;
using Human_Resources_Web_API.Enums;

namespace Human_Resources_Web_API.Models
{
    public class EmployeeRequest
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [DataType(DataType.Date)] [Required] public DateTime BirthDate { get; set; }
        [Required] public Gender Gender { get; set; }
        [Required] public string ContactNumber { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Must be a valid Email Address")]
        public string Email { get; set; }
        [Required] public string PayrollInformation { get; set; }
        [Required] public string SocialSecurityNumber { get; set; }
        [Required] public float Salary { get; set; }
    }
}