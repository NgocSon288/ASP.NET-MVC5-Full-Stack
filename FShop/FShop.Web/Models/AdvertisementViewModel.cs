using System.ComponentModel.DataAnnotations;

namespace FShop.Web.Models
{
    public class AdvertisementViewModel
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string URL { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? Status { get; set; }
    }
}