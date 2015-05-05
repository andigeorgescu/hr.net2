using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Personal.Entities
{
    [Table("Employee",Schema="HR")]
    public class Employee
    {
        [Required]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public Job Job { get; set; }
        [Range(0,int.MaxValue)]
        public decimal Salary { get; set; }
        [Range(0,100)]
        public decimal CommisionPercent { get; set; }
        public Employee Manager { get; set; }
        public Department Department { get; set; }
    }
}
