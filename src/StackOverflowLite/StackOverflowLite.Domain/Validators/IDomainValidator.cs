namespace StackOverflowLite.Domain.Validators
{
    public interface IDomainValidator<in T>
    {
        void Validate(T obj);
    }
}