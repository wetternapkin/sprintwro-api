using Sprintwro.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sprintwro.Domain
{
    public class Pseudonym : ValueObject
    {
        private static readonly Regex Regex = new(@"[a-zA-Z0-9]{4,50}");

        private readonly string _value;

        private Pseudonym(string value)
        {
            _value = value;
        }

        public static Pseudonym Create(string value)
        {
            if (!Regex.IsMatch(value)) throw new ArgumentException($"{value} is not a valid Pseudonym, it needs to respect the Regex {Regex}");

            return new Pseudonym(value);
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
