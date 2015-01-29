using System;
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

        public int AddReputationForQuestion(Question question)
        {
            Console.WriteLine("{0:HH:mm:ss.fff}: AddReputationForQuestion started.", DateTime.Now);

            int pointsToAdd = question.UpVotes * 5 - question.DownVotes * 2;
            int newReputation = _userDataService.AddReputationForUser(question.Author, pointsToAdd);

            Console.WriteLine("{0:HH:mm:ss.fff}: AddReputationForQuestion completed.", DateTime.Now);
            return newReputation;
        }

        public int AddReputationForAnswer(Answer answer)
        {
            Console.WriteLine("{0:HH:mm:ss.fff}: AddReputationForAnswer started.", DateTime.Now);

            int pointsToAdd = answer.UpVotes * 10 - answer.DownVotes * 3;
            int newReputation = _userDataService.AddReputationForUser(answer.Author, pointsToAdd);

            Console.WriteLine("{0:HH:mm:ss.fff}: AddReputationForAnswer completed.", DateTime.Now);
            return newReputation;
        }
    }
}
