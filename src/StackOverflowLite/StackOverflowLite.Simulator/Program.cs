using System;
using System.Collections.Generic;
using StackOverflowLite.Data.Implementation;
using StackOverflowLite.Domain;
using StackOverflowLite.Service.Contracts;
using StackOverflowLite.Service.Implementation;

namespace StackOverflowLite.Simulator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var question = CreateDummyQuestion();
            var reputationService = GetReputationService();

            reputationService.AddReputationForQuestion(question);
            foreach (var answer in question.Answers)
            {
                reputationService.AddReputationForAnswer(answer);
            }
        }

        private static Question CreateDummyQuestion()
        {
            var questionId = Guid.NewGuid();
            var question = new Question
            {
                Id = questionId,
                Title = "Unsure if I understand TransactionAwarePersistenceManagerFactoryProxy",
                Text = "What happens if the proxy doesn't get made properly? " +
                    "Can I still use it to access my factory to create a transaction aware persistence manager? " +
                    "If the object managed by the factory is a singleton, does this change things?",
                Tags = new List<Tag>
                {
                    new Tag
                    {
                        Id = Guid.NewGuid(),
                        Name = "java"
                    },
                    new Tag
                    {
                        Id = Guid.NewGuid(),
                        Name = "spring"
                    }
                },
                Author = new User
                {
                    Id = Guid.NewGuid(),
                    Username = "megazord@fakemail.com",
                    DisplayName = "megazord",
                    Reputation = 1208
                },
                UpVotes = 160,
                DownVotes = 1,

                Answers = new List<Answer>
                {
                    new Answer
                    {
                        Id = Guid.NewGuid(),
                        QuestionId = questionId,
                        Author = new User
                        {
                            Id = Guid.NewGuid(),
                            Username = "griwes@fakemail.com",
                            DisplayName = "Griwes",
                            Reputation = 1025,
                        },
                        Text = "And this, dear children, is why Java should stop taking drugs.",
                        UpVotes = 120,
                        DownVotes = 10,
                    },
                    new Answer
                    {
                        Id = Guid.NewGuid(),
                        QuestionId = questionId,
                        Author = new User
                        {
                            Id = Guid.NewGuid(),
                            Username = "chandpriyankara@fakemail.com",
                            DisplayName = "chandpriyankara",
                            Reputation = 460,
                        },
                        Text = "DAOs could seamlessly switch between a JNDI PersistenceManagerFactory and this proxy for a local PersistenceManagerFactory.",
                        UpVotes = 13,
                        DownVotes = 0
                    }
                }
            };

            return question;
        }

        private static IReputationService GetReputationService()
        {
            return new ReputationService(new FakeConsoleEchoingUserDataService());
        }
    }
}
