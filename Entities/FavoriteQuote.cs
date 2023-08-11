using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities;

public class FavoriteQuote
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuoteId { get; set; }
}