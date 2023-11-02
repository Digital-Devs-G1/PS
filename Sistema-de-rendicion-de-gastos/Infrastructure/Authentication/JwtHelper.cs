using Application.Exceptions;
using Infrastructure.Authentication.Constants;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Infrastructure.Authentication
{
    public class JwtHelper : IJwtHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetEmployeeId()
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            string? id = GetClaimValue(token, TypeClaims.Id);
            int employeeId;
            if (!int.TryParse(id, out employeeId))
                throw new InvalidTokenInformation();
            return employeeId;
        }

        private string GetClaimValue(string token, string claim)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            string authHeader = token.Replace("Bearer ", "").Replace("bearer ", "");
            JwtSecurityToken tokens = handler.ReadToken(authHeader) as JwtSecurityToken;

            Claim claimData = tokens.Claims.FirstOrDefault(
                cl => cl.Type.ToUpper() == claim.ToUpper()
            );

            if(claimData == null || string.IsNullOrEmpty(claimData.Value))
                throw new UnauthorizedAccessException();

            return claimData.Value;
        }
    }
}