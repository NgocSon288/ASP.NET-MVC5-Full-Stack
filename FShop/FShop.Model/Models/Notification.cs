﻿using FShop.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("Notifications")]
    public class Notification : Auditable
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Tiêu đề")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "{0} phải từ {2} đến {1} ký tự")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Mô tả")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "{0} phải từ {2} đến {1} ký tự")]
        public string Description { get; set; }

        public int CategoryNotificationID { get; set; }

        [ForeignKey("CategoryNotificationID")]
        public CategoryNotification CategoryNotification { get; set; }

        public virtual IEnumerable<MemberNotification> MemberNotifications { get; set; }
    }
}