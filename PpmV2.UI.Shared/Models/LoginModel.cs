using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PpmV2.UI.Shared.Models;

public class LoginModel
{
    [Required(ErrorMessage = "E-mail ist erforderlich.")]
    [EmailAddress(ErrorMessage = "Bitte eine gültige E-Mail-Adresse eingeben.")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Passwort ist erforderlich.")]
    [MinLength(6, ErrorMessage = "Das Passwort muss mindestens 6 Zeichen lang sein.")]
    public string Password { get; set; } = string.Empty;
    public bool RememberMe { get; set; }
}
