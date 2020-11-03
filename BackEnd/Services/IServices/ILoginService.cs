using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IServices
{
    public interface ILoginService
    {
        string GenerateJWTToken(User userInfo);
        User Login(string userName, string password);
        bool CheckActionCode(long perID, string actCode);
    }
}
