using System;
using PostSharp.Aspects;

namespace StackOverflowLite.CrossCutting.Aspects
{
    [Serializable]
    public class MultipleAttemptExecution : MethodInterceptionAspect
    {
        private readonly int _maxAttempts;

        public MultipleAttemptExecution(int maxAttempts)
        {
            _maxAttempts = maxAttempts;
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var attemptsLeft = _maxAttempts;
            while (attemptsLeft > 0)
            {
                try
                {
                    args.Proceed();
                    return;
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
