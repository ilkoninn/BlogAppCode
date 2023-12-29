using BlogApp.Business.DTOs.StudentDTOs;
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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly IWebHostEnvironment _environment;

        public StudentsController(IStudentService service, IWebHostEnvironment environment)
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
        public async Task<IActionResult> Create([FromForm] CreateStudentDTO create)
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
        public async Task<IActionResult> Update([FromForm] UpdateStudentDTO update)
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
