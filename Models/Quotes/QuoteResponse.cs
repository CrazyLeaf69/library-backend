namespace backend.Models.Quotes;

public class QuoteResponse
{
    public int Id { get; set; }
    public string? Value { get; set; }
    public string? From { get; set; }
    public int? UserId { get; set; }
    public string? Username { get; set; }
    public int? FavoriteQuoteId { get; set; }
}