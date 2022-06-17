
using Sprintwro.Domain;
using Sprintwro.Service.Session;

namespace Sprintwro.Infrastructure
{
    public class MemorySessionRepository : ISessionRepository
    {
        private readonly Dictionary<SessionId, Session> _sessions;

        public MemorySessionRepository()
        {
            _sessions = new();
        }

        public Task Save(Session session)
        {
            return Task.Run(() => _sessions[session.Id] = session);
        }

        public async Task<Session?> Get(SessionId id)
        {
            if (!_sessions.TryGetValue(id, out var session))
            {
                return null;
            }

            return await Task.FromResult(session);
        }
    }
}
