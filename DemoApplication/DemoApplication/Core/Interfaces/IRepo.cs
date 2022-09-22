namespace DemoApplication.Interface
{
    public interface IRepo<T, ID, RT> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(ID id);
        Task<RT> Create(T obj);
        bool Update(T obj);
        Task<bool> Delete(ID id);
    }
}
