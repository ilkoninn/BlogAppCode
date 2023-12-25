using BlogApp.Business.DTOs.CommonDTOs;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.TeacherDTOs
{
    public record ReadTeacherDTO : BaseAuditableTableDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
