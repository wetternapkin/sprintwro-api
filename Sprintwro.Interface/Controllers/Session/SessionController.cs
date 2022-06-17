using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprintwro.Service.Session;

namespace Sprintwro.Interface.Controllers.Session
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class SessionController : Controller
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost()]
        public async Task<ActionResult> CreateSession()
        {
            var session = await _sessionService.Create();

            var result = new CreateSessionResponseDto
            {
                SessionId = session.Id.Value,
            };

            return Ok(result);
        }

        [HttpPost("{sessionId}/posts")]
        public async Task<ActionResult> CreatePost(string sessionId, [FromBody] CreatePostCommandArgs args)
        {
            var post = await _sessionService.AddPost(Domain.SessionId.Create(Guid.Parse(sessionId)), args.Message);

            return Ok(post);
        }
    }
}
