using BlogApp.Business.DTOs.CommonDTOs;
using BlogApp.Business.DTOs.CourseDTOs;
using BlogApp.Core.Entities;
using BlogApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.TeacherDTOs
{
    public record DetailTeacherDTO : BaseAuditableEntityDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public ICollection<MiniReadCourseDTO>? Courses { get; set; }
    }
}
