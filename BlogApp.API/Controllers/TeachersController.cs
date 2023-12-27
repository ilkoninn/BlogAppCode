using BlogApp.Business.DTOs.TeacherDTOs;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Services.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _service;
        private readonly IWebHostEnvironment _environment;

        public TeachersController(ITeacherService service, IWebHostEnvironment environment)
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
        public async Task<IActionResult> Create([FromForm] CreateTeacherDTO create)
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
        public async Task<IActionResult> Update([FromForm] UpdateTeacherDTO update)
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
