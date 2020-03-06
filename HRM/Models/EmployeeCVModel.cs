using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PagedList;

namespace HRM.Models
{
    public class EmployeeCVModel
    {
        public string EmpID { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Enter Last Name")]
        public string VLastName { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Enter First Name")]
        public string VFirstName { get; set; } = "";

        public string NickName { get; set; }

        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Enter DOB")]
        public string DOB { get; set; }

        [Required(ErrorMessage = "Enter Gender")]
        public string Gender { get; set; }

        public string Email { get; set; }

        [Display(Name = "Search For:")]
        public string searchtxt { get; set; }

        //public IEnumerable<EmployeeCVModel> ShowallEmployee { get; set; }
        
    }
}