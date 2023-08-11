using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities;

public class Quote
{
    public int Id { get; set; }
    public string? Value { get; set; }
    public string? From { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? CreatedAt { get; set; }
    public int UserId { get; set; }
}