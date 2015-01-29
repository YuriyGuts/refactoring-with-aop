using System;
using PostSharp.Aspects;

namespace StackOverflowLite.CrossCutting.Aspects
{
    [Serializable]
    public class BoundaryLogging : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("{0:HH:mm:ss.fff}: {1} started.", DateTime.Now, args.Method.Name);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("{0:HH:mm:ss.fff}: {1} completed.", DateTime.Now, args.Method.Name);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            Console.WriteLine("{0:HH:mm:ss.fff}: {1} failed with exception: {2}.", DateTime.Now, args.Method.Name, args.Exception);
        }
    }
}
