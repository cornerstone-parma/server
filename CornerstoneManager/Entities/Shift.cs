namespace CornerstoneManager.Entities;

public class Shift
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
}