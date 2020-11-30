using System;
using System.Collections.Generic;
using System.Text;

namespace TechCodeLib.DAL.Entities
{
    public class Subject : BaseEntity
    {        
        public string Name { get; set; }
        public int? ParentSubjectId { get; set; }
        public Subject ParentSubject { get; set; }

    }
}
