namespace backend.Models.Quotes;

using System.ComponentModel.DataAnnotations;

public class UpdateQuoteRequest
{
    [Required]
    public string? Value { get; set; }
    public string? From { get; set; }
}