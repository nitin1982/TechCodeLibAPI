using System;
using System.Collections.Generic;
using System.Text;

namespace TechCodeLib.DTOS
{
    public class CourseGridDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }
        public string Language { get; set; }
        public string Subject { get; set; }
        public decimal CourseDuration { get; set; }
        public int Rating { get; set; }

    }
}
