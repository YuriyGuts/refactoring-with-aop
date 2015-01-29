using System;

namespace StackOverflowLite.Domain.Validators
{
    public class QuestionValidator : IDomainValidator<Question>
    {
        public void Validate(Question question)
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
        }
    }
}
