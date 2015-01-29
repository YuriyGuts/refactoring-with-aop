using StackOverflowLite.Domain;

namespace StackOverflowLite.Service.Contracts
{
    public interface IReputationService
    {
        int AddReputationForQuestion(Question question);

        int AddReputationForAnswer(Answer answer);
    }
}
