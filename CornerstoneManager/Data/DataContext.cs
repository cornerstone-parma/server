using CornerstoneManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace CornerstoneManager.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Shift> Shifts { get; set; }
}