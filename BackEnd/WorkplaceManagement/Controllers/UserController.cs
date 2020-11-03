using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Entities.Models.ModelsNonEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using System;
using System.Security.Claims;

namespace WorkplaceManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILoginService _loginService;
        public UserController(IUserService userService, IMapper mapper, ILoginService loginService)
        {
            _userService = userService;
            _mapper = mapper;
            _loginService = loginService;
        }

        [HttpGet("GetAllUser")]
        [Authorize]
        public IActionResult GetAll()
        {
            var perID = long.Parse(HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Role).Value);
            var allow = _loginService.CheckActionCode(perID, "getalluser");
            if (allow)
            {
                var role = HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Role);

                var user = _userService.GetAll();
                return Ok(user);
            }
            return BadRequest("No permission");
        }

        [HttpGet("GetUserById")]
        [Authorize]
        public IActionResult GetUserById([FromBody]GetObjectId getObject)
        {
            var perID = long.Parse(HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Role).Value);
            var allow = _loginService.CheckActionCode(perID, "getuserbyid");
            if (allow)
            {
                var role = HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Role);

                var user = _userService.GetByID(getObject);
                return Ok(user);
            }
            return BadRequest("No permission");
        }

        [HttpPost("CreateUser")]
        public IActionResult Create([FromBody]UserVM userDTO)
        {
            /*var perID = long.Parse(HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Role).Value);
            var allow = _loginService.CheckActionCode(perID, "createuser");*/
            var allow = true;
            if (allow)
            {
                try
                {
                    User user = _mapper.Map<User>(userDTO);
                    var createUser = _userService.CreateUser(user);
                    return Ok(new { status = true, value = "Tao user thanh cong" });

                }catch(Exception e)
                {
                    return Ok(new { status = false, value = e.Message });
                }
            }
            return BadRequest("No permission");
        }


        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword([FromBody]ChangePassword changePasswordModel)
        {
            try
            {
                changePasswordModel.UserName = HttpContext.User.FindFirst(c => c.Type == "userName").Value;
                var result = _userService.ChangePassword(changePasswordModel);
                return Ok(new { status = false, value = "Thay doi password thanh cong" });
            }
            catch (Exception e)
            {
                return Ok(new { status = false, value = e.Message });

            }
        }


        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UserVM userDTO)
        {
            try
            {
                User user = _mapper.Map<User>(userDTO);
                _userService.UpdateUser(user);
                return Ok(new { status = true, value = "Sua thong tin user thanh cong" });

            }
            catch (Exception e)
            {
                return Ok(new { status = false, value = e.Message });

            }
        }
        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser([FromBody] GetObjectId deleteUserDTO)
        {
            var perID = long.Parse(HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Role).Value);
            var allow = _loginService.CheckActionCode(perID, "deleteuser");
            if (allow)
            {
                var boo = _userService.DeleteUser(deleteUserDTO);
                if (boo == true)
                {
                    return Ok(new { status = true, value = "Xoa user thanh cong" });
                }
                else
                {
                    return Ok(new { status = false, value = "Xoa user KHONG thanh cong" });
                }
            }
            return BadRequest("No permission");
        }
    }
}
