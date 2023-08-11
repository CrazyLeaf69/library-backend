namespace backend.Models.Books;

public class BookResponse
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public DateTime? PublishedDate { get; set; }
    public string? Description { get; set; }
    public string? AddedBy { get; set; }
}