using BlogApp.Business.DTOs.CourseDTOs;
using BlogApp.Business.Services.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _service;
        private readonly IWebHostEnvironment _environment;

        public CoursesController(ICourseService service, IWebHostEnvironment environment)
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
        public async Task<IActionResult> Create([FromForm] CreateCourseDTO create)
        {
            var result = await _service.CreateAsync(create, _environment.WebRootPath);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        // <-- Update API Section -->
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCourseDTO update)
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
