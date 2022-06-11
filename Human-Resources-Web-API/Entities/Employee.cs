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

    }
}