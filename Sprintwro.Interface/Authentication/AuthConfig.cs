using System.ComponentModel.DataAnnotations;

namespace Sprintwro.Interface.Authentication
{
    public class AuthConfig
    {
        [Required]
        public string Secret { get; set; }
        [Required]
        public string Issuer { get; set; }
        [Required]
        public string Audience { get; set; }
    }
}
