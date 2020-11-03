using AutoMapper;
using Entities;
using Entities.DTOs;
using Entities.Models;
using Entities.Models.ModelsNonEntities;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPermissionService _permissionService;
        public UserService(DataContext context, IMapper mapper, IPermissionService permissionService)
        {
            _context = context;
            _mapper = mapper;
            _permissionService = permissionService;
        }

        public string EncodePassword(string originalPassword)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
        }

        public Boolean CheckValidPassword(string password)
        {
            //min 6 chars, max 12 chars
            if (password.Length < 6 || password.Length > 12)
                return false;

            //No white space
            if (password.Contains(" "))
                return false;

            //At least 1 upper case letter
            if (!password.Any(char.IsUpper))
                return false;

            //At least 1 lower case letter
            if (!password.Any(char.IsLower))
                return false;

            //No two similar chars consecutively
            for (int i = 0; i < password.Length - 1; i++)
            {
                if (password[i] == password[i + 1])
                    return false;
            }

            //At least 1 special char
            string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialCharactersArray = specialCharacters.ToCharArray();
            foreach (char c in specialCharactersArray)
            {
                if (password.Contains(c))
                    return true;
            }
            return false;
        }

        public IEnumerable<UserVM> GetAll()
        {
            IEnumerable<User> users = _context.Users;
            IEnumerable<UserVM> usersDTO = _mapper.Map<IEnumerable<UserVM>>(users);
            return usersDTO;
        }

        public UserVM GetByID(GetObjectId getObject)
        {
            User user = _context.Users.Find(getObject.Id);
            UserVM usersDTO = _mapper.Map<UserVM>(user);
            return usersDTO;
        }


        public User CreateUser(User user)
        {
            //Con cai ID department chua check
            if (string.IsNullOrWhiteSpace(user.PassWord) ||
                string.IsNullOrWhiteSpace(user.UserName) ||
                string.IsNullOrWhiteSpace(user.DisplayName))
            {
                throw new Exception("Password, Username va DisplayName la bat buoc");
            }
            if (_context.Users.Any(x => x.UserName == user.UserName))
            {
                throw new Exception("Username da ton tai!");
            }
            if (CheckValidPassword(user.PassWord) == false)
            {
                throw new Exception("Password khong hop le!");
            }
            user.PassWord = EncodePassword(user.PassWord);
            user.DepartmentId = null;
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User ChangePassword(ChangePassword changePassword)
        {

            if (string.IsNullOrWhiteSpace(changePassword.CurrentPassword) || string.IsNullOrWhiteSpace(changePassword.NewPassword))
            {
                throw new Exception("Yeu cau nhap day du cac truong du lieu");
            }
            User user = _context.Users.FirstOrDefault(x => x.UserName == changePassword.UserName);
            if (user == null)
            {
                throw new Exception("User can doi password khong ton tai");
            }
            if (changePassword.CurrentPassword == changePassword.NewPassword)
            {
                throw new Exception("Mat khau moi khong duoc trung voi mat khau cu");
            }
            changePassword.CurrentPassword = EncodePassword(changePassword.CurrentPassword);
            if (changePassword.CurrentPassword != user.PassWord)
            {
                throw new Exception("Password hien tai khong dung");
            }
            changePassword.NewPassword = EncodePassword(changePassword.NewPassword);
            user.PassWord = changePassword.NewPassword;
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(User userToUpdate)
        {
            User user = _context.Users.FirstOrDefault(x => x.UserName == userToUpdate.UserName);
            if (user == null)
            {
                throw new Exception("User can doi password khong ton tai");
            }
            user.DisplayName = userToUpdate.DisplayName;
            user.PhoneNumber = userToUpdate.PhoneNumber;
            user.Birthday = userToUpdate.Birthday;
            user.DepartmentId = userToUpdate.DepartmentId;
            _context.Update(user);
            _context.SaveChanges();
            return user;
        }

        public bool DeleteUser(GetObjectId deleteUserViewModel)
        {
            var user = _context.Users.Find(deleteUserViewModel.Id);
            if (user != null)
            {
                var per = _context.Relationshipuserpermissions.FirstOrDefault(x => x.UserId == user.Id);
                if (per != null)
                {
                    _context.Relationshipuserpermissions.Remove(per);
                }
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
