using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sprintwro.Domain
{
    public class Post
    {
        public const int MinLengthMessage = 3;
        public const int MaxLengthMessage = 500;
        public UserId Owner { get; }
        public string Message { get; }
        public DateTimeOffset Creation { get; set; }
        public Reactions Reactions { get; set; } = new();

        private Post(UserId owner, string message)
        {
            Owner = owner;
            Message = message;
        }

        public static Post Create(UserId owner, string message)
        {
            ArgumentNullException.ThrowIfNull(owner);
            ArgumentNullException.ThrowIfNull(message);

            if (message is { Length: < MinLengthMessage } or { Length: > MaxLengthMessage})
            {
                throw new ArgumentException($"The min length is {MinLengthMessage} and the max length is {MaxLengthMessage}", nameof(message));
            }

            return new Post(owner, message);
        }
    }
}
