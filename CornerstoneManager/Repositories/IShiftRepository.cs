using CornerstoneManager.Entities;

namespace CornerstoneManager.Repositories;

public interface IShiftRepository
{
    ICollection<Shift> GetAll();
    Shift? GetById(int id);
    Shift Add(Shift shift);
    int Update(Shift shift);
    int Delete(Shift shift);
    bool Exists(int id);
}