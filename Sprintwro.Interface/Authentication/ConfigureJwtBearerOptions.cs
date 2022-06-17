using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Sprintwro.Interface.Authentication
{
    public class ConfigureJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>
    {
		private readonly AuthConfig _authConfig;

        public ConfigureJwtBearerOptions(IOptions<AuthConfig> options)
        {
			_authConfig = options.Value;
        }

        public void Configure(JwtBearerOptions options)
        {
			var key = Encoding.UTF8.GetBytes(_authConfig.Secret);
			options.SaveToken = true;
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = false,
				ValidateAudience = false,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = _authConfig.Issuer,
				ValidAudience = _authConfig.Audience,
				IssuerSigningKey = new SymmetricSecurityKey(key)
			};
		}

        public void Configure(string name, JwtBearerOptions options)
        {
			Configure(options);
        }
    }
}
