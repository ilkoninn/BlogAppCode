using BlogApp.Core.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.CourseDTOs
{
    public record CreateCourseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
    }
}
