
namespace Sprintwro.Service.Session
{
    public interface ISessionService
    {
        Task<Domain.Post> AddPost(Domain.SessionId sessionId, string message);
        Task<Domain.Session> Create();
    }
}
