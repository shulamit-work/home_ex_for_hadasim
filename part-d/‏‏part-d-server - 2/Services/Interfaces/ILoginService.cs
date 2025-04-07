using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILoginService
    {
        string GenerateToken(UserDto user);
        UserDto Verify(string name, string pwd);
        bool ValidateUserId(ClaimsPrincipal user, int userId);
        int GetUserIdFromToken(ClaimsPrincipal user);
        bool CheckIsOwner(ClaimsPrincipal user);
    }
}









    //public interface ILoginService
    //{
    //    string GenerateTokenP(UserDto prov);
    //    string GenerateTokenO(OwnerDto owner);
    //    UserDto VerifyP(string name, string pwd);
    //    OwnerDto VerifyO(string name, string pwd);
    //    bool ValidateId(ClaimsPrincipal user, int id);
    //    int GetIdFromToken(ClaimsPrincipal user);
    //    bool CheckIsOwner(ClaimsPrincipal user);
