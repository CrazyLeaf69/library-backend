namespace backend.Models.FavoriteQuotes;

using System.ComponentModel.DataAnnotations;

public class DeleteFavoriteQuoteRequest
{
    [Required]
    public int FavoriteQuoteId { get; set; }
}