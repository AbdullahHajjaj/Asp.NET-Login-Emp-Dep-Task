using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpDepTask.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public string EmpNum { get; set; }

        public string PhoneNumber { get; set; }

        [ForeignKey("Department")]
        public int DepId { get; set; }
        public Department Department { get; set; }
    }
}
