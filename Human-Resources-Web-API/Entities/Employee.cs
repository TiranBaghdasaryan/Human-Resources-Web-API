using System;
using System.ComponentModel.DataAnnotations;
using Human_Resources_Web_API.Enums;

namespace Human_Resources_Web_API.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)] public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public HumanResourceData HumanResourceData { get; set; }


        public void UpdateEmployee
        (
            string firstName,
            string lastName,
            DateTime birthDate,
            Gender gender,
            string contactNumber,
            string email
        )
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            ContactNumber = contactNumber;
            Email = email;
        }


        public void UpdateHumanResourceData(string payrollInformation, string socialSecurityNumber, float salary)
        {
            HumanResourceData.PayrollInformation = payrollInformation;
            HumanResourceData.SocialSecurityNumber = socialSecurityNumber;
            HumanResourceData.Salary = salary;
        }
    }
}