using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechCodeLib.DAL.Entities;
using TechCodeLib.DTOS;

namespace TechCodeLibAPI
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppUserDTO, AppUser>();
            CreateMap<AppUser,AppUserDTO>();
            CreateMap<Section, SectionDTO>();
            CreateMap<Video, VideoDTO>();

            CreateMap<Course, CourseDTO>().ForMember(x => x.Language, opt => opt.MapFrom(src => src.Language.Name))
                .ForMember(x => x.Author, opt => opt.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName))
                .ForMember(x => x.Subject, opt => opt.MapFrom(src => src.Subject.Name))
                .ForMember(x => x.ContentLevel, opt => opt.MapFrom(src => src.ContentLevel.Name))
                .ForMember(x => x.Rating, opt => opt.MapFrom(src => (src.Reviews.Count() != 0) ? src.Reviews.Select(p => p.RatingStar).Average() : 0));

            CreateMap<Course, CourseGridDTO>()
                .ForMember(x => x.Language, opt => opt.MapFrom(src => src.Language.Name))
                .ForMember(x => x.Author, opt => opt.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName))
                .ForMember(x => x.Subject, opt => opt.MapFrom(src => src.Subject.Name))
                .ForMember(x => x.Rating, opt => opt.MapFrom(src => (src.Reviews.Count() != 0)?src.Reviews.Select(p => p.RatingStar).Average(): 0));
        }
    }
}
