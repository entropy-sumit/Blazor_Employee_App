using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.Model
{
    public class EmployeeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ProfileImg { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Notes { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public string Salary { get; set; }

    }
}
