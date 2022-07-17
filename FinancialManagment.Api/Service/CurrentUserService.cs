using FinancialManagment.Application.Common.Interfaces;
using IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialManagment.Api.Service
{
    public class CurrentUserService : ICurrentUserService
    {
        public string Email { get; set; }
        public bool IsAuthenticated { get; set; }
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var email = httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Email);

            Email = email;

            IsAuthenticated = !string.IsNullOrEmpty(email);
        }
    }
}
