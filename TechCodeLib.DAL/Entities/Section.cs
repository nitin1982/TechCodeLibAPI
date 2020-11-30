using System;
using System.Collections.Generic;
using System.Text;

namespace TechCodeLib.DAL.Entities
{
    public class Section : BaseEntity
    {        
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Duration { get; set; }
        public List<Video> Videos { get; set; }
        public int? DocumentId { get; set; }
        public Document Document { get; set; }

        public int? CourseId { get; set; }
        public Course Course { get; set; }

    }
}
