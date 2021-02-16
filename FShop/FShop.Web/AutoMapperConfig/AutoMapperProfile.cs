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
                    map => map.MapFrom(p => p.Description + " XXX AAA"))
                .ForMember(model => model.URL,
                    map => map.MapFrom(p => "localhost://" + p.URL));

            // Brand
            CreateMap<Brand, BrandViewModel>();

            // CategoryNotify
            CreateMap<CategoryNotification, CategoryNotificationViewModel>();

            // Comment
            CreateMap<Comment, CommentViewModel>();

            // ImportBill
            CreateMap<ImportBill, ImportBillViewModel>();

            // ImportBillDetail
            CreateMap<ImportBillDetail, ImportBillDetailViewModel>();

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

            // MemberStatus
            CreateMap<MemberStatus, MemberStatusViewModel>();

            // Notification
            CreateMap<Notification, NotificationViewModel>();

            // Order
            CreateMap<Order, OrderViewModel>();

            // OrderDetail
            CreateMap<OrderDetail, OrderDetailViewModel>();

            // OrderStatus
            CreateMap<OrderStatus, OrderStatusViewModel>();

            // PaymentMethod
            CreateMap<PaymentMethod, PaymentMethodViewModel>();

            // Product
            CreateMap<Product, ProductViewModel>();

            // ProductCategory
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductCategoryViewModel, ProductCategory>();

            // Slide
            CreateMap<Slide, SlideViewModel>();

            // Supplier
            CreateMap<Supplier, SupplierViewModel>();

        }
    }
}