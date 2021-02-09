using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FShop.Web.Models
{
    public class MemberStatusViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public string Description { get; set; }
    }
}