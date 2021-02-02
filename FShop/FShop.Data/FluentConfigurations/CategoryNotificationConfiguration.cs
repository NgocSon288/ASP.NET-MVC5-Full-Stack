using FShop.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace FShop.Data.FluentConfigurations
{
    internal class CategoryNotificationConfiguration : EntityTypeConfiguration<CategoryNotification>
    {
        //public CategoryNotificationConfiguration()
        //{
        //    this.ToTable("CategoryNotifications");

        //    this.HasKey(cn => cn.ID);

        //    this.Property(cn => cn.Status)
        //        .IsRequired();

        //    this.Property(cn => cn.Description)
        //        .HasMaxLength(500)
        //        .IsRequired();

        //    this.Property(cn => cn.Color)
        //        .HasMaxLength(50)
        //        .IsRequired();

        //    this.Property(cn => cn.Icon)
        //        .HasMaxLength(50)
        //        .IsRequired();

        //    this.HasMany<Notification>(cn => cn.Notifications)
        //        .WithRequired(n => n.CategoryNotification)
        //        .HasForeignKey(n => n.CategoryNotificationID);
        //}
    }
}