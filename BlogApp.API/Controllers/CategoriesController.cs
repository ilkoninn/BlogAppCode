using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.Services.Intefaces;
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

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        // <-- Read API Section -->
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            ReadCategoryDTO readAll = await _service.ReadAsync();

            return StatusCode(StatusCodes.Status200OK, readAll.Categories);
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> ReadId(int Id)
        {
            ReadCategoryDTO readOne = await _service.ReadAsync(Id);

            return StatusCode(StatusCodes.Status200OK, readOne.Category);
        }

        // <-- Create API Section -->
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDTO create)
        {
            var result = await _service.CreateAsync(create);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        // <-- Update API Section -->
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCategoryDTO update)
        {
            var result = await _service.UpdateAsync(update);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        // <-- Delete API Section -->
        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteCategoryDTO delete)
        {
            var result = _service.DeleteAsync(delete);

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
