namespace backend.Models.Books;

using System.ComponentModel.DataAnnotations;

public class CreateBookRequest
{
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Author { get; set; }
    [Required]
    public DateTime? PublishedDate { get; set; }
    public string? Description { get; set; }
    [Required]
    public int AddedBy { get; set; }
}