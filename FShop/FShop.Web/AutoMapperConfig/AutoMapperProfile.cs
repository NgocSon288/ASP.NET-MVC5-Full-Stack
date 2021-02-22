using AutoMapper;
using FShop.Common.ModelSession;
using FShop.Model.Models;
using FShop.Web.Models;

namespace FShop.Web.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Advertisement
            CreateMap<Advertisement, AdvertisementViewModel>()
                .ForMember(model => model.Description,
                    map => map.MapFrom(p => p.Description))
                .ForMember(model => model.URL,
                    map => map.MapFrom(p => p.URL));
            CreateMap<AdvertisementViewModel, Advertisement>();

            // Brand
            CreateMap<Brand, BrandViewModel>();
            CreateMap<BrandViewModel, Brand>();

            // CategoryMember
            CreateMap<CategoryMember, CategoryMemberViewModel>();
            CreateMap<CategoryMemberViewModel, CategoryMember>();

            // CategoryNotify
            CreateMap<CategoryNotification, CategoryNotificationViewModel>();
            CreateMap<CategoryNotificationViewModel, CategoryNotification>();

            // Comment
            CreateMap<Comment, CommentViewModel>();
            CreateMap<CommentViewModel, Comment>();

            // ImportBill
            CreateMap<ImportBill, ImportBillViewModel>();
            CreateMap<ImportBillViewModel, ImportBill>();

            // ImportBillDetail
            CreateMap<ImportBillDetail, ImportBillDetailViewModel>();
            CreateMap<ImportBillDetailViewModel, ImportBillDetail>();

            // Member
            CreateMap<Member, MemberSession>();
            CreateMap<Member, MemberViewModel>();
            CreateMap<MemberViewModel, Member>();
            CreateMap<Member, MemberUpdateInputViewModel>();
            CreateMap<MemberUpdateInputViewModel, Member>()
                .ForMember(model => model.PassWord,
                    map => map.MapFrom(p => p.NewPassWord));

            // MemberNotification
            CreateMap<MemberNotification, MemberNotificationViewModel>();
            CreateMap<MemberNotificationViewModel, MemberNotification>();

            // MemberStatus
            CreateMap<MemberStatus, MemberStatusViewModel>();
            CreateMap<MemberStatusViewModel, MemberStatus>();

            // Notification
            CreateMap<Notification, NotificationViewModel>();
            CreateMap<NotificationViewModel, Notification>();

            // Order
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderViewModel, Order>();

            // OrderDetail
            CreateMap<OrderDetail, OrderDetailViewModel>();
            CreateMap<OrderDetailViewModel, OrderDetail>();

            // OrderStatus
            CreateMap<OrderStatus, OrderStatusViewModel>();
            CreateMap<OrderStatusViewModel, OrderStatus>();

            // PaymentMethod
            CreateMap<PaymentMethod, PaymentMethodViewModel>();
            CreateMap<PaymentMethodViewModel, PaymentMethod>();

            // PermissionCategoryMember
            CreateMap<PermissionCategoryMember, PermissionCategoryMember>();
            CreateMap<PermissionCategoryMember, PermissionCategoryMember>();

            // Permission
            CreateMap<Permission, PermissionViewModel>();
            CreateMap<PermissionViewModel, Permission>();

            // Product
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();

            // ProductCategory
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductCategoryViewModel, ProductCategory>();

            // Slide
            CreateMap<Slide, SlideViewModel>();
            CreateMap<SlideViewModel, Slide>();

            // Supplier
            CreateMap<Supplier, SupplierViewModel>();
            CreateMap<SupplierViewModel, Supplier>();

        }
    }
}