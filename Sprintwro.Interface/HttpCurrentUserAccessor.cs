using Sprintwro.Domain;
using Sprintwro.Interface.Authentication;
using Sprintwro.Service;
using System.Security.Claims;

namespace Sprintwro.Interface
{
    public class HttpCurrentUserAccessor : ICurrentUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpCurrentUserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public User CurrentUser { 
            get
            {
                var principal = _httpContextAccessor.HttpContext?.User;

                if (principal == null)
                {
                    throw new UserNotFoundException();
                }

                var id = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (id == null)
                {
                    throw new InvalidClaimsException(ClaimTypes.NameIdentifier);
                }

                var pseudo = principal.FindFirst(ClaimTypes.Surname)?.Value;

                if (pseudo == null)
                {
                    throw new InvalidClaimsException(ClaimTypes.Surname);
                }

                return User.Create(UserId.Create(Guid.Parse(id)), Pseudonym.Create(pseudo));
            } 
        }
    }
}
