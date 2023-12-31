﻿using BlogApp.Business.DTOs.CommonDTOs;
using BlogApp.Business.DTOs.CourseDTOs;
using BlogApp.Core.Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.StudentDTOs
{
    public record ReadStudentDTO : BaseEntityDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public ICollection<MiniReadCourseDTO> Courses { get; set; } 
    }
    public record MiniReadStudentDTO : BaseEntityDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
    }
}
