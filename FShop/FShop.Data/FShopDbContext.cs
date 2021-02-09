using FShop.Data.FluentConfigurations;
using FShop.Model.Models;
using System.Data.Entity;

namespace FShop.Data
{
    public class FShopDbContext : DbContext
    {
        public FShopDbContext() : base("FShopConnection")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Advertisement> Advertisements { set; get; }
        public DbSet<Brand> Brands { set; get; }
        public DbSet<CategoryNotification> CategoryNotifications { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public DbSet<ImportBill> ImportBills { set; get; }
        public DbSet<ImportBillDetail> ImportBillDetails { set; get; }
        public DbSet<Member> Members { set; get; }
        public DbSet<MemberNotification> MemberNotifications { set; get; }
        public DbSet<MemberStatus> MemberStatuses { set; get; }
        public DbSet<Notification> Notifications { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<OrderStatus> OrderStatuses { set; get; }
        public DbSet<PaymentMethod> PaymentMethods { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductCategory> ProductCategory { set; get; }
        public DbSet<Slide> Slides { set; get; }
        public DbSet<Supplier> Suppliers { set; get; }

        public static FShopDbContext Create()
        {
            return new FShopDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            // Move Fluent API Configurations to a Separate Class in Entity Framework
            // builder.Configurations.Add(new AdvertisementConfiguration());
            // builder.Configurations.Add(new CategoryNotificationConfiguration());
        }
    }
}