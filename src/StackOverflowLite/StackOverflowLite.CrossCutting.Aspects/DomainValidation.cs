using System;
using System.Linq;
using System.Reflection;
using PostSharp.Aspects;
using StackOverflowLite.Domain.Validators;

namespace StackOverflowLite.CrossCutting.Aspects
{
    [Serializable]
    public class DomainValidation : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            foreach (var argument in args.Arguments)
            {
                Type domainValidatorType = typeof(IDomainValidator<>).MakeGenericType(argument.GetType());
                var validatorImplementorType = Assembly.GetAssembly(typeof(IDomainValidator<>))
                    .GetTypes()
                    .FirstOrDefault(t => domainValidatorType.IsAssignableFrom(t));

                if (validatorImplementorType != null)
                {
                    var validatorImplementorObject = Activator.CreateInstance(validatorImplementorType);
                    validatorImplementorType.InvokeMember
                    (
                        "Validate",
                        BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance,
                        null,
                        validatorImplementorObject,
                        new [] { argument }
                    );
                }
            }
        }
    }
}
