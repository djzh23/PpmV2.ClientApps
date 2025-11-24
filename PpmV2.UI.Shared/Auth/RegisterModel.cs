using System.ComponentModel.DataAnnotations;
using PpmV2.UI.Shared.Auth;

namespace PpmV2.UI.Shared.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "E-Mail ist erforderlich.")]
    [EmailAddress(ErrorMessage = "Bitte eine gültige E-Mail eingeben.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Passwort ist erforderlich.")]
    [MinLength(6, ErrorMessage = "Mindestens 6 Zeichen.")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Passwort-Bestätigung ist erforderlich.")]
    [Compare(nameof(Password), ErrorMessage = "Passwörter stimmen nicht überein.")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vorname ist erforderlich.")]
    public string Firstname { get; set; } = string.Empty;

    [Required(ErrorMessage = "Nachname ist erforderlich.")]
    public string Lastname { get; set; } = string.Empty;

    [Required(ErrorMessage = "Rolle ist erforderlich.")]
    public UserRole Role { get; set; } = UserRole.Honorarkraft; // Standard-Rolle

    public bool AcceptTerms { get; set; }
}
