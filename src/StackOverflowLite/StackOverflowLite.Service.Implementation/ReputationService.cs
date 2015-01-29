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
            if (question == null)
            {
                throw new ArgumentNullException("question");
            }
            if (question.Author == null)
            {
                throw new ArgumentNullException("question", "Author cannot be null.");
            }
            if (question.UpVotes < 0 || question.DownVotes < 0)
            {
                throw new ArgumentException("A question cannot have a negative number of votes");
            }

            Console.WriteLine("{0:HH:mm:ss.fff}: AddReputationForQuestion started.", DateTime.Now);

            var attemptsLeft = 3;
            try
            {
                while (attemptsLeft > 0)
                {
                    try
                    {
                        int pointsToAdd = question.UpVotes * 5 - question.DownVotes * 2;
                        int newReputation = _userDataService.AddReputationForUser(question.Author, pointsToAdd);

                        Console.WriteLine("{0:HH:mm:ss.fff}: AddReputationForQuestion completed.", DateTime.Now);
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0:HH:mm:ss.fff}: AddReputationForQuestion failed with exception: {1}.", DateTime.Now, ex);
            }
            throw new Exception();
        }

        public int AddReputationForAnswer(Answer answer)
        {
            if (answer == null)
            {
                throw new ArgumentNullException("answer");
            }
            if (answer.Author == null)
            {
                throw new ArgumentNullException("answer", "Author cannot be null.");
            }
            if (answer.UpVotes < 0 || answer.DownVotes < 0)
            {
                throw new ArgumentException("An answer cannot have a negative number of votes");
            }

            Console.WriteLine("{0:HH:mm:ss.fff}: AddReputationForAnswer started.", DateTime.Now);

            var attemptsLeft = 3;
            try
            {
                while (attemptsLeft > 0)
                {
                    try
                    {

                        int pointsToAdd = answer.UpVotes * 10 - answer.DownVotes * 3;
                        int newReputation = _userDataService.AddReputationForUser(answer.Author, pointsToAdd);

                        Console.WriteLine("{0:HH:mm:ss.fff}: AddReputationForAnswer completed.", DateTime.Now);
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0:HH:mm:ss.fff}: AddReputationForAnswer failed with exception: {1}.", DateTime.Now, ex);
            }
            throw new Exception();
        }
    }
}
