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
            throw new NotImplementedException();
        }

        public int AddReputationForAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
