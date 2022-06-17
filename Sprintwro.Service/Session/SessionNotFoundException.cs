using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprintwro.Service.Session
{
    public class SessionNotFoundException : ServiceException
    {
        public SessionNotFoundException(Domain.SessionId id) : base("SESSION_NOT_FOUND", $"the session with id {id} was not found")
        {

        }
    }
}
