namespace backend.Models.Users;

using System.ComponentModel.DataAnnotations;

public class CreateUserRequest
{
    [Required]
    public string? Username { get; set; }

    [Required]
    public string? Password { get; set; }

}