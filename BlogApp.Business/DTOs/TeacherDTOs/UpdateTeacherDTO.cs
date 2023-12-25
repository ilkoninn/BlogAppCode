using BlogApp.Business.DTOs.CommonDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.TeacherDTOs
{
    public record UpdateTeacherDTO : BaseEntityDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }

    }
}
