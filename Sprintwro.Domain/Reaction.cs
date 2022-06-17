using Sprintwro.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprintwro.Domain
{
    public class Reaction : ValueObject
    {
        private readonly string _code;

        private Reaction(string code)
        {
            _code = code;
        }

        public static Reaction Create(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException($"'{nameof(code)}' cannot be null or whitespace.", nameof(code));
            }

            return new Reaction(code);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _code;
        }

        public override string ToString()
        {
            return _code;
        }

        public static readonly Reaction PlusOne = new("plus-one");
    }
}
