using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities;

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public DateTime? PublishedDate { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? CreatedAt { get; set; }
    public string? Description { get; set; }
    public int AddedBy { get; set; }
}