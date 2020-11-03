using Entities;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.IServices;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public LoginService(DataContext context, IConfiguration configuration, IUserService userService)
        {
            _context = context;
            _configuration = configuration;
            _userService = userService;

        }
        public User Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new Exception("Username va password la bat buoc");
            }
            var user = _context.Users.SingleOrDefault(x => x.UserName == username);
            if (user == null)
                throw new Exception("Username chua dang ky");
            else
            {
                if (_userService.EncodePassword(password) != user.PassWord)
                {
                    throw new Exception("Mat khau SAI");
                }
            }
            return user;
        }

        public string GenerateJWTToken(User userInfo)
        {
            var permissionID = _context.Relationshipuserpermissions.Where(up => up.UserId == userInfo.Id).Select(up=>up.PermissionId).FirstOrDefault();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
            new Claim("userName", userInfo.UserName.ToString()),
            new Claim(ClaimTypes.Role,permissionID.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],

            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool CheckActionCode(long perID, string actCode)
        {
            var act = _context.Detailpermissions.Where(act => act.PermissionId == perID && act.ActionCode == actCode).FirstOrDefault();
            if (act != null) return true;
            return false;
        }
    }
}
