using PpmV2.UI.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PpmV2.UI.Shared.Services;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(RegisterModel model);
    Task<AuthResult> LoginAsync(LoginModel model); // LoginModel kannst du später ergänzen/verwenden
}
