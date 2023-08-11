namespace backend.Models.Books;

using System.ComponentModel.DataAnnotations;

public class UpdateBookRequest
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Author { get; set; }
    [Required]
    public DateTime? PublishedDate { get; set; }
    public string? Description { get; set; }
}