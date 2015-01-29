using System;
using System.Collections.Generic;

namespace StackOverflowLite.Domain
{
    public class Question
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public User Author { get; set; }

        public IList<Tag> Tags { get; set; }

        public IList<Answer> Answers { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }
    }
}
