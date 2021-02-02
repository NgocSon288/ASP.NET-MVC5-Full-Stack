using FShop.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace FShop.Data.FluentConfigurations
{
    public class AdvertisementConfiguration : EntityTypeConfiguration<Advertisement>
    {
        //public AdvertisementConfiguration()
        //{
        //    this.ToTable("Advertisements");

        //    this.HasKey(p => p.ID);

        //    this.Property(p => p.Name)
        //        .HasMaxLength(100)
        //        .IsRequired();

        //    this.Property(p => p.Description)
        //        .HasMaxLength(500)
        //        .IsRequired();

        //    this.Property(p => p.Image)
        //        .HasMaxLength(500)
        //        .IsRequired();

        //    this.Property(p => p.URL)
        //        .HasMaxLength(250)
        //        .IsRequired();
        //}
    }
}