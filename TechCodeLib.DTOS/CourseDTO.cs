using System;
using System.Collections.Generic;
using System.Text;

namespace TechCodeLib.DTOS
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EmbedCode { get; set; }
        public List<SectionDTO> Sections { get; set; }
        public string Tags { get; set; }
        public string ContentLevel { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public int LanguageId { get; set; }
        public string Language { get; set; }
        public string Author { get; set; }      
        
        public string Subject { get; set; }
       
        public int Rating { get; set; }
    }

    public class SectionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Duration { get; set; }
        public List<VideoDTO> Videos { get; set; }
        public int? DocumentId { get; set; }
        public DocumentDTO Document { get; set; }
    }

    public class VideoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Length { get; set; }
        public string EmbedLink { get; set; }
        public bool IsActive { get; set; }
        public int Rating { get; set; }
        
        public string Language { get; set; }
    }

    public class DocumentDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string DocUrl { get; set; }
        public string FileType { get; set; }
    }
}
