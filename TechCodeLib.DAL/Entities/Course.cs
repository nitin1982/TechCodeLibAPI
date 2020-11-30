using System;
using System.Collections.Generic;
using System.Text;

namespace TechCodeLib.DAL.Entities
{
    public class Course : BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }        
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Section> Sections { get; set; }
        public string Tags { get; set; }
        public int ContentLevelId { get; set; }
        public ContentLevel ContentLevel { get; set; }
        public int AppUserId { get; set; }
        public AppUser Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public decimal CourseDuration { get; set; }


    }

}
