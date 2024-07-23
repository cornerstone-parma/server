namespace CornerstoneManager.Repositories;

public interface IRepository<T>
{
    ICollection<T> GetAll();
    T GetById(int id);
    T Add(T entity);
    int Update(T entity);
    int Delete(int id);
    bool Exists(int id);
}