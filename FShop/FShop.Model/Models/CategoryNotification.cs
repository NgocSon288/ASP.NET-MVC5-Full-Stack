using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("CategoryNotifications")]
    public class CategoryNotification
    {
        [Key]
        public int ID { get; set; }

        public string Description { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Icon { get; set; }

        public virtual IEnumerable<Notification> Notifications { get; set; }
    }
}