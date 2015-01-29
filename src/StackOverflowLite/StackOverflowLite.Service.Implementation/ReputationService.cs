using StackOverflowLite.CrossCutting.Aspects;
using StackOverflowLite.Data.Contracts;
using StackOverflowLite.Domain;
using StackOverflowLite.Service.Contracts;

namespace StackOverflowLite.Service.Implementation
{
    public class ReputationService : IReputationService
    {
        private readonly IUserDataService _userDataService;

        public ReputationService(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }

        [DomainValidation]
        [BoundaryLogging]
        [MultipleAttemptExecution(3)]
        public int AddReputationForQuestion(Question question)
        {
            int pointsToAdd = question.UpVotes * 5 - question.DownVotes * 2;
            int newReputation = _userDataService.AddReputationForUser(question.Author, pointsToAdd);
            return newReputation;
        }

        [DomainValidation]
        [BoundaryLogging]
        [MultipleAttemptExecution(3)]
        public int AddReputationForAnswer(Answer answer)
        {
            int pointsToAdd = answer.UpVotes * 10 - answer.DownVotes * 3;
            int newReputation = _userDataService.AddReputationForUser(answer.Author, pointsToAdd);
            return newReputation;
        }
    }
}
