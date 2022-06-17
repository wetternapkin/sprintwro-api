using System.ComponentModel.DataAnnotations;

namespace Sprintwro.Interface.Controllers
{
    public class AuthRequest
    {
        [Required]
        public string Pseudonym { get; set; }
    }
}
