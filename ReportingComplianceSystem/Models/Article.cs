using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReportingComplianceSystem.Models
{
    [Table("pArticle")]
    public class pArticle
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string ArticleName { get; set; }
    }
}