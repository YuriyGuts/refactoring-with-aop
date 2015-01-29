using System;

namespace StackOverflowLite.Domain
{
    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string DisplayName { get; set; }

        public int Reputation { get; set; }
    }
}