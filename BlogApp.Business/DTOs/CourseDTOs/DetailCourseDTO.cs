using BlogApp.Business.DTOs.CommonDTOs;
using BlogApp.Business.DTOs.StudentDTOs;
using BlogApp.Business.DTOs.TeacherDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.CourseDTOs
{
    public record DetailCourseDTO : BaseAuditableEntityDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
        public MiniReadTeacherDTO? Teacher { get; set; }
        public ICollection<MiniDetailStudentDTO>? Students { get; set; }
    }
    public record MiniDetailStudentDTO : BaseAuditableEntityDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
    }

}
