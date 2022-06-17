using Sprintwro.Domain.Utils;

namespace Sprintwro.Domain
{
    public class SessionId : ValueObject
    {
        private readonly Guid _value;

        private SessionId(Guid value)
        {
            _value = value;
        }

        public static SessionId Create(Guid value)
        {
            return new SessionId(value);
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }

        public Guid Value => _value;
    }
}
