using System;
using System.ComponentModel.DataAnnotations;
using Human_Resources_Web_API.Enums;

namespace Human_Resources_Web_API.Models
{
    public class AddEmployeeRequest
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public DateTime BirthDate { get; set; }
        [Required] public Gender Gender { get; set; }
        [Required] public string ContactNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required] public string PayrollInformation { get; set; }
        [Required] public string SocialSecurityNumber { get; set; }
        [Required] public float Salary { get; set; }
    }
}