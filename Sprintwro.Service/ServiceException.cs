using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprintwro.Service
{
    public abstract class ServiceException : Domain.DomainException
    {
        public string Code { get; }

        protected ServiceException(string code, string message) : base(message)
        {
            Code = code;
        }

        protected ServiceException(string code, Exception innerException) : base(innerException.Message, innerException)
        {
            Code = code;
        }
    }
}
