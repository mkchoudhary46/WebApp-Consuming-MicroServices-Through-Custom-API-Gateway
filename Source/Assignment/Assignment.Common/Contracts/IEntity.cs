namespace Assignment.Common.Contracts
{
    public interface IEntity
    {
        object Id { get; }
    }

    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }
}
