using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Dtos;
using Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly IService<ProviderDto> _provService;
        private readonly IService<OwnerDto> _ownerService;
        private readonly IConfiguration _config;

        public LoginService(IService<ProviderDto> provService, IService<OwnerDto> ownerService, IConfiguration config)
        {
            _provService = provService;
            _ownerService = ownerService;
            _config = config;
        }
        public string GenerateTokenP(ProviderDto prov)
        {
            //the code to encode in a bytes array
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //encoding
            var carditional = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, prov.Name),
                new Claim(ClaimTypes.NameIdentifier, prov.Name.ToString()),
                new Claim(ClaimTypes.Role, "prov")
            };
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"], _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: carditional
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateTokenO(OwnerDto owner)
        {
            //the code to encode in a bytes array
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //encoding
            var carditional = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, owner.Name),
                new Claim(ClaimTypes.NameIdentifier, owner.Name.ToString()),
                new Claim(ClaimTypes.Role, "owner")
            };
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"], _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: carditional
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ProviderDto VerifyP(string name, string pwd)
        {
            return _provService.GetAll().FirstOrDefault(p => p.Name == name && BCrypt.Net.BCrypt.Verify(pwd, p.Password));
        }

        public OwnerDto VerifyO(string name, string pwd)
        {
            return _ownerService.GetAll().FirstOrDefault(o => o.Name == name && BCrypt.Net.BCrypt.Verify(pwd, o.Password));
        }

        public bool ValidateId(ClaimsPrincipal user, int id)
        {
            var claim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
            {
                return false;
            }
            return int.Parse(claim.Value) == id;
        }

        public int GetIdFromToken(ClaimsPrincipal user)
        {
            var claim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
            {
                return -1;
            }
            return int.Parse(claim.Value);
        }

        public bool CheckIsOwner(ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Role).Value == "owner";
        }
    }
}