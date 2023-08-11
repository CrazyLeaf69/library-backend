namespace backend.Models.Users;

using System.ComponentModel.DataAnnotations;

public class UpdateUserRequest
{
    [Required]
    public string? Id { get; set; }
    [Required]
    public string? Username { get; set; }

    [Required]
    public string? Password { get; set; }
}