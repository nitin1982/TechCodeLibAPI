using System;
using System.Collections.Generic;
using System.Text;

namespace TechCodeLib.DAL.Entities
{
    public class Review : BaseEntity
    {        
        public int RatingStar { get; set; }
        public string Comments { get; set; }
        public int? AppUserId { get; set; }
        public AppUser Reviewer { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
