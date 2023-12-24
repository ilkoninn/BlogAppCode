using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BlogApp.Business.DTOs.CategoryDTOs
{
    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
