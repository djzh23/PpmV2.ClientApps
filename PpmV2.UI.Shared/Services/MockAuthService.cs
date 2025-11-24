// In PpmV2.UI.Web/Services/MockAuthService.cs
using PpmV2.UI.Shared.Models;
using PpmV2.UI.Shared.Services;

namespace PpmV2.UI.Web.Services;

public class MockAuthService : IAuthService
{
    public Task<AuthResult> RegisterAsync(RegisterModel model)
    {
        // Simuliere eine kurze Netzwerkverzögerung
        Task.Delay(500).Wait();

        // Simuliere eine Validierungslogik, um den Fehlerfall zu testen
        // Wenn die E-Mail "fail" enthält, geben wir einen Fehler zurück.
        if (model.Email.Contains("fail"))
        {
            return Task.FromResult(new AuthResult
            {
                Success = false,
                ErrorMessage = "Diese E-Mail-Adresse ist bereits vergeben (Mock-Fehler)."
            });
        }

        // Simuliere eine erfolgreiche Registrierung
        return Task.FromResult(new AuthResult { Success = true });
    }

    public Task<AuthResult> LoginAsync(LoginModel model)
    {
        // Simuliere eine kurze Netzwerkverzögerung
        Task.Delay(500).Wait();
        // Simuliere eine einfache Login-Logik
        if (model.Email == "")
        {
            return Task.FromResult(new AuthResult
            {
                Success = false,
                ErrorMessage = "E-Mail darf nicht leer sein (Mock-Fehler)."
            });
        }
        if (model.Password == "password")
        {
            return Task.FromResult(new AuthResult
            {
                Success = true,
            }
            );
            }
        return Task.FromResult(new AuthResult
            {
            Success = false,
            ErrorMessage = "Ungültige Anmeldeinformationen (Mock-Fehler)."
        });
        }
    }