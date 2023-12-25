using BlogApp.Business.DTOs.CommonDTOs;
using BlogApp.Business.DTOs.StudentDTOs;
using BlogApp.Business.DTOs.TeacherDTOs;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.CourseDTOs
{
    public record ReadCourseDTO : BaseAuditableTableDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
        public ICollection<ReadStudentDTO>? Students { get; set; }
        public ReadTeacherDTO? Teacher { get; set; }
    }
}
