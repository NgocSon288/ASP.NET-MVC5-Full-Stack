using FShop.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace FShop.Data.FluentConfigurations
{
    public class MemberConfiguration : EntityTypeConfiguration<Member>
    {
        //public MemberConfiguration()
        //{
        //    this.ToTable("Members");

        //    this.HasKey(m => m.ID);

        //    this.Property(m => m.UserName)
        //        .HasMaxLength(100)
        //        .IsRequired();

        //    this.Property(m => m.PassWord)
        //        .HasMaxLength(500)
        //        .IsRequired();

        //    this.Property(m => m.DisplayName)
        //        .HasMaxLength(100)
        //        .IsRequired();

        //    this.Property(m => m.Email)
        //        .HasMaxLength(100)
        //        .IsRequired();

        //    this.Property(m => m.Avatar)
        //        .HasMaxLength(500)
        //        .IsRequired();

        //    this.HasRequired<MemberStatus>(m => m.MemberStatus)
        //        .WithMany(ms => ms.Members)
        //        .HasForeignKey(m => m.MemberStatusID);

        //    this.HasMany<Comment>(m => m.Comments)
        //        .WithRequired(c => c.Member)
        //        .HasForeignKey(c => c.CustomerID);

        //    this.HasMany<Order>(m => m.Orders)
        //        .WithRequired(o => o.Member)
        //        .HasForeignKey(o => o.MemberID);

        //    this.HasMany<MemberNotification>(m => m.MemberNotifications)
        //        .WithRequired(mn => mn.Member)
        //        .HasForeignKey(mn => mn.MemberID);
        //}
    }
}