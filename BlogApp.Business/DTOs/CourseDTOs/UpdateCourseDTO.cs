using BlogApp.Business.DTOs.CommonDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.CourseDTOs
{
    public record UpdateCourseDTO : BaseEntityDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
