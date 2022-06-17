

namespace Sprintwro.Service.Session
{
    public interface ISessionRepository
    {
        Task Save(Domain.Session session);
        Task<Domain.Session?> Get(Domain.SessionId id);
    }
}
