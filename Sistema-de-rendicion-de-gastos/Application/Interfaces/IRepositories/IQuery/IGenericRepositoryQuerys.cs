namespace Application.Interfaces.IRepositories.IQuery
{
    public interface IGenericRepositoryQuerys<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
    }
}
