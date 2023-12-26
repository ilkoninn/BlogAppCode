using BlogApp.Business.DTOs.CourseDTOs;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.StudentDTOs
{
    public record CreateStudentDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public ICollection<CreateCourseDTO> Courses { get; set; }
    }
}
