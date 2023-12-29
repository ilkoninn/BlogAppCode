using BlogApp.Business.DTOs.AccountDTOs;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Services.InternalServices.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountsController(IAccountService service)
        {
            _service = service;
        }

        // <-- Read Users API Section
        [HttpGet("[action]")]
        public async Task<IActionResult> Read()
        {
            var result = await _service.ReadAsync();

            return Ok(result);
        }

        // <-- Registration API Section -->
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromForm] RegisterDTO register)
        {
            var result = await _service.RegisterAsync(register);

            if(result.Keys.Contains("Operation")) 
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // <-- Login API Section -->
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromForm] LoginDTO login)
        {
            try
            {
                var result = await _service.LoginAsync(login);

                return Ok(result);
            }
            catch(ObjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status502BadGateway, ex.Message);
            }
           
        }
    }
}
