using System;

namespace StackOverflowLite.Domain.Validators
{
    public class AnswerValidator
    {
        public static void ValidateAnswer(Answer answer)
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
        }
    }
}
