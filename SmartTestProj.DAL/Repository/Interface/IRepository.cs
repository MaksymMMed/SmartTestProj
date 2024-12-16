namespace SmartTestProj.DAL.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task Delete(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> GetCompleteById(Guid id);
        Task Insert(T entity);
        Task Update(T entity);
    }
}