using System;
using Human_Resources_Web_API.Enums;

namespace Human_Resources_Web_API.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public string PayrollInformation { get; set; }
        public string SocialSecurityNumber { get; set; }
        public float Salary { get; set; }

        public EmployeeViewModel Update
        (
            string firstName,
            string lastName,
            DateTime birthDate,
            Gender gender,
            string contactNumber,
            string email,
            string payrollInformation,
            string socialSecurityNumber,
            float salary)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            ContactNumber = contactNumber;
            Email = email;

            PayrollInformation = payrollInformation;
            socialSecurityNumber = socialSecurityNumber;
            Salary = salary;

            return this;
        }
    }
}