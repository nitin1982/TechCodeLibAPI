using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCodeLib.DTOS;
using TechCodeLib.Services.Contract;

namespace TechCodeLibAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public async Task<IActionResult> GetCourses()
        {
            return Ok(await _courseService.GetAllDisplayCoursesDTOs());
        }

        [Route("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            return Ok(await _courseService.GetCourseById(id));
        }

        //   CQRS
        //ReadOnly - Differnt DTO
          //  Update, Delete, Create - Different DTO
    }
}
