using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Services.Intefaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            var result = await _service.ReadAsync();

            return StatusCode(StatusCodes.Status200OK, result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> ReadId(int Id)
        {
            try
            {
                var result = await _service.ReadAsync(Id);

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
        public async Task<IActionResult> Create([FromForm] CreateCategoryDTO create)
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
        public async Task<IActionResult> Update([FromForm] UpdateCategoryDTO update)
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
