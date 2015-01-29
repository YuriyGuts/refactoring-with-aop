using StackOverflowLite.CrossCutting.Utils;
using StackOverflowLite.Data.Contracts;
using StackOverflowLite.Domain;
using StackOverflowLite.Domain.Validators;
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

        public int AddReputationForQuestion(Question question)
        {
            QuestionValidator.ValidateQuestion(question);
            return BoundaryLogging<int>.Run("AddReputationForQuestion", () =>
            {
                return MultipleAttemptExecutor<int>.Run(3, () =>
                {
                    int pointsToAdd = question.UpVotes * 5 - question.DownVotes * 2;
                    int newReputation = _userDataService.AddReputationForUser(question.Author, pointsToAdd);
                    return newReputation;
                });
            });
        }

        public int AddReputationForAnswer(Answer answer)
        {
            AnswerValidator.ValidateAnswer(answer);
            return BoundaryLogging<int>.Run("AddReputationForAnswer", () =>
            {
                return MultipleAttemptExecutor<int>.Run(3, () =>
                {
                    int pointsToAdd = answer.UpVotes * 10 - answer.DownVotes * 3;
                    int newReputation = _userDataService.AddReputationForUser(answer.Author, pointsToAdd);
                    return newReputation;
                });
            });
        }
    }
}
