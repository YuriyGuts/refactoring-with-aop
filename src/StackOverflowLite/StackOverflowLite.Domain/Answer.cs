using System;

namespace StackOverflowLite.Domain
{
    public class Answer
    {
        public Guid Id { get; set; }

        public Guid QuestionId { get; set; }

        public User Author { get; set; }

        public string Text { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }
    }
}