using System.Net.Http.Json;
using PpmV2.UI.Shared.Auth;
using PpmV2.UI.Shared.Models;

namespace PpmV2.UI.Shared.Services;

public class ApiAuthService : IAuthService
{
    private readonly HttpClient _http;

    public ApiAuthService(HttpClient http)
    {
        _http = http;
    }

    public async Task<AuthResult> RegisterAsync(RegisterModel model)
    {
        try
        {
            // Mapping auf dein Backend-DTO RegisterRequest
            var payload = new
            {
                Email = model.Email,
                Password = model.Password,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Role = model.Role.ToString() // "Admin", "Coordinator", ...
            };

            // TODO: Pfad an deine reale Route anpassen (z.B. "api/auth/register")
            var response = await _http.PostAsJsonAsync("auth/register", payload);

            if (response.IsSuccessStatusCode)
                return AuthResult.Ok();

            var errorText = await response.Content.ReadAsStringAsync();
            return AuthResult.Fail($"Registrierung fehlgeschlagen: {errorText}");
        }
        catch (Exception ex)
        {
            return AuthResult.Fail($"Registrierungsfehler: {ex.Message}");
        }
    }

    public async Task<AuthResult> LoginAsync(LoginModel model)
    {
        // Platzhalter – wir implementieren den Login-Flow später sauber.
        try
        {
            var payload = new
            {
                Email = model.Email,
                Password = model.Password
            };

            var response = await _http.PostAsJsonAsync("auth/login", payload);

            if (!response.IsSuccessStatusCode)
            {
                var errorText = await response.Content.ReadAsStringAsync();
                return AuthResult.Fail($"Login fehlgeschlagen: {errorText}");
            }

            var result = await response.Content.ReadFromJsonAsync<LoginResponseDto>();
            return AuthResult.Ok(result?.Token);
        }
        catch (Exception ex)
        {
            return AuthResult.Fail($"Login-Fehler: {ex.Message}");
        }
    }

    // DTO passend zu deiner Login-Response (später ggf. anpassen)
    private sealed class LoginResponseDto
    {
        public string? Token { get; set; }
    }
}
