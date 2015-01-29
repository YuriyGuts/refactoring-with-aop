using System;

namespace StackOverflowLite.CrossCutting.Utils
{
    public class MultipleAttemptExecutor<T>
    {
        public static T Run(int maxAttempts, Func<T> action)
        {
            var attemptsLeft = maxAttempts;
            while (attemptsLeft > 0)
            {
                try
                {
                    var result = action();
                    return result;
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
            throw new Exception("Maximum attempts reached.");
        }
    }
}
