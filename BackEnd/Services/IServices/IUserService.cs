using Entities.DTOs;
using Entities.Models;
using Entities.Models.ModelsNonEntities;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Services.IServices
{
    public interface IUserService
    {
        string EncodePassword(string originalPassword);
        IEnumerable<UserVM> GetAll();
        UserVM GetByID(GetObjectId getObject);
        User ChangePassword(ChangePassword changePasswordModel);
        User CreateUser(User user);
        User UpdateUser(User user);
        bool DeleteUser(GetObjectId deleteUserViewModel);
    }
}
