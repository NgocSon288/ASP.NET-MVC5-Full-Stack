using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Web.Models
{
    public class MemberNotificationViewModel
    {
        [Key]
        public int ID { get; set; }

        public int MemberID { get; set; }

        public int NotificationID { get; set; }

        [ForeignKey("MemberID")]
        public virtual MemberViewModel Member { get; set; }

        [ForeignKey("NotificationID")]
        public virtual NotificationViewModel Notification { get; set; }
    }
}