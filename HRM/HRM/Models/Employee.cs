using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Employee Code")]
        [StringLength(10)]
        public string EmployeeCode { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Nick Name")]
        public string NickName { get; set; }

        [Display(Name = "Mobile Number")]
        [StringLength(15)]
        public string MobileNumber { get; set; }

        [Display(Name = "Email")]
        [StringLength(100)]
        public string Email { get; set; }

        [Display(Name = "Father's Name")]
        public string FatherName { get; set; }

        [Display(Name = "Mother's Name")]
        public string MotherName { get; set; }

        public int DesignationId { get; set; }

        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        [Display(Name = "Blood Group")]
        [StringLength(3)]
        public string BloodGroup { get; set; }


        public int DeptId { get; set; }

        [ForeignKey("DeptId")]
        public virtual Dept Dept { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Upload File")]
        public string EmployeePhotoPath { get; set; }

        [NotMapped]
        public HttpPostedFileBase EmployeePhoto { get; set; }
    }
}