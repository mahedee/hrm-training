using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class Section
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Section. Code")]
        [StringLength(10)]
        public string SectionCode { get; set; }

        [Display(Name = "Section Name")]
        [StringLength(150)]
        public string SectionName { get; set; }

        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public virtual Dept Dept { get; set; }
    }
}