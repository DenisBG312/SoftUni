namespace HighwayToPeak.Repositories.Contracts
{
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> All { get; }

        void Add(T model);

        T Get(string name);
    }
}
