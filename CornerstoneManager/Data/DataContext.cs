using CornerstoneManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace CornerstoneManager.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Person> Persons { get; set; }
}