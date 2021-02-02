using AutoMapper;
using FShop.Model.Models;
using FShop.Web.Models;

namespace FShop.Web.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Advertisement, AdvertisementViewModel>()
                .ForMember(model => model.Description,
                    map => map.MapFrom(p => p.Description + " XXX AAA"))
                .ForMember(model => model.URL,
                    map => map.MapFrom(p => "localhost://" + p.URL));
        }
    }
}