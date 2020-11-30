using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechCodeLib.DAL.Entities;
using TechCodeLib.DTOS;
using TechCodeLib.Repositories;
using TechCodeLib.Services.Contract;

namespace TechCodeLib.Services
{
    public class CourseService : ICourseService
    {
        private readonly TechCodeLibUoW _uow; 
        private readonly IMapper _mapper;

        public CourseService(TechCodeLibUoW uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CourseDTO>> GetAllCoursesDTOs()
        {
            var result = await _uow.CourseRepository.GetAllAsync();
            return result.Select(x => _mapper.Map<Course, CourseDTO>(x)).ToList();
        }

        public async Task<IEnumerable<CourseGridDTO>> GetAllDisplayCoursesDTOs()
        {
            var result = await (_uow.CourseRepository.GetWithInclude(x => x.IsActive == true, "Language", "ContentLevel", "Author", "Reviews", "Subject")).ToListAsync();

            return result.Select(x => _mapper.Map<Course, CourseGridDTO>(x)).ToList();
        }

        public async Task<CourseDTO> GetCourseById(int id)
        {
            CourseDTO courseDTO = null;
            //var course = await(_uow.CourseRepository.GetWithInclude(x => x.IsActive == true && x.Id == id, "Sections","Language", "ContentLevel", "Author", "Reviews", "Subject")).FirstOrDefaultAsync();

            //if (course != null)
            //    courseDTO = _mapper.Map<Course, CourseDTO>(course);

            //foreach (var item in courseDTO.Sections)
            //{
            //    var sectionvideos = await (_uow.SectionVideoRepository.GetWithInclude(x => x.SectionId == item.Id, "Video")).ToListAsync();
            //    item.Videos = sectionvideos.Select(x => x.Video).Select(x => _mapper.Map<Video, VideoDTO>(x)).ToList();
            //}

            //courseDTO.Sections = course.Sections.Select(x => _mapper.Map<Section, SectionDTO>(x)).ToList();


            var course = await _uow.CourseRepository.GetQueryable()                
                .Include(x => x.Sections)
                    .ThenInclude(sec => sec.Videos)
                .Include(x => x.Language)
                .Include(x => x.ContentLevel)
                .Include(x => x.Author)
                .Include(x => x.Subject)
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);

            if (course != null)
                courseDTO = _mapper.Map<Course, CourseDTO>(course);

            return courseDTO;
        }
    }
}
