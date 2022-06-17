using Sprintwro.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprintwro.Domain
{
    public class UserId : ValueObject
    {
        private readonly Guid _value;

        private UserId(Guid value)
        {
            _value = value;
        }

        public UserId()
        {
            _value = Guid.NewGuid();
        }

        public static UserId Create(Guid value)
        {
            return new UserId(value);
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }
    }
}
