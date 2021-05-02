using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpDepTask.Models
{
    public class Department
    {

        [Key]
        public int id { get; set; }

        [Required]
        public string DepName { get; set; }



    }
}
