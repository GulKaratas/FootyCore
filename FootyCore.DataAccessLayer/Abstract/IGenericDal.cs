namespace FootyCore.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task Insert(T t);
        Task Update(T t);
        Task Delete(int id);
        Task<List<T>> GetList();
        Task<T> GetById(int id);
    }
}
