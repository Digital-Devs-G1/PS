namespace Application.Interfaces.IRepositories.IQuery
{
    public interface IGenericRepositoryQuerys<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
