using AutoMapper;
using KittenFactory.Application.Models;
using KittenFactory.Shared.ViewModels;

namespace KittenFactory.Server.Mapper
{
    public class KittenFactoryProfile: Profile
    {
        public KittenFactoryProfile()
        {
            CreateMap<CatModel, CatViewModel>().ReverseMap();
        }
    }
}
