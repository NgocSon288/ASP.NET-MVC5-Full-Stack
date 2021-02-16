using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FShop.Web.Models
{
    public class SlideViewModel
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        [Required]
        public string Image { get; set; }

        public bool Status { get; set; }
    }
}