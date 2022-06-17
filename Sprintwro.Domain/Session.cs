using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprintwro.Domain
{
    public class Session
    {
        public List<Post> Posts { get; init; } = new();

        public DateTimeOffset DateTimeOffset { get; init; } = DateTimeOffset.UtcNow;
        public SessionId Id { get; }

        public Session()
        {
            Id = SessionId.Create(Guid.NewGuid());
        }

        private Session(SessionId id)
        {
            Id = id;
        }

        public static Session Create(SessionId id)
        {
            ArgumentNullException.ThrowIfNull(id);

            return new Session(id);
        }

    }
}
