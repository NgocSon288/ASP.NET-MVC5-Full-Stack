using FShop.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("MemberNotifications")]
    public class MemberNotification : Auditable
    {
        [Key]
        public int ID { get; set; }

        public int MemberID { get; set; }

        public int NotificationID { get; set; }

        [ForeignKey("MemberID")]
        public virtual Member Member { get; set; }

        [ForeignKey("NotificationID")]
        public virtual Notification Notification { get; set; }
    }
}