using FShop.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace FShop.Data.FluentConfigurations
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        //public CommentConfiguration()
        //{
        //    this.ToTable("Comments");

        //    this.HasKey(c => c.ID);

        //    this.Property(c => c.StarNumber)
        //        .IsRequired();

        //    this.Property(c => c.Reason)
        //        .HasMaxLength(100)
        //        .IsRequired();

        //    this.Property(c => c.Description)
        //        .HasMaxLength(500)
        //        .IsRequired();

        //    this.HasRequired<Member>(c => c.Member)
        //        .WithMany(m => m.Comments)
        //        .HasForeignKey(c => c.CustomerID);

        //    this.HasRequired<Product>(c => c.Product)
        //        .WithMany(p => p.Comments)
        //        .HasForeignKey(c => c.ProductID);
        //}
    }
}