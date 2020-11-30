using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechCodeLib.DTOS;

namespace TechCodeLib.Services.Contract
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDTO>> GetAllCoursesDTOs();
        Task<IEnumerable<CourseGridDTO>> GetAllDisplayCoursesDTOs();

        Task<CourseDTO> GetCourseById(int id);
    }
}
