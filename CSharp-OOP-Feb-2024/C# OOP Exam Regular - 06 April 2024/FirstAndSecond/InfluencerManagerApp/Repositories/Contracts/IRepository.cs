namespace InfluencerManagerApp.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        IReadOnlyCollection<T> Models {  get; }


        void AddModel(T model);

        bool RemoveModel(T model);

        T FindByName(string name);
    }
}
