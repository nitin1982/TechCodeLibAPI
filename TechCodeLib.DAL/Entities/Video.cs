using System;
using System.Collections.Generic;
using System.Text;

namespace TechCodeLib.DAL.Entities
{
    public class Video : BaseEntity
    {        
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Length { get; set; }
        public string EmbedLink { get; set; }
        public string Tags { get; set; }
        public int AppUserId { get; set; }
        public AppUser Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public int Rating { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }

    }
}
