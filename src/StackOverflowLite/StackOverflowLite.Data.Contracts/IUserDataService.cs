using StackOverflowLite.Domain;

namespace StackOverflowLite.Data.Contracts
{
    public interface IUserDataService
    {
        int AddReputationForUser(User user, int reputationToAdd);
    }
}
