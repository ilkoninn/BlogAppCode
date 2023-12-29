using BlogApp.Business.DTOs.CourseDTOs;
using BlogApp.Business.DTOs.CourseDTOs;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Services.InternalServices.Intefaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            var result = await _service.ReadAsync();
            
            return StatusCode(StatusCodes.Status200OK, result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> ReadId(int Id)
        {
            try
            {
                var result = await _service.ReadIdAsync(Id);

                return Ok(result);
            }
            catch (NegativeIdException ex)
            {
                return StatusCode(StatusCodes.Status200OK, ex.Message);
            }
            catch (ObjectNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (ObjectNullException ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status502BadGateway, ex.Message);
            }
        }

        // <-- Create API Section -->
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCourseDTO create)
        {
            try
            {
                var result = await _service.CreateAsync(create, _environment.WebRootPath);

                return Ok(result);
            }
            catch (NegativeIdException ex)
            {
                return StatusCode(StatusCodes.Status200OK, ex.Message);
            }
            catch (ObjectNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (ObjectNullException ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status502BadGateway, ex.Message);
            }

        }

        // <-- Update API Section -->
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCourseDTO update)
        {
            try
            {
                var result = await _service.UpdateAsync(update, _environment.WebRootPath);

                return Ok(result);
            }
            catch (NegativeIdException ex)
            {
                return StatusCode(StatusCodes.Status200OK, ex.Message);
            }
            catch (ObjectNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (ObjectNullException ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status502BadGateway, ex.Message);
            }

        }

        // <-- Delete API Section -->
        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] int Id)
        {
            try
            {
                var result = await _service.DeleteAsync(Id);

                return Ok(result);
            }
            catch (NegativeIdException ex)
            {
                return StatusCode(StatusCodes.Status200OK, ex.Message);
            }
            catch (ObjectNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (ObjectNullException ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status502BadGateway, ex.Message);
            }
        }
    }
}
