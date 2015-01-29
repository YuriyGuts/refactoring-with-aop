using System;

namespace StackOverflowLite.CrossCutting.Utils
{
    public static class BoundaryLogging<T>
    {
        public static T Wrapper(string methodName, Func<T> function)
        {
            Console.WriteLine("{0:HH:mm:ss.fff}: {1} started.", DateTime.Now, methodName);
            try
            {
                T result = function();
                Console.WriteLine("{0:HH:mm:ss.fff}: {1} completed.", DateTime.Now, methodName);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0:HH:mm:ss.fff}: {1} failed with exception: {2}.", DateTime.Now, methodName, ex);
                throw;
            }
        }
    }
}
