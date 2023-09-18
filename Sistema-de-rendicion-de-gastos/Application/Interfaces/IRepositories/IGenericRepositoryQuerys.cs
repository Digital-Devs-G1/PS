namespace Application.Interfaces.IRepositories
{
    public interface IGenericRepositoryQuerys<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
