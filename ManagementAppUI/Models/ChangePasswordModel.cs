using System.ComponentModel.DataAnnotations;

namespace ManagementAppUI.Models;

public class ChangePasswordModel
{
    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Confirm password field do not match the original password")]
    [MinLength(6)]
    public string PasswordConfirm { get; set; }
}
