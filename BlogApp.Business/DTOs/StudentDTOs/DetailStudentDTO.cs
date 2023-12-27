using BlogApp.Business.DTOs.CommonDTOs;
using BlogApp.Business.DTOs.CourseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.StudentDTOs
{
    public record DetailStudentDTO : BaseAuditableEntityDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public ICollection<MiniReadCourseDTO> Courses { get; set; }
    }
}
