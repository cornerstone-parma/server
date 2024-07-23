using System.ComponentModel.DataAnnotations;

namespace CornerstoneManager.Entities;

public class Shift
{
    [Key] public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public required string Title { get; set; }

    [Required] public DateTime StartAt { get; set; }

    [Required] public DateTime EndAt { get; set; }
}