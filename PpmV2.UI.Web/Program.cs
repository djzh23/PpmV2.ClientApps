using Microsoft.AspNetCore.Components.Web;
using PpmV2.UI.Shared;
using PpmV2.UI.Shared.Services;
using PpmV2.UI.Web.Components;
using PpmV2.UI.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


//builder.Services.AddScoped<IAuthService, MockAuthService>();
builder.Services.AddHttpClient<IAuthService, ApiAuthService>(client =>
{
    // TODO: enter real backend URL here
    // client.BaseAddress = new Uri("https://ppm-backend.onrender.com/api/");
    client.BaseAddress = new Uri("https://ppmv2-hbb4.onrender.com/api/");
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseStaticFiles(); // Serves files from wwwroot folder

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(new[] { typeof(SharedAssemblyMarker).Assembly });

app.Run();
