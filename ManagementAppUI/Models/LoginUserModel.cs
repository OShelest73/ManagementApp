using System.ComponentModel.DataAnnotations;

namespace ManagementAppUI.Models;

public class LoginUserModel
{
    [Required(ErrorMessage = "Не указан Email")]
    public string EmailAdress { get; set; }

    [Required(ErrorMessage = "Не указан пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
