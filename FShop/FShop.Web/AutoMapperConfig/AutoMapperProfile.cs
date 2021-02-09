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

            // CategoryNotify

            // Comment

            // ImportBill

            // ImportBillDetail

            // Member
            CreateMap<Member, MemberSession>();
            CreateMap<Member, MemberViewModel>();
            CreateMap<MemberViewModel, Member>();

            // MemberNotification

            // MemberStatus

            // Notification

            // Order

            // OrderDetail

            // OrderStatus

            // PaymentMethod

            // Product

            // ProductCategory

            // Slide

            // Supplier
        }
    }
}