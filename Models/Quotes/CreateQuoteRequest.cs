namespace backend.Models.Quotes;

using System.ComponentModel.DataAnnotations;

public class CreateQuoteRequest
{
    [Required]
    public string? Value { get; set; }
    public string? From { get; set; }
    [Required]
    public int UserId { get; set; }
}