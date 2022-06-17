using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprintwro.Domain
{
    public class User
    {
        public UserId Id { get; }
        public Pseudonym Pseudonym { get; }

        private User(UserId id, Pseudonym pseudonym)
        {
            Id = id;
            Pseudonym = pseudonym;
        }

        public static User Create(UserId id, Pseudonym pseudonym)
        {
            ArgumentNullException.ThrowIfNull(id);
            ArgumentNullException.ThrowIfNull(pseudonym);

            return new User(id, pseudonym);
        }
    }
}
