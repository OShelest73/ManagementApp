using System.ComponentModel.DataAnnotations;

namespace ManagementAppUI.Models;

public class CreateUserModel
{
    [Required]
    [EmailAddress]
    public string EmailAdress { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Confirm password field do not match the original password")]
    [MinLength(6)]
    public string PasswordConfirm { get; set; } 

    [Required]
    [MinLength(2)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2)]
    public string LastName { get; set; }

    [Required]
    public string Category { get; set; }
}
