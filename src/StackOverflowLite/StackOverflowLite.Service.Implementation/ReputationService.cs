using System;
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
            return BoundaryLogging<int>.Wrapper("AddReputationForQuestion", () =>
            {
                var attemptsLeft = 3;
                while (attemptsLeft > 0)
                {
                    try
                    {
                        int pointsToAdd = question.UpVotes*5 - question.DownVotes*2;
                        int newReputation = _userDataService.AddReputationForUser(question.Author, pointsToAdd);
                        return newReputation;
                    }
                    catch
                    {
                        attemptsLeft--;
                        if (attemptsLeft == 0)
                        {
                            throw;
                        }
                    }
                }
                throw new Exception();
            });
        }

        public int AddReputationForAnswer(Answer answer)
        {
            AnswerValidator.ValidateAnswer(answer);
            return BoundaryLogging<int>.Wrapper("AddReputationForAnswer", () =>
            {
                var attemptsLeft = 3;
                while (attemptsLeft > 0)
                {
                    try
                    {

                        int pointsToAdd = answer.UpVotes*10 - answer.DownVotes*3;
                        int newReputation = _userDataService.AddReputationForUser(answer.Author, pointsToAdd);
                        return newReputation;
                    }
                    catch
                    {
                        attemptsLeft--;
                        if (attemptsLeft == 0)
                        {
                            throw;
                        }
                    }
                }
                throw new Exception();
            });
        }
    }
}
