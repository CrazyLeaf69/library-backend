namespace backend.Models.FavoriteQuotes;

using System.ComponentModel.DataAnnotations;

public class CreateFavoriteQuoteRequest
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public int QuoteId { get; set; }
}