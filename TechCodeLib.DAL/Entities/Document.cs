using System;
using System.Collections.Generic;
using System.Text;

namespace TechCodeLib.DAL.Entities
{
    public class Document : BaseEntity
    {        
        public string FileName { get; set; }
        public string DocUrl { get; set; }
        public string FileType { get; set; }

    }
}
