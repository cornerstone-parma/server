using System.ComponentModel.DataAnnotations;

namespace CornerstoneManager.Entities;

public class Shift
{
    public int Id { get; set; }
    
    [MaxLength(100)]
    public required string Title { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
}