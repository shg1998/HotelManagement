using System;
using AutoMapper;
using HotelManagement.Data;
using HotelManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HotelManagement.Services;
using Microsoft.AspNetCore.Http;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public AccountController(UserManager<ApiUser> userManager, ILogger<AccountController> logger, IMapper mapper,IAuthManager authManager)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDTO userDto)
        {
            _logger.LogInformation($"Registration Attempt for {userDto.Email}");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var user = _mapper.Map<ApiUser>(userDto);
                user.UserName = userDto.Email;
                var result = await _userManager.CreateAsync(user,userDto.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRolesAsync(user, userDto.Roles);
                    return Accepted();
                }
                foreach (var err in result.Errors) ModelState.AddModelError(err.Code, err.Description);
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went Wrong in the {nameof(Register)}");
                return Problem($"Something went Wrong in the {nameof(Register)}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            _logger.LogInformation($"Login Attempt for {loginDto.Email}");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                if (!await _authManager.ValidateUser(loginDto))  return Unauthorized();
                return Accepted(new {Token = await  _authManager.CreateToken()});
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went Wrong in the {nameof(Login)}");
                return Problem($"Something went Wrong in the {nameof(Login)}", statusCode: 500);
            }
        }
    }
}
