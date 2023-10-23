using Application.Exceptions;
using Infrastructure.Authentication.Constants;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication
{
    public interface IJwtHelper
    {
        public int GetEmployeeId();        
    }
}
