using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class MvcEmployeeModel
    {
        public int EmpolyeeId { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string Name { get; set; }
        public string Position { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> Salary { get; set; }

    }
}