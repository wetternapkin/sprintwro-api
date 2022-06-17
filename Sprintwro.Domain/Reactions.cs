using System.Collections;

namespace Sprintwro.Domain
{
    public class Reactions : IEnumerable<(long count, Reaction reaction)>
    {

        private readonly Dictionary<Reaction, List<User>> _reactions = new();

        public Reactions()
        {

        }

        public Reactions(Dictionary<Reaction, List<User>> reactions)
        {
            _reactions = reactions;
        }

        public IEnumerator<(long count, Reaction reaction)> GetEnumerator()
        {
            return _reactions.Select((pair) => (count: pair.Value.LongCount(), reaction: pair.Key)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
