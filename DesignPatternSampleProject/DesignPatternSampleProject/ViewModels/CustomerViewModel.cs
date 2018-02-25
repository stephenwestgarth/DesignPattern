using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DesignPatternSampleProject.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }
        [MaxLength(50)]
        public string Address1 { get; set; }
        [MaxLength(50)]
        public string Address2 { get; set; }
        [MaxLength(50)]
        public string Address3 { get; set; }
        [MaxLength(50)]
        public string Address4 { get; set; }
        [MaxLength(50)]
        public string PostCode { get; set; }
       
    }
}