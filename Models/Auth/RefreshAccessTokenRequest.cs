namespace backend.Models.Auth;

using System.ComponentModel.DataAnnotations;

public class RefreshAccessTokenRequest
{
    [Required]
    public string RefreshToken { get; set; }
}