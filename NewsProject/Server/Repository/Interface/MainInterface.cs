using NewsProject.Shared.Models;

namespace NewsProject.Server.Repository.Main
{
    public interface MainInterface<T> where T : class 
    {
        Task<IEnumerable<T>?>GetAll();
        Task<IEnumerable<T>?> GetAll(string include);
        Task<T?>GetbyId(int id);
        Task<T> AddRowe(T entity);
        Task<T?>Update(int id, T entity);
        Task Delete(int id);
        Task<bool> Exsiset(Func<T,bool> test);
    }
}
