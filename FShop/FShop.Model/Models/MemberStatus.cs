using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("MemberStatuses")]
    public class MemberStatus
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual IEnumerable<Member> Members { get; set; }
    }
}