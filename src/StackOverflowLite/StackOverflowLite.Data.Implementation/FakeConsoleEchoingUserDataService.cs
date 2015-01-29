using System;
using StackOverflowLite.Data.Contracts;
using StackOverflowLite.Domain;

namespace StackOverflowLite.Data.Implementation
{
    public class FakeConsoleEchoingUserDataService : IUserDataService
    {
        public int AddReputationForUser(User user, int reputationToAdd)
        {
            user.Reputation += reputationToAdd;
            Console.WriteLine("DataService: Added {0} reputation points to user {1}. The reputation is now {2}.", reputationToAdd, user.DisplayName, user.Reputation);
            return user.Reputation;
        }
    }
}
