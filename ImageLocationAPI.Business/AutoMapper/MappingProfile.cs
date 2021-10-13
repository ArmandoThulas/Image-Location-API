using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ImageLocationAPI.Data.DataModels;
using ImageLocationAPI.Models.Image;
using ImageLocationAPI.Models.Venue;

namespace ImageLocationAPI.Business.AutoMapper
{
    public class MappingProfile
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VenueModel, Venue>().ReverseMap();
                cfg.CreateMap<venueCategoriesModel, Category>().ReverseMap();
                cfg.CreateMap<VenueModel, Venue>().ReverseMap();
                cfg.CreateMap<VenueLocationModel, Venue>().ReverseMap();
                cfg.CreateMap<ImageModel, Image>().ReverseMap();
            });

            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
