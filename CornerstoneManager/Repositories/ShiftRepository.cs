using CornerstoneManager.Data;
using CornerstoneManager.Entities;

namespace CornerstoneManager.Repositories;

public class ShiftRepository(DataContext context) : IShiftRepository
{
    public ICollection<Shift> GetAll()
    {
        return context.Shifts.ToList();
    }

    public Shift? GetById(int id)
    {
        return context.Shifts.Find(id);
    }

    public Shift Add(Shift shift)
    {
        context.Shifts.Add(shift);
        context.SaveChanges();

        return shift;
    }

    public int Update(Shift shift)
    {
        var currentShift = context.Shifts.Find(shift.Id);

        if (currentShift is null) throw new Exception("Shift not found id: " + shift.Id);

        currentShift.Title = shift.Title;
        currentShift.StartAt = shift.StartAt;
        currentShift.EndAt = shift.EndAt;

        return context.SaveChanges();
    }

    public int Delete(Shift shift)
    {
        context.Shifts.Remove(shift);

        return context.SaveChanges();
    }

    public bool Exists(int id)
    {
        return context.Shifts.Any(s => s.Id == id);
    }
}