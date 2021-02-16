using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FShop.Web.Models
{
    public class CategoryNotificationViewModel
    {
        [Key]
        public int ID { get; set; }

        public int Status { get; set; }

        public string Description { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Icon { get; set; }

        public virtual IEnumerable<NotificationViewModel> Notifications { get; set; }
    }
}