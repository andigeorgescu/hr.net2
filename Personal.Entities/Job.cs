using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Personal.Entities
{
    [Table("Job",Schema="HR")]
    public class Job
    {
        [Required]
        public string JobId { get; set; }
        public string JobTitle { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
    }
}
