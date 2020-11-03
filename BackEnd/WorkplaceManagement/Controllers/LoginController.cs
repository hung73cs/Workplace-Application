using AutoMapper;
using Entities.DTOs;
using Entities.Models.ModelsNonEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using System;

namespace WorkplaceManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public LoginController(ILoginService loginService, IUserService userService, IMapper mapper)
        {
            _loginService = loginService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Login login)
        {

            try
            {
                IActionResult response = Unauthorized();
                var user = _loginService.Login(login.UserName, login.PassWord);

                    var tokenString = _loginService.GenerateJWTToken(user);
                return Ok(new { status = true, value = tokenString.ToString() });

            }
            catch (Exception e)
            {
                return Ok(new { status = false, value = e.Message });
            }
        }

    }
}
