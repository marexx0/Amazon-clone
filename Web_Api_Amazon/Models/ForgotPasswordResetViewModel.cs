using System.ComponentModel.DataAnnotations;

public class ForgotPasswordResetViewModel
{
    public string Email { get; set; }
    public string Token { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The passwords do not match.")]
    public string ConfirmPassword { get; set; }
}
