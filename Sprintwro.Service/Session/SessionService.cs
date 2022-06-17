using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprintwro.Service.Session
{
    public class SessionService : ISessionService
    {
        private readonly ICurrentUserAccessor _currentUserAccessor;
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ICurrentUserAccessor currentUserAccessor, ISessionRepository sessionRepository)
        {
            _currentUserAccessor = currentUserAccessor;
            _sessionRepository = sessionRepository;
        }

        public async Task<Domain.Session> Create()
        {
            var session = new Domain.Session();

            await _sessionRepository.Save(session);

            return session;
        }

        public async Task<Domain.Post> AddPost(Domain.SessionId sessionId, string message)
        {
            ArgumentNullException.ThrowIfNull(sessionId);

            var session = await _sessionRepository.Get(sessionId);

            if (session == null)
            {
                throw new SessionNotFoundException(sessionId);
            }

            var writer = _currentUserAccessor.CurrentUser;

            var newPost = Domain.Post.Create(writer.Id, message);

            session.Posts.Add(newPost);

            await _sessionRepository.Save(session);

            return newPost;
        }
    }
}
