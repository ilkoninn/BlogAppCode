using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.Services.Intefaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IWebHostEnvironment _environment;

        public CategoriesController(ICategoryService service, IWebHostEnvironment environment)
        {
            _service = service;
            _environment = environment;
        }

        // <-- Read API Section -->
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            return StatusCode(StatusCodes.Status200OK, await _service.ReadAsync());
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> ReadId(int Id)
        {
            var result = await _service.ReadAsync(Id);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        // <-- Create API Section -->
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDTO create)
        {
            var result = await _service.CreateAsync(create, _environment.WebRootPath);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        // <-- Update API Section -->
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCategoryDTO update)
        {
            var result = await _service.UpdateAsync(update, _environment.WebRootPath);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        // <-- Delete API Section -->
        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] int Id)
        {
            var result = await _service.DeleteAsync(Id);

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
