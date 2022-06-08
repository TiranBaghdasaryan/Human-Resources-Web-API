using System;
using System.ComponentModel.DataAnnotations;
using Human_Resources_Web_API.Enums;

namespace Human_Resources_Web_API.Entities
{
    public class EmployeeLeft
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)] public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public string PayrollInformation { get; set; }
        public string SocialSecurityNumber { get; set; }
        public float Salary { get; set; }

        [DataType(DataType.Date)] public DateTime DateLeft { get; set; }


        public EmployeeLeft
        (
            string firstName,
            string lastName,
            DateTime birthDate,
            Gender gender,
            string contactNumber,
            string email,
            string payrollInformation,
            string socialSecurityNumber,
            float salary
        )
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            ContactNumber = contactNumber;
            Email = email;
            PayrollInformation = payrollInformation;
            SocialSecurityNumber = socialSecurityNumber;
            Salary = salary;
            DateLeft = DateTime.Now.Date;
        }
    }
}