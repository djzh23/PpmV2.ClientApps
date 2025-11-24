using System;
using System.Collections.Generic;
using System.Text;

namespace PpmV2.UI.Shared.Services;

public class AuthResult
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
    public string? Token { get; set; }

    public static AuthResult Ok(string? token = null) =>
        new() { Success = true, Token = token };

    public static AuthResult Fail(string error) =>
        new() { Success = false, ErrorMessage = error };
}
