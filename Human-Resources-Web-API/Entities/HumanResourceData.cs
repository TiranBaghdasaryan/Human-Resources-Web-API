using System.ComponentModel.DataAnnotations;

namespace Human_Resources_Web_API.Entities
{
    public class HumanResourceData
    {
        [Key] public int EmployeeId { get; set; }
        public string PayrollInformation { get; set; }
        public string SocialSecurityNumber { get; set; }
        public float Salary { get; set; }
        public Employee Employee { get; set; }
    }
}